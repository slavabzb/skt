import re
import os

def configure_file(src, dst, **kwargs):
	content = None
	with open(src, 'r') as f:
		content = f.read()
	for k in kwargs:
		pattern = re.compile(k)
		content = pattern.sub(kwargs[k], content)
	with open(dst, 'w') as f:
		f.write(content)

def configure_dir(src, dst, rmpostfix='.in', recursively=True, **kwargs):
	if not os.path.isdir(dst):
		os.makedirs(dst)
	for path in os.listdir(src):
		realpath = os.path.realpath(os.path.realpath(os.path.join(src, path)))
		if os.path.isfile(realpath):
			configure_file(realpath, os.path.join(dst, path.replace(rmpostfix, '')), **kwargs)
		elif os.path.isdir(realpath):
			if recursively:
				configure_dir(realpath, os.path.join(dst, os.path.basename(realpath)), rmpostfix, recursively, **kwargs)
