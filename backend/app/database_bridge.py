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

    def remove_object_id(self, data_list):
        data_list_returned = []

        for data in data_list:
            print(data)
            id = str(data['_id'])
            data.pop('_id')
            data['_id'] = id

            data_list_returned.append(data)

        return data_list_returned;


    def get_workers(self):
        results = self.workers.find().sort('firstname', DESCENDING)
        return self.remove_object_id(results)
    
    def add_workers(self, username, firstname, lastname, email):
        new_worker = {
            'username': username,
            'firstname': firstname,
            'lastname': lastname,
            'email':email
        }
        result = self.workers.insert_one(new_worker).inserted_id

        if result == None:
            return None;
        
        return new_worker

