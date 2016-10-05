from datetime import timedelta

def make_timedelta(config):
	delta = {}

	for node in config:
		delta.update({node.tag: int(node.text)})

	return timedelta(**delta)
