import os
import logging
import settings

from provider import provider_factory

class dbmanager():
	def __init__(self, config):
		self.__config = config
		
		factory = provider_factory(self.__config.find('provider_factory'))		
		self.__provider = factory.create_provider(self.__config.find('provider').text)

	def get_stock_info(self, symbol, begin = None, end = None):
		stock_info = []

		try:
			query = """
				select
					st.name,
					std.date,
					std.open,
					std.high,
					std.low,
					std.close,
					std.volume
				from STOCK st join STOCK_DATA std using(stock_id)
			"""
			c = self.__provider.execute(query)
			stock_info = c.fetchall()
		except Exception as e:
			logging.warning(e)

		return stock_info

	def make_migration(self):
		current_version = 0

		try:
			c = self.__provider.execute('select version, dirty from MIGRATION_VERSION')
			res = c.fetchone()
			current_version = int(res[0])
			dirty = int(res[1])
			if dirty:
				logging.error('Migration `{}` is broken. Please, fix it manually. Aborting.'.format(current_version))
				return
		except:
			pass

		logging.info('Current database version is `{}`'.format(current_version))

		for dirpath, dirnames, filenames in os.walk(settings.dirs['migration']):
			for new_version in sorted(dirnames):
				files = []

				if int(new_version) == current_version:
					try:
						c = self.__provider.execute('select * from MIGRATION_FILES')
						files = c.fetchall()
					except:
						pass

				if int(new_version) > current_version:
					try:
						self.__provider.execute('delete from MIGRATION_FILES')
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
									self.__provider.apply(f.read())
									self.__provider.execute('insert into MIGRATION_FILES values (\'{}\')'.format(filename))
						self.__provider.execute('update MIGRATION_VERSION set `version` = {}'.format(int(new_version)))
				except Exception as e:
					self.__provider.execute('update MIGRATION_VERSION set `dirty` = 1')
					raise e
