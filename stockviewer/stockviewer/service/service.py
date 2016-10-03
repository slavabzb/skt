import logging

from db import dbmanager

class service():
	def __init__(self, args, config):
		self.__args = args
		self.__config = config
		self.__db = dbmanager(config.find('dbmanager'))

	def __enter__(self):
		return self

	def __exit__(self, type, exception, traceback):
		self.stop()
		if exception:
			logging.exception(exception)
		return self

	def start(self):
		logging.info('Service started')

		if self.__args.make_migration:
			self.__db.make_migration()

	def stop(self):
		logging.info('Service stopped')
