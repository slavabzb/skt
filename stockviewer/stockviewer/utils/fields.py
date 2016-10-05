def make_fields(config):
	fields = {}
	for node in config:
		fields.update({node.get('alias'): node.text})
	return fields
