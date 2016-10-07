import logging

from collections import namedtuple
from time import localtime, struct_time, mktime, time
from datetime import datetime
from utils import make_timedelta, make_fields

from source import source_factory

class viewmanager():
	def __init__(self, config):
		logging.debug('View manager init: config {}'.format(config))
		self.__config = config
		self.__date_input_format = self.__config.find('date_input_format').text
		self.__date_view_format = self.__config.find('date_view_format').text
		self.__fields = make_fields(self.__config.find('fields'))
		self.__sources = {}
		self.__onview_source = None
		self.__onmiss_source = None
		factory = source_factory(self.__config.find('source_factory'))
		for node in self.__config.find('sources').iter('source'):
			self.__sources.update({node.text: factory.create_source(node.text)})
			if node.get('using') == 'onview':
				self.__onview_source = node.text
			elif node.get('using') == 'onmiss':
				self.__onmiss_source = node.text

	def view(self, symbol, begin = None, end = None):
		logging.debug('View manager view: symbol `{symbol}`, begin `{begin}`, end `{end}`'.format(symbol=symbol, begin=begin, end=end))

		try:
			if begin:
				begin = datetime.strptime(begin, self.__date_input_format)

			if end:
				end = datetime.strptime(end, self.__date_input_format)
		except ValueError:
			raise Exception("Dates don't match the format `{}`".format(self.__date_input_format))

		stock_data = self.__sources[self.__onview_source].get(symbol, begin, end)
		dbegin, dend = self.__correct_dates(stock_data, begin, end)
		missed = self.__get_missed(stock_data, dbegin, dend)

		additional = []

		for item in missed:
			local = self.__sources[self.__onmiss_source].get(symbol, item[0], item[1])
			for data in local:
				additional.append(data)

		for data in additional:
			self.__sources[self.__onview_source].store(symbol, data)

		stock_data = self.__sources[self.__onview_source].get(symbol, begin, end)

		if stock_data:
			print "{date:<15}{open:<10}{high:<10}{low:<10}{close:<10}{volume:<10}".format(**self.__fields)

		for data in stock_data:
			data["Date"] = datetime.strftime(data["Date"], self.__date_view_format)
			print "{Date:<15}{Open:<10}{High:<10}{Low:<10}{Close:<10}{Volume:<10}".format(**data)

	def __get_missed(self, stock_data, dbegin, dend):
		missed = []

		index = 0
		timestep = make_timedelta(self.__config.find('date_step'))
		ibegin = dbegin
		iend = ibegin + timestep
		while iend < dend:
			tend = dend

			if index < len(stock_data):
				tend = stock_data[index]['Date']
				index += 1

			while iend < tend:
				iend += timestep

			if abs(iend - ibegin) >= timestep:
				missed.append((ibegin, iend))
				ibegin = iend + timestep

		return missed

	def __correct_dates(self, stock_data, begin, end):
		dbegin = begin
		if not dbegin:
			if stock_data:
				dbegin = stock_data[0]['Date']
			else:
				dbegin = datetime.today()

		dend = end
		if not dend:
			if stock_data:
				dend = stock_data[-1]['Date']
			else:
				dend = datetime.today() + make_timedelta(self.__config.find('default_view_window'))
				dend = dend.timetuple()

		if dend <= dbegin:
			raise Exception('The end `{}` of the period is less or equal to begin `{}`'.format(datetime.strftime(dend, self.__date_view_format), datetime.strftime(dbegin, self.__date_view_format)))

		logging.debug('View window is {} - {}'.format(datetime.strftime(dbegin, self.__date_input_format), datetime.strftime(dend, self.__date_input_format)))

		return dbegin, dend
