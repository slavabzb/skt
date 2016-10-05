import logging

from dbsource import dbsource
from websource import websource

class source_factory():
	def __init__(self, config):
		logging.debug('Source factory init: config {}'.format(config))
		self.__config = config

	def create_source(self, requested_name):
		node = self.__config.find("./source[@name='{}']".format(requested_name))

		if requested_name == 'database':
			return dbsource(node)
		elif requested_name == 'web':
			return websource(node)

		logging.warning("No '{}' source found".format(requested_name))

		return None
