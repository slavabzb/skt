from time import strptime, strftime
from db import dbmanager

class viewmanager():
	def __init__(self, config):
		self.__config = config
		self.__db = dbmanager(self.__config.find('dbmanager'))

	def view(self, symbol, begin, end):
		date_format = self.__config.find('date_format').text

		try:
			begin = strptime(begin, date_format)
			end = strptime(end, date_format)
		except ValueError:
			raise Exception('Dates don\'t match the format `{}`'.format(date_format))

		if end <= begin:
			raise Exception('The end `{}` of the period is greater or equal to begin `{}`'.format(strftime(date_format, end), strftime(date_format, begin)))

		stock_info = self.__db.get_stock_info(symbol, begin, end)
		print stock_info
