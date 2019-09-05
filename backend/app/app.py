# Data base bridge
from database_bridge import Db_bridge
#API
from flask import Flask, request, jsonify
import json
import os


app = Flask(__name__)
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

@app.route('/api/temp')
def temp():
    hola = {
        "tasks": [
        {
        "employee_id": "4321",
        "employee_name": "Gregorio",
        "task": "Desbotonar",
        "block": 41,
        "date": "2019-09-04T08:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "4321",
        "employee_name": "Gregorio",
        "task": "Siembra en Banca",
        "block": 30,
        "date": "2019-09-04T10:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "4321",
        "employee_name": "Gregorio",
        "task": "Siembra en Cama",
        "block": 42,
        "date": "2019-09-04T14:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "4321",
        "employee_name": "Gregorio",
        "task": "Corte",
        "block": 38,
        "date": "2019-09-04T16:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "1234",
        "employee_name": "Maria",
        "task": "Corte",
        "block": 38,
        "date": "2019-09-04T08:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "1234",
        "employee_name": "Maria",
        "task": "Corte",
        "block": 25,
        "date": "2019-09-04T10:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "1234",
        "employee_name": "Maria",
        "task": "Siembra en Cama",
        "block": 42,
        "date": "2019-09-04T14:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "1234",
        "employee_name": "Maria",
        "task": "Corte",
        "block": 25,
        "date": "2019-09-04T16:00:00.000000Z",
        "completed": False,
        "completion_time": None
        },
        {
        "employee_id": "4321",
        "employee_name": "Gregorio",
        "task": "Desbotonar",
        "block": 41,
        "date": "2019-09-04T08:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "4321",
        "employee_name": "Gregorio",
        "task": "Siembra en Banca",
        "block": 30,
        "date": "2019-09-04T10:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "4321",
        "employee_name": "Gregorio",
        "task": "Siembra en Cama",
        "block": 42,
        "date": "2019-09-04T14:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "4321",
        "employee_name": "Gregorio",
        "task": "Corte",
        "block": 38,
        "date": "2019-09-04T16:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "1234",
        "employee_name": "Maria",
        "task": "Corte",
        "block": 38,
        "date": "2019-09-04T08:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "1234",
        "employee_name": "Maria",
        "task": "Corte",
        "block": 25,
        "date": "2019-09-04T10:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "1234",
        "employee_name": "Maria",
        "task": "Siembra en Cama",
        "block": 42,
        "date": "2019-09-04T14:00:00.000000Z",
        "completed": False,
        "completion_time": ""
        },
        {
        "employee_id": "1234",
        "employee_name": "Maria",
        "task": "Corte",
        "block": 25,
        "date": "2019-09-04T16:00:00.000000Z",
        "completed": False,
        "completion_time": None
        }
        ]
    }
    return jsonify(hola)
    

@app.route('/api/test/workers')
def test_workers():
    db.add_workers('Koko', 'Leonardo','Ortega','koko@loscantoresdechipuco.tocapues')
    db.add_workers('Coronel', 'Julian','Coronel','Coronel@loscantoresdechipuco.tocapues')
    db.add_workers('Karval', 'Carlos','Valencia','Karval@loscantoresdechipuco.tocapues')

    return get_workers()
@app.route('/')
def hello_world_web():
    return 'Yo, sup bro'



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
