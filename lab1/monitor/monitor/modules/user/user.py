class user():
    """Represents a user."""
    
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
            raise Exception('Invalid user: login %(login)s, password %(password)s, group %(group)s' % {
                'login': self._login,
                'password': self._password,
                'group': self._group
            })

    def login(self):
        return self._login

    def group(self):
        return self._group
    
    def password(self):
        return self._password
