from provider import provider_factory

class dbmanager():
	def __init__(self, config):
		self.__config = config
		self.__provider_factory = provider_factory(config.find('provider_factory'))

	def apply(self, fp):
		pass
