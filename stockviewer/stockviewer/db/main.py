from dbmanager import dbmanager

def main(args, config):
	db = dbmanager(config.find('dbmanager'))

	if args.make_migration:
		db.make_migration()
