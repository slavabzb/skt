try:
	from lxml import etree
except ImportError:
	try:
		import xml.etree.cElementTree as etree
	except ImportError:
		try:
			import xml.etree.ElementTree as etree
		except ImportError:
			try:
				import cElementTree as etree
			except ImportError:
				import elementtree.ElementTree as etree

def parse_config(fp):
	tree = etree.parse(fp)
	#print etree.tostring(tree.getroot(), pretty_print=True)
	root = tree.getroot()

	#r = root.find('xi:include', root.nsmap)
	#print r

	#tree.xinclude()
	tree.xinclude()
	
	return root
