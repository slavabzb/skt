from sqlite_provider import sqlite_provider

class provider_factory():
	def __init__(self, config):
		self.__config = config
	
	def create_provider(name):
		if name == 'sqlite':
			return sqlite_provider()

		return None
