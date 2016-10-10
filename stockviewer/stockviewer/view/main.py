import stockviewer.view

def main(args, config):
	vm = stockviewer.view.viewmanager(config.find('viewmanager'))
	vm.view(args.symbol, args.begin, args.end)
