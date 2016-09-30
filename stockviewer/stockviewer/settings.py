import os

from utils import configure_dir

__anchor = os.path.dirname(__file__)

dirs = {
	'config.in': os.path.realpath(os.path.join(__anchor, '..', 'config.in')),
	'config': os.path.realpath(os.path.join(__anchor, '..', 'config')),
	'log': os.path.realpath(os.path.join(__anchor, '..', 'log')),
}

files = {
	'config': os.path.join(dirs['config'], 'main.xml'),
}

mapper = {
	'@LOG_DIR': dirs['log']
}

configure_dir(dirs['config.in'], dirs['config'], **mapper)

try:
	import settings_local
except ImportError:
	pass
