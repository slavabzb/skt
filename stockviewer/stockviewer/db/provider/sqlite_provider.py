import sqlite3
import logging
import time

class sqlite_provider():
	def __init__(self, config):
		self.__config = config
		self.__file = self.__config.find('file').text

	def apply(self, sql_script):
		with sqlite3.connect(self.__file) as cnx:
			cnx.executescript(sql_script)

	def execute(self, query, **kw):		
		for k in kw:
			if type(kw[k]) == time.struct_time:
				kw[k] = time.strftime(self.__config.find('dateformat').text, kw[k])

		query = query.format(**kw)
		logging.info(query)

		with sqlite3.connect(self.__file) as cnx:
			return cnx.cursor().execute(query)
