import logging

from getter_factory import getter_factory

class getter():
	def __init__(self, config):
		logging.debug('Getter init: config {}'.format(config))
		self.__config = config
		self.__getters = []
		factory = getter_factory(self.__config.find('getter_factory'))
		for node in self.__config.find('getters'):
			self.__getters.append(factory.create_getter(node.text))

	def get(self, symbol, begin, end):
		data = []
		for getter in self.__getters:
			data += getter.get(symbol, begin, end)
		return data
