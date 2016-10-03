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
			c = self.__db.execute('select version, dirty from MIGRATION_VERSION')
			res = c.fetchone()
			current_version = int(res[0])
			dirty = int(res[1])
			if dirty:
				logging.error('Migration {} is broken. Please, fix it manually. Aborting.'.format(current_version))
				return
		except:
			pass

		logging.info('Current database version is {}'.format(current_version))

		for dirpath, dirnames, filenames in os.walk(settings.dirs['migration']):
			for new_version in sorted(dirnames):
				files = []

				if int(new_version) == current_version:
					try:
						c = self.__db.execute('select * from MIGRATION_FILES')
						files = c.fetchall()
					except:
						pass

				if int(new_version) > current_version:
					try:
						self.__db.execute('delete from MIGRATION_FILES')
					except:
						pass

				try:
					if new_version >= current_version:
						for filename in sorted(os.listdir(os.path.join(dirpath, new_version))):
							if (unicode(filename),) in files:
								logging.info('Skipping file `{}`'.format(filename))
							else:
								logging.info('Applying file `{}`'.format(filename))
								with open(os.path.join(dirpath, new_version, filename), 'rb') as f:
									self.__db.apply(f.read())
									self.__db.execute('insert into MIGRATION_FILES values (\'{}\')'.format(filename))
						self.__db.execute('update MIGRATION_VERSION set `version` = {}'.format(int(new_version)))
				except Exception as e:
					print e
					self.__db.execute('update MIGRATION_VERSION set `dirty` = 1')
					return
