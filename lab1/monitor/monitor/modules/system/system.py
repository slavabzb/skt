import csv
import getpass
import hashlib
import functools
import settings
import modules

class system():
    """Represents a huge megasystem."""
    
    def __init__(self, args):
        """Constructor."""
        
        self._args = args
        self._database_changed = False
        self._running = False
        
        self._welcome = """
            Welcome to %(package)s v%(version)s.
            Type "help" for more information.
        """ % {
            'package': settings.__name__,
            'version': settings.__version__
        }
        
        self._user = None
        self._user_list = []
        
        self._cmd = ''
        self._cmds = [
            {
                'names': ['help', 'h'],
                'help': 'Print this help.',
                'callback': functools.partial(system._help_print, self)
            },
            {
                'names': ['exit', 'quit', 'q'],
                'help': 'Exit the program.',
                'callback': functools.partial(system.stop_session, self)
            },
            {
                'names': ['user-login', 'in'],
                'help': 'Login into the system.',
                'callback': functools.partial(system._user_login, self)
            },
            {
                'names': ['user-logout', 'out'],
                'help': 'Logout from the system.',
                'callback': functools.partial(system._user_logout, self)
            },
            {
                'names': ['user-register', 'mku'],
                'help': 'Add a new user to database.',
                'groups': ['admin'],
                'callback': functools.partial(system._user_register, self)
            },
            {
                'names': ['user-remove', 'rmu'],
                'help': 'Remove a new user from database.',
                'groups': ['admin'],
                'callback': functools.partial(system._user_remove, self)
            },
            {
                'names': ['user-change-password', 'chu'],
                'help': 'Remove a new user from database.',
                'groups': ['admin', 'user'],
                'callback': functools.partial(system._user_change_password, self)
            },
            {
                'names': ['user-show-list', 'lsu'],
                'help': 'Show all the registered users.',
                'groups': ['admin', 'user'],
                'callback': functools.partial(system._user_show_list, self)
            }
        ]
        
        self._load_database(settings.files['database'])
    
    def start_session(self):
        """Start system loop."""

        if self._args.user and self._args.password:
            self._user_login(self._args.user, self._args.password)
        
        print(self._welcome)
        
        self._check_no_users_condition()
        
        self._running = True
        while self._running:
            self._poll_command()
            self._process_command()

    def stop_session(self):
        """Flush database and cleanup."""
        
        self._running = False
        
        if self._database_changed:
            self._store_database(settings.files['database'])

    def _load_database(self, path):
        """Load a database."""
        
        self._user_list = []
        
        with open(path, 'rb') as databasefile:
            reader = csv.reader(databasefile)
            for row in reader:
                self._user_list.append(modules.user.user(**{
                    'user': row[0],
                    'password': row[1],
                    'group': row[2]
                }))
        
        self._database_changed = False

    def _store_database(self, path):
        """Save database into a file."""
        
        with open(path, 'wb') as databasefile:
            writer = csv.writer(databasefile, quoting=csv.QUOTE_MINIMAL)
            for user in self._user_list:
                writer.writerow([user.login(), user.password(), user.group()])
        
        self._database_changed = False
    
    def _check_no_users_condition(self):
        if not self._user_list:
            self._user_list.append(modules.user.user(**{
                'user': settings.default_user['user'],
                'password': self._user_get_hash(settings.default_user['user'], settings.default_user['password'], settings.default_user['group']),
                'group': settings.default_user['group']
            }))
            
            self._database_changed = True
            
            print("""
                It seems to be a first starting of the system.
                You can use login `%(login)s` and password `%(password)s`
                to login into the system.
                
                Change your default credentials for security reasons!
            """ % {
                'login': settings.default_user['user'],
                'password': settings.default_user['password']
            })
    
    def _poll_command(self):
        """Get next command."""

        prompt = '[%(user)s]> ' % {
            'user': self._user.login() if self._user else self._user
        }
        
        self._cmd = raw_input(prompt).strip()

    def _process_command(self):
        """Process current command."""
        
        try:
            if self._cmd:
                for cmd in self._cmds:
                    if self._cmd in cmd['names']:
                        self._check_access(cmd)
                        cmd['callback']()
                        return
                raise Exception('Unknown command \'%(command)s\'' % {
                    'command': self._cmd
                })
        except Exception as e:
            print(e)
    
    def _check_access(self, cmd):
        """Check if user's group allowed for command."""
        
        if 'groups' in cmd:
            if not self._user or self._user.group() not in cmd['groups']:
                raise SystemError('Access denied')
    
    def _help_print(self):
        """Print out available commands list."""
        
        for cmd in self._cmds:
            print('\t%(name)-30s%(help)s' % {
                'name': ', '.join(cmd['names']),
                'help': cmd['help']
            })
    
    def _user_get_hash(self, login, password, group):
        return hashlib.sha256(login + password + group).hexdigest()
    
    def _user_change_password(self):
        oldpass = self._user_get_password('User current password: ')
        userhash = self._user_get_hash(self._user.login(), oldpass, self._user.group())
        
        if self._user.password() != userhash:
            self._user_logout()
            raise Exception('Invalid password')
        
        newpass = self._user_get_password('Enter a new password: ')
        
        if not newpass:
            raise Exception('Invalid password')
        
        self._user.set_password(self._user_get_hash(self._user.login(), newpass, self._user.group()))
                
        for user in self._user_list:
            if user.login() == self._user.login() and user.password() == userhash and user.group() == self._user.group():
                self._user_list.remove(user)
                self._user_list.append(self._user)
                break
        
        self._user_logout()
        self._database_changed = True
        
        print('Password successfully changed. Signin into the system.')
    
    def _user_show_list(self):
        """Print out all the registered users."""
        
        for user in self._user_list:
            print('\t%(user)s' % {
                'user': user.login()
            })
    
    def _user_get_login(self):
        return raw_input('User login: ')
    
    def _user_get_password(self, prompt = 'User password: '):
        return getpass.getpass(prompt)
    
    def _user_register(self):
        """Create a new account."""
        
        login = self._user_get_login()
        if not login:
            raise Exception('Empty login')
        
        password = self._user_get_password()

        if password != self._user_get_password('Confirm user password: '):
            raise Exception('Password is not confirmed')
        
        group = raw_input('User group: ')
        if not group:
            raise Exception('Invalid group')
        
        for user in self._user_list:
            userhash = self._user_get_hash(user.login(), password, user.group())
            if login == user.login() and userhash == user.password() and group == user.group():
                raise Exception('User already exists')
        
        self._user_list.append(modules.user.user(**{
            'user': login,
            'password': self._user_get_hash(login, password, group),
            'group': group
        }))
        
        self._database_changed = True

    def _user_remove_confirm(self, user, login):
        if user.login() != login:
            return False

        prompt = 'Remove user %(login)s from group \'%(group)s\'? y/[N] ' % {
            'login': user.login(),
            'group': user.group()
        }

        if 'y' == raw_input(prompt).strip().lower():
            self._database_changed = True
            return True
        
        return False

    def _user_remove(self):
        """Remove a user from database."""
        
        login = self._user_get_login()
        self._user_list = [user for user in self._user_list if not self._user_remove_confirm(user, login)]

    def _user_login(self, login = None, password = None):
        """Signin into the system."""
        
        if not login:
            login = self._user_get_login()
        
        if not password:
            password = self._user_get_password()
                
        for user in self._user_list:
            if user.login() == login:
                userhash = self._user_get_hash(user.login(), password, user.group())
                if user.password() == userhash:
                    self._user = modules.user.user(user=login, password=userhash, group=user.group())
                    break

        if not self._user:
            raise Exception('Invalid login/password')

    def _user_logout(self):
        """Logout from the system."""
        
        self._user = None
