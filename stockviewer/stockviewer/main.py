import logging
import settings

from utils import parse_args, parse_config, loginit

def main(args, config):
	try:
		loginit(config.find('logger'))
		args.func(args, config)
	except Exception as e:
		logging.critical(e)

if __name__ == '__main__':
	main(parse_args(), parse_config(settings.files['config']))
