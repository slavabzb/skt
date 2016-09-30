import sqlite3

class sqlite_provider():
	def connect(self, path):
		return sqlite3.connect(path)
