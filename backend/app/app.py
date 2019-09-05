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
