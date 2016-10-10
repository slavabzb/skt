import logging
import csv

from urllib2 import urlopen, quote
from datetime import datetime

from stockviewer.utils import make_timedelta, make_fields

class websource():
	def __init__(self, config):
		logging.debug('Web source init: config {}'.format(config))
		self.__config = config
		self.__url = self.__config.find('url').text
		self.__date_request_format = self.__config.find('date_request_format').text
		self.__date_output_format = self.__config.find('date_output_format').text
		self.__fields = make_fields(self.__config.find('fields'))

	def get(self, symbol, begin = None, end = None):
		if not begin:
			begin = datetime.today()

		if not end:
			end = begin + make_timedelta(self.__config.find('default_view_window'))
		
		url = self.__url.format(symbol=quote(symbol), begin=quote(datetime.strftime(begin, self.__date_request_format)), end=quote(datetime.strftime(end, self.__date_request_format)))
		logging.info('Opening url `{}`'.format(url))

		response = []

		try:
			response = urlopen(url)
		except Exception as e:
			logging.warning(e)

		reader = csv.reader(response)

		stock_info = []

		first = True
		for row in reader:
			if first:
				first = False
				continue

			info = {
				self.__fields['date']: datetime.strptime(row[0], self.__date_output_format),
				self.__fields['open']: float(row[1]),
				self.__fields['high']: float(row[2]),
				self.__fields['low']: float(row[3]),
				self.__fields['close']: float(row[4]),
				self.__fields['volume']: int(row[5]),
			}

			stock_info.append(info)

		return stock_info
