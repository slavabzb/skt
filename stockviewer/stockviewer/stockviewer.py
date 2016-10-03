import logging
import settings

from utils import parse_args, parse_config, loginit

def main(args, config):
	loginit(config.find('logger'))

	try:
		args.func(args, config)
	except Exception as e:
		logging.exception(e)

if __name__ == '__main__':
	main(parse_args(), parse_config(settings.files['config']))
