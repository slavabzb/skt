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

    def login(self):
        return self._login
    
    def group(self):
        return self._group
    
    def password(self):
        return self._password
    
    def set_password(self, password):
        self._password = password
