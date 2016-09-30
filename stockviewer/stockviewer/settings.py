import os

from utils import configure_dir

__anchor = os.path.dirname(__file__)

dirs = {
	'config.in': os.path.realpath(os.path.join(__anchor, '..', 'config.in')),
	'config': os.path.realpath(os.path.join(__anchor, '..', 'config')),
	'log': os.path.realpath(os.path.join(__anchor, '..', 'log')),
	'migration': os.path.realpath(os.path.join(__anchor, '..', 'migration')),
	'db': os.path.realpath(os.path.join(__anchor, '..', 'db')),
}

files = {
	'config': os.path.join(dirs['config'], 'main.xml'),
}

try:
	import settings_local
except ImportError:
	pass

for alias in dirs:
    dirname = dirs[alias]
    if not os.path.isdir(dirname):
        os.makedirs(dirname)

mapper = {
	'@LOG': dirs['log'],
	'@CONFIG': dirs['config'],
	'@DATABASE': os.path.join(dirs['db'], 'stockviewer.db'),
}

configure_dir(dirs['config.in'], dirs['config'], **mapper)
