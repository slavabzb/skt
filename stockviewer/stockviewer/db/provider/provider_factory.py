import logging

from sqlite_provider import sqlite_provider

class provider_factory():
	def __init__(self, config):
		self.__config = config
	
	def create_provider(self, requested_name):
		for provider_node in self.__config.find('providers'):
			if requested_name == provider_node.get('name'):
				return sqlite_provider(provider_node)

		logging.warning("No '{}' provider found".format(requested_name))
		
		return None
