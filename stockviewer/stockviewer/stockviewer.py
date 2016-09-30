import settings

from service import service
from utils import parse_args, parse_config, loginit

def main(args, config):
	loginit(config.find('logger'))

	with service(args, config.find('service')) as s:
		s.start()

if __name__ == '__main__':
	main(parse_args(), parse_config(settings.files['config']))
