import logging

from collections import namedtuple
from time import localtime, struct_time, mktime, time
from datetime import datetime, timedelta
from db import dbmanager
from getter import getter

class viewmanager():
	def __init__(self, config):
		logging.debug('View manager init: config {}'.format(config))
		self.__config = config
		self.__db = dbmanager(self.__config.find('dbmanager'))
		self.__getter = getter(self.__config.find('getter'))
		self.__date_input_format = self.__config.find('date_input_format').text
		self.__date_view_format = self.__config.find('date_view_format').text

	def close(self):
		logging.debug('View manager close')
		self.__db.close()

	def view(self, symbol, begin = None, end = None):
		logging.debug('View manager view: symbol `{symbol}`, begin `{begin}`, end `{end}`'.format(symbol=symbol, begin=begin, end=end))

		try:
			if begin:
				begin = datetime.strptime(begin, self.__date_input_format)

			if end:
				end = datetime.strptime(end, self.__date_input_format)
		except ValueError:
			raise Exception("Dates don't match the format `{}`".format(self.__date_input_format))

		stock_info = self.__db.get_stock_info(symbol, begin, end)
		dbegin, dend = self.__correct_dates(stock_info, begin, end)
		missed = self.__get_missed(stock_info, dbegin, dend)

		print 'database'
		for item in stock_info:
			print datetime.strftime(item['Date'], self.__date_input_format)

		print 'missed'
		for item in missed:
			print datetime.strftime(item[0], self.__date_input_format), datetime.strftime(item[1], self.__date_input_format)

	def __get_missed(self, stock_info, dbegin, dend):
		missed = []

		index = 0
		timestep = self.__make_timedelta('date_step')
		ibegin = dbegin
		iend = ibegin + timestep
		while iend < dend:
			tend = dend

			if index < len(stock_info):
				tend = stock_info[index]['Date']
				index += 1

			while iend < tend:
				iend += timestep

			if abs(iend - ibegin) >= timestep:
				missed.append((ibegin, iend))
				ibegin = iend + timestep

		return missed

	def __correct_dates(self, stock_info, begin, end):
		dbegin = begin
		if not dbegin:
			if stock_info:
				dbegin = stock_info[0]['Date']
			else:
				dbegin = datetime.today()

		dend = end
		if not dend:
			if stock_info:
				dend = stock_info[-1]['Date']
			else:
				dend = datetime.today() + self.__make_timedelta('default_view_window')
				dend = dend.timetuple()

		if dend <= dbegin:
			raise Exception('The end `{}` of the period is less or equal to begin `{}`'.format(datetime.strftime(dend, self.__date_view_format), datetime.strftime(dbegin, self.__date_view_format)))

		logging.debug('View period is {} - {}'.format(datetime.strftime(dbegin, self.__date_input_format), datetime.strftime(dend, self.__date_input_format)))

		return dbegin, dend

	def __make_timedelta(self, path):
		delta = {}

		for node in self.__config.find(path):
			delta.update({node.tag: int(node.text)})

		return timedelta(**delta)
