import os
import logging
import settings

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
			self.__make_migration()

	def stop(self):
		logging.info('Service stopped')

	def __make_migration(self):
		current_version = 0
		
		try:
			c = self.__db.execute('select version from MIGRATION_VERSION')
			current_version = c.fetchone()[0]
		except:
			pass

		for dirpath, dirnames, filenames in os.walk(settings.dirs['migration']):
			for new_version in sorted(dirnames):
				if int(new_version) >= current_version:
					try:
						for filename in sorted(os.listdir(os.path.join(dirpath, new_version))):
							with open(os.path.join(dirpath, new_version, filename), 'rb') as f:
								self.__db.apply(f.read())
								self.__db.execute('insert into MIGRATION_FILES values (\'{}\')'.format(filename))
						self.__db.execute('update MIGRATION_VERSION set `version` = {}'.format(current_version + 1))
					except:
						self.__db.execute('update MIGRATION_VERSION set `dirty` = 1')
						return
