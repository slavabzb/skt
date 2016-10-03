import sqlite3

class sqlite_provider():
	def __init__(self, config):
		self.__config = config
		self.__file = self.__config.find('file').text

	def apply(self, sql_script):
		with sqlite3.connect(self.__file) as cnx:
			cnx.executescript(sql_script)

	def execute(self, query):
		with sqlite3.connect(self.__file) as cnx:
			return cnx.cursor().execute(query)
