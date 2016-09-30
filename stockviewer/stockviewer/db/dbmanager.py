from provider import provider_factory

class dbmanager():
	def __init__(self, config):
		self.__config = config
		
		factory = provider_factory(self.__config.find('provider_factory'))
		
		self.__dbprovider = factory.create_provider(self.__config.find('dbprovider').text)

	def apply(self, fp):
		self.__dbprovider.connect()
