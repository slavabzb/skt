import logging

from urllib2 import urlopen

class urlgetter():
	def __init__(self, config):
		logging.debug('Url getter init: config {}'.format(config))
		self.__config = config
		self.__url = self.__config.find('url').text

	def get(self, **kw):
		url = self.__url.format(**kw)
		logging.info('Opening url `{}`'.format(url))
		response = urlopen(url)
