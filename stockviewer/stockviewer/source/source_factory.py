import logging

from urlgetter import urlgetter

class getter_factory():
	def __init__(self, config):
		logging.debug('Getter factory init: config {}'.format(config))
		self.__config = config

	def create_getter(self, requested_name):
		for node in self.__config.iter('getter'):
			if requested_name == node.get('name'):
				return urlgetter(node)

		logging.warning("No '{}' getter found".format(requested_name))

		return None
