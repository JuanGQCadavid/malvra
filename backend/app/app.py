# Data base bridge
from database_bridge import Db_bridge
#API
from flask import Flask, request, jsonify
from flask_cors import CORS
import json
import os


app = Flask(__name__)
CORS(app)
db = None;


@app.route('/api/')
def hello_world_api():
    return 'Backend up!!'

#Get all the workers
@app.route('/api/workers/all')
def get_workers():
    workers = db.get_workers()
    print(workers)
    return jsonify(workers)

@app.route('/api/workers/add', methods=['POST'])
def add_worker():
    return "To do ..."

#Save a rotine to a worker
@app.route('/api/routines/add', methods=['POST'])
def add_routine():
    return "To do ..."
    

@app.route('/api/test/workers')
def test_workers():
    db.add_workers('Koko', 'Leonardo','Ortega','koko@loscantoresdechipuco.tocapues')
    db.add_workers('Coronel', 'Julian','Coronel','Coronel@loscantoresdechipuco.tocapues')
    db.add_workers('Karval', 'Carlos','Valencia','Karval@loscantoresdechipuco.tocapues')

    return get_workers()

@app.route('/')
def hello_world_web():
    return 'Yo, sup bro'

@app.route('/api/temp/')
def temp():
    return jsonify(data)

if __name__ == '__main__':
    dev_state, state = None,None

    try:
        state = os.environ['ENVSTATE']
    except:

        state = os.environ['ENVSTATE'] = 'DEV'
    
    if state == 'PROD':
        print("Production ENV")
        dev_state = False
    elif state == 'DEV':
        print("Deveploment ENV")
        dev_state = True
    else:
        raise Exception("ENVSTATE is unknowing, STATE -> {}".format(state))

    try:
        db = Db_bridge(dev_state)
        app.run(host='0.0.0.0', port=5000, debug=dev_state)
    except KeyboardInterrupt:
        print('Closing server....')
