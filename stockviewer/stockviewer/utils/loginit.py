import logging

def loginit(config):
	if config is not None:
		logger = logging.getLogger('')
		logger.setLevel(logging.NOTSET)

		for sink in config.iter('sink'):
			handler = logging.StreamHandler()

			node = sink.find('filename')
			if node is not None:
				handler = logging.FileHandler(node.text)

			node = sink.find('level')
			if node is not None:
				level = getattr(logging, node.text.upper())
				if isinstance(level, int):
					handler.setLevel(level)

			node = sink.find('format')
			if node is not None:
				fmt = node.text
				datefmt = None
				node = sink.find('dateformat')
				if node is not None:
					datefmt = node.text
				formatter = logging.Formatter(fmt, datefmt)
				handler.setFormatter(formatter)

			logger.addHandler(handler)
