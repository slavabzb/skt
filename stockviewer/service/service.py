import sys, os
sys.path.insert(0, os.path.realpath(os.path.join(os.path.abspath(os.path.dirname(__file__)), '..')))

import json

from flask import Flask, Response, request, render_template

from stockviewer.view import viewmanager
from stockviewer.utils import parse_config

import stockviewer.settings

app = Flask(__name__)

@app.route('/')
def index():
	return render_template('index.html')

@app.route('/view')
def view():
	symbol = request.args.get('symbol')
	begin = request.args.get('begin')
	end = request.args.get('end')

	config = parse_config(stockviewer.settings.files['config'])

	vm = viewmanager(config.find('viewmanager'))
	response = vm.view(symbol, begin, end)

	return Response(json.dumps(response), mimetype='application/json')

if __name__ == '__main__':
	app.run(debug=True)
