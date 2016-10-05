from view import viewmanager

def main(args, config):
	vm = viewmanager(config.find('viewmanager'))
	vm.view(args.symbol, args.begin, args.end)
