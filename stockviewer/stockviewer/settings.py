import os

from utils import configure_dir

__anchor = os.path.dirname(__file__)

dirs = {
	'config.in': os.path.realpath(os.path.join(__anchor, '..', 'config.in')),
	'config': os.path.realpath(os.path.join(__anchor, '..', 'config')),
	'log': os.path.realpath(os.path.join(__anchor, '..', 'log')),
	'migration': os.path.realpath(os.path.join(__anchor, '..', 'migration')),
}

files = {
	'config': os.path.join(dirs['config'], 'main.xml'),
}

mapper = {
	'@LOG': dirs['log'],
	'@CONFIG': dirs['config'],
}

try:
	import settings_local
except ImportError:
	pass

configure_dir(dirs['config.in'], dirs['config'], **mapper)
