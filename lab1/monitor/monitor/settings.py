import os

# directories which are used in the project
dirs = {
    'database': os.path.realpath(os.path.join(os.path.abspath(os.path.dirname(__file__)), '..', 'database'))
}

# files which are used in the project
files = {
    'database': os.path.join(dirs['database'], 'database.json')
}

# make directories which do not exist
for name, path in dirs.iteritems():
    if not os.path.isdir(path):
        os.makedirs(path)

# create files which do not exist
for name, path in files.iteritems():
    if not os.path.isfile(path):
        with open(path, 'a'):
            os.utime(path, None)
