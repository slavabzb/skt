import getpass
import csv
import settings

class user():
    def __init__(self, **kwargs):
        """Constructor."""
        
        self._login = None
        self._password = None
        self._group = None

        if 'user' in kwargs:
            self._login = kwargs['user']
        
        if 'password' in kwargs:
            self._password = kwargs['password']
        
        if 'group' in kwargs:
            self._group = kwargs['group']
        
        if not (self._login and self._password and self._group):
            raise Exception('Invalid user %(login)s %(password)s %(group)s' % {
                'login': self._login,
                'password': self._password,
                'group': self._group
            })
    
    def __str__(self):
        return str(self._login)

    def __eq__(self, other):
        return self._login == other._login and self._password == other._password

    def login(self):
        return self._login

    def group(self):
        return self._group
    
    def password(self):
        return self._password
