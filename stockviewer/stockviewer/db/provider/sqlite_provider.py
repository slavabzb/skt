import logging
import sqlite3

class sqlite_provider():
	def __init__(self, config):
		self.__config = config
		self.__file = self.__config.find('file').text
		
		logging.info('Sqlite provider source "{}"'.format(self.__file))

	def connect(self):
		logging.info('Connecting to "{}"'.format(self.__file))
		return sqlite3.connect(self.__file)
