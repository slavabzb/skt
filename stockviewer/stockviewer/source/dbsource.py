import logging

from db.provider import provider_factory
from utils import make_fields

class dbsource():
	def __init__(self, config):
		logging.debug('Db source init: config {}'.format(config))
		self.__config = config
		self.__fields = make_fields(self.__config.find('fields'))

		factory = provider_factory(self.__config.find('provider_factory'))
		self.__provider = factory.create_provider(self.__config.find('provider').text)

	def get(self, symbol, begin = None, end = None):
		logging.debug('Database source get: symbol `{symbol}`, begin `{begin}`, end `{end}`'.format(symbol=symbol, begin=begin, end=end))

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

		res = []

		try:
			self.__provider.connect()
			res = self.__provider.execute(query, symbol=symbol, begin=begin, end=end, sqlitedatefmtids=[0])
			self.__provider.close()
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

	def store(self, symbol, stock_data):
		try:
			self.__provider.connect()
			
			query = (
				"select "
					"stock_id"
				" from "
					"STOCK"
				" where "
					"name = '{symbol}'"
			)

			res = self.__provider.execute(query, symbol=symbol)

			stock_id = None

			if res:
				stock_id = res[0][0]
			else:
				query = (
					"insert into "
						"STOCK"
					" values (null, '{symbol}')"
				)

				self.__provider.execute(query, symbol=symbol)

				query = (
					"select "
						"stock_id"
					" from "
						"STOCK"
					" where "
						"name = '{symbol}'"
				)

				res = self.__provider.execute(query, symbol=symbol)

				stock_id = res[0][0]

			query = (
				"insert into "
					"STOCK_DATA"
				" values ({stock_id},'{date}',{open},{high},{low},{close},{volume})"
			)

			self.__provider.execute(query,
				stock_id=stock_id,
				date=stock_data[self.__fields['date']],
				open=stock_data[self.__fields['open']],
				high=stock_data[self.__fields['high']],
				low=stock_data[self.__fields['low']],
				close=stock_data[self.__fields['close']],
				volume=stock_data[self.__fields['volume']]
			)

			self.__provider.close()
		except Exception as e:
			logging.warning(e)

