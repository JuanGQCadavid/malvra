from pymongo import MongoClient, DESCENDING
from bson.objectid import ObjectId

class Db_bridge:
    def __init__(self, development_state):
        print("Class connected")

        if (development_state):
            host = 'mongo-server'
        else:
            host = 'mongo-server'

        port = 27017

        #Connect to mongo
        self.client = MongoClient(host,port)

        #Create or use the dabase
        self.db = self.client['malvra_db']

        #Add or use a collection
        self.workers = self.db.workers
        self.routines = self.db.routines