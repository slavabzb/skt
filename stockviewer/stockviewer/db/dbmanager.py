import logging

from provider import provider_factory

class dbmanager():
	def __init__(self, config):
		self.__config = config
		
		factory = provider_factory(self.__config.find('provider_factory'))		
		self.__provider = factory.create_provider(self.__config.find('provider').text)

	def apply(self, sql_script):
		try:
			self.__provider.apply(sql_script)
		except Exception as e:
			logging.warning(e)
			raise e

	def execute(self, query):
		logging.info(query)
		try:
			return self.__provider.execute(query)
		except Exception as e:
			logging.warning(e)
			raise e
