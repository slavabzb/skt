import sqlite3
import logging

from datetime import datetime

class sqlite_provider():
	def __init__(self, config):
		logging.debug('Sqlite provider init: config {}'.format(config))
		self.__config = config
		self.__filename =  self.__config.find('file').text
		self.__datefmt = self.__config.find('dateformat').text

	def connect(self):
		logging.debug('Connecting to `{}`'.format(self.__filename))
		self.__cnx = sqlite3.connect(self.__filename)

	def close(self):
		logging.debug('Closing connection to `{}`'.format(self.__filename))
		self.__cnx.commit()
		self.__cnx.close()

	def apply(self, fp):
		self.__cnx.executescript(fp.read())

	def execute(self, query, **kw):
		for k in kw:
			if type(kw[k]) == datetime:
				kw[k] = datetime.strftime(kw[k], self.__datefmt)

		query = query.format(**kw)
		logging.info(query)

		res = []

		for row in self.__cnx.execute(query):
			data = []

			for idx, el in enumerate(row):
				if 'sqlitedatefmtids' in kw and idx in kw['sqlitedatefmtids']:
					data.append(datetime.strptime(row[idx], self.__datefmt))
				else:
					data.append(row[idx])

			res.append(data)

		return res
