import os
import logging
import settings

from provider import provider_factory

class dbmanager():
	def __init__(self, config):
		logging.debug('Db manager init: config {}'.format(config))
		self.__config = config

		self.__fields = {}
		for node in self.__config.find('fields'):
			self.__fields.update({node.get('alias'): node.text})

		factory = provider_factory(self.__config.find('provider_factory'))
		
		self.__provider = factory.create_provider(self.__config.find('provider').text)
		self.__provider.connect()

	def close(self):
		logging.debug('Db manager close')
		self.__provider.close()

	def get_stock_info(self, symbol, begin = None, end = None):
		logging.debug('Db manager get stock info: symbol `{symbol}`, begin `{begin}`, end `{end}`'.format(symbol=symbol, begin=begin, end=end))
		res = []

		try:
			query = (
				"select "
					"st.date,"
					"st.open,"
					"st.high,"
					"st.low,"
					"st.close,"
					"st.volume"
				" from "
					"STOCK s join STOCK_DATA st using(stock_id)"
				" where "
					"s.name = '{symbol}'"
			)

			if begin:
				query = query + " and st.date >= '{begin}'"

			if end:
				query = query + " and st.date <= '{end}'"

			query = query + " order by st.date"

			res = self.__provider.execute(query, symbol=symbol, begin=begin, end=end, sqlitedatefmtids=[0])
		except Exception as e:
			logging.warning(e)

		stock_info = []

		for row in res:
			info = {
				self.__fields['date']: row[0],
				self.__fields['open']: row[1],
				self.__fields['high']: row[2],
				self.__fields['low']: row[3],
				self.__fields['close']: row[4],
				self.__fields['volume']: row[5],
			}

			stock_info.append(info)

		return stock_info

	def make_migration(self):
		logging.debug('Db manager make migration')
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

		logging.debug('Current database version is `{}`'.format(current_version))

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
								logging.debug('Skipping file `{}`'.format(filename))
							else:
								logging.debug('Applying file `{}`'.format(filename))
								with open(os.path.join(dirpath, new_version, filename), 'rb') as f:
									self.__provider.apply(f.read())
									self.__provider.execute("insert into MIGRATION_FILES values ('{filename}')", filename=filename)
						self.__provider.execute('update MIGRATION_VERSION set `version` = {version}', version=int(new_version))
				except Exception as e:
					self.__provider.execute('update MIGRATION_VERSION set `dirty` = 1')
					raise e
