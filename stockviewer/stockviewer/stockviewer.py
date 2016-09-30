import settings

from argparse import ArgumentParser

from utils import parse_config
from utils import loginit

from service import service

def parse_args():
	parser = ArgumentParser()

	return parser.parse_args()

def main(args, config):
	loginit(config.find('logger'))

	with service(args, config.find('service')) as s:
		s.start()

if __name__ == '__main__':
    main(parse_args(), parse_config(settings.files['config']))
