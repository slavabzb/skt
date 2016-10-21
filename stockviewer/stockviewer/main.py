import sys, os
sys.path.insert(0, os.path.realpath(os.path.join(os.path.abspath(os.path.dirname(__file__)), '..')))

import logging
import settings

from utils import parse_args, parse_config, loginit

def main(args, config):
	try:
		loginit(config.find('logger'))
		args.func(args, config)
	except Exception as e:
		logging.exception(e)

if __name__ == '__main__':
	main(parse_args(), parse_config(settings.files['config']))
