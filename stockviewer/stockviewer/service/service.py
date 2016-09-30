import logging

class service():
	def __init__(self, args, config):
		self.__args = args
		self.__config = config

	def __enter__(self):
		return self

	def __exit__(self, type, value, traceback):
		self.stop()
		if value:
			logging.exception(value)
		return self

	def start(self):
		logging.info('Service started')

	def stop(self):
		logging.info('Service stopped')
