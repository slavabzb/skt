import os

__name__ = 'monitor'
__version__ = '0.1.0'

# default system user
default_user = {
    'user': 'admin',
    'password': 'password',
    'group': 'admin'
}

# directories that are used in the project
dirs = {
    'database': os.path.realpath(os.path.join(os.path.abspath(os.path.dirname(__file__)), '..', 'database'))
}

# files that are used in the project
files = {
    'database': os.path.join(dirs['database'], 'database.csv')
}

# make directories that do not exist
for name, path in dirs.iteritems():
    if not os.path.isdir(path):
        os.makedirs(path)

# create files that do not exist
for name, path in files.iteritems():
    if not os.path.isfile(path):
        with open(path, 'ab') as f:
            os.utime(path, None)
            if path == files['database']:
                f.write('admin,123\n')
