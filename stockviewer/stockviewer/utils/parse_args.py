from argparse import ArgumentParser

from stockviewer.db import main as dbmain
from stockviewer.view import main as viewmain

def parse_args():
	parser = ArgumentParser()

	subparsers = parser.add_subparsers()

	database_parser = subparsers.add_parser('database', help='database commands')
	database_parser.add_argument('--make-migration', '-m', help='apply migration', action='store_true')
	database_parser.set_defaults(func=dbmain)

	view_parser = subparsers.add_parser('view', help='stock view commands')
	view_parser.add_argument('symbol', help='stock symbol')
	view_parser.add_argument('--begin', '-b', help='begin of the period')
	view_parser.add_argument('--end', '-e', help='end of the period')

	view_source_group = view_parser.add_argument_group('source', 'view source settings')
	view_source_group.add_argument('--onview-source', '-vs', default='database', help='source used for data viewing (default: database)')
	view_source_group.add_argument('--onmiss-source', '-ms', default='web', help='source used if search is incomplete (default: web)')

	view_parser.set_defaults(func=viewmain)

	return parser.parse_args()
