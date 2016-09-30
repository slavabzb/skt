import os
import logging
import settings

from db import dbmanager

class service():
	def __init__(self, args, config):
		self.__args = args
		self.__config = config
		self.__dbmanager = dbmanager(config.find('dbmanager'))

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
			self.__make_migration()

	def stop(self):
		logging.info('Service stopped')

	def __make_migration(self):
		for dirpath, dirnames, filenames in os.walk(settings.dirs['migration']):
			for dirname in sorted(dirnames):
				for filename in sorted(os.listdir(os.path.join(dirpath, dirname))):
					with open(os.path.join(dirpath, dirname, filename), 'rb') as f:
						self.__dbmanager.apply(f)
