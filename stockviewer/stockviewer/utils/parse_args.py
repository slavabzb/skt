from argparse import ArgumentParser

from db import main as dbmain
from view import main as viewmain

def parse_args():
	parser = ArgumentParser()

	subparsers = parser.add_subparsers()

	database_parser = subparsers.add_parser('database', help='database commands')
	database_parser.add_argument('--make-migration', '-m', help='apply migration', action='store_true')
	database_parser.set_defaults(func=dbmain)

	view_parser = subparsers.add_parser('view', help='stock view commands')
	view_parser.add_argument('symbol', help='stock symbol')
	view_parser.add_argument('begin', help='begin of the period')
	view_parser.add_argument('end', help='end of the period')
	view_parser.set_defaults(func=viewmain)

	return parser.parse_args()
