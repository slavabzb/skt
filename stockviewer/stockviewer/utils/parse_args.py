from argparse import ArgumentParser

def parse_args():
	parser = ArgumentParser()

	parser.add_argument('--make-migration', help='apply next migration', action='store_true')

	return parser.parse_args()
