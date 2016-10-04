import logging

from collections import namedtuple
from time import strptime, strftime, localtime, struct_time, mktime, time
from datetime import date, timedelta
from db import dbmanager

class viewmanager():
	def __init__(self, config):
		logging.debug('View manager init: config {}'.format(config))
		self.__config = config
		self.__db = dbmanager(self.__config.find('dbmanager'))
		self.__date_input_format = self.__config.find('date_input_format').text
		self.__date_view_format = self.__config.find('date_view_format').text

	def close(self):
		logging.debug('View manager close')
		self.__db.close()

	def view(self, symbol, begin = None, end = None):
		logging.debug('View manager view: symbol `{symbol}`, begin `{begin}`, end `{end}`'.format(symbol=symbol, begin=begin, end=end))

		try:
			if begin:
				begin = strptime(begin, self.__date_input_format)

			if end:
				end = strptime(end, self.__date_input_format)
		except ValueError:
			raise Exception("Dates don't match the format `{}`".format(self.__date_input_format))

		stock_info = self.__db.get_stock_info(symbol, begin, end)

		mindate = None
		maxdate = None

		dbegin = begin
		if dbegin:
			if stock_info:
				mindate = stock_info[0]['Date']
		else:
			if stock_info:
				dbegin = stock_info[0]['Date']
				mindate = dbegin
			else:
				dbegin = localtime()

		logging.debug('View period begin {}'.format(strftime(self.__date_input_format, dbegin)))

		dend = end
		if dend:
			if stock_info:
				maxdate = stock_info[-1]['Date']
		else:
			if stock_info:
				dend = stock_info[-1]['Date']
				maxdate = dend
			else:
				dend = date.today() + self.__make_timedelta('date_default_window')
				dend = dend.timetuple()

		if dend <= dbegin:
			raise Exception('The end `{}` of the period is less or equal to begin `{}`'.format(strftime(self.__date_view_format, dend), strftime(self.__date_view_format, dbegin)))

		logging.debug('View period end {}'.format(strftime(self.__date_input_format, dend)))

		if mindate and maxdate:
			logging.debug('Matching period is [{}; {}]'.format(strftime(self.__date_input_format, mindate), strftime(self.__date_input_format, maxdate)))
		else:
			logging.debug('No matching period found')

		missed = []

		itime = dbegin
		timestep = self.__make_timedelta('date_step')
		while itime <= dend:
			if stock_info:
				if not (itime >= mindate and itime <= maxdate):
					missed.append(itime)
			else:
				missed.append(itime)

			step = date.fromtimestamp(mktime(itime)) + timestep
			itime = step.timetuple()

		print 'Missed'
		for tmp in missed:
			print tmp

		for row in stock_info:
			print strftime(self.__date_view_format, row['Date']), row

	def __make_timedelta(self, path):
		delta = {}

		for node in self.__config.find(path):
			delta.update({node.tag: int(node.text)})

		return timedelta(**delta)
