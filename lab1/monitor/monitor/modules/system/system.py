import csv
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
        
        self._user = None #modules.user.user(group='guest', **vars(self._args))
        self._user_logged = False
        self._user_list = []
        
        self._cmd = ''
        self._cmds = [
            {
                'names': ['help', 'h'],
                'help': 'Print this help.',
                'callback': functools.partial(system._print_help, self)
            },
            {
                'names': ['exit', 'quit', 'q'],
                'help': 'Exit the program.',
                'callback': functools.partial(system.stop_session, self)
            },
            {
                'names': ['user-show-list', 'usl'],
                'help': 'Show all the registered users.',
                'groups': ['admin'],
                'callback': functools.partial(system._user_show_list, self)
            },
            {
                'names': ['user-register', 'ur'],
                'help': 'Add a new user to database.',
                'groups': ['admin'],
                'callback': functools.partial(system._user_register, self)
            }
        ]
        
        self._load_database(settings.files['database'])
    
    def _poll_command(self):
        """Get next command."""
                
        prompt = '[%(user)s]> ' % {
            'user': self._user  
        }
        
        self._cmd = raw_input(prompt)

    def _process_command(self):
        """Process current command."""
        
        try:
            for cmd in self._cmds:
                if self._cmd in cmd['names']:
                    self._check_access(cmd)
                    cmd['callback']()
                    return
        except Exception as e:
            print(e)
            return
        
        print('Unknown command \'%(command)s\'' % {
            'command': self._cmd
        })
    
    def _check_access(self, cmd):
        """Check if user's group allowed for command."""
        
        if 'groups' in cmd:
            if not self._user or self._user.group() not in cmd['groups']:
                raise SystemError('Access denied')
    
    def _print_help(self):
        """Print out available commands list."""
        
        for cmd in self._cmds:
            print('\t%(name)-20s%(help)s' % {
                'name': ', '.join(cmd['names']),
                'help': cmd['help']
            })
    
    def _user_show_list(self):
        """Print out all the registered users."""
        
        for user in self._user_list:
            print(user)
    
    def _user_register(self):
        """Create a new account."""
        
        # get a new user info
        login = raw_input('User login: ')
        pass0 = getpass.getpass('User password: ')

        if not pass0:
            print('Empty password')
            return

        pass1 = getpass.getpass('Confirm user password: ')

        if pass0 != pass1:
            print('Password is not confirmed')
            return
        
        group = raw_input('User group: ')
        
        self._user_list.append(modules.user.user(**{
            'user': login,
            'password': pass0,
            'group': group
        }))
        
        self._database_changed = True
    
    def start_session(self):
        """Start system loop."""
        
        self._running = True
        print(self._welcome)
        while self._running:
            self._poll_command()
            self._process_command()

    def stop_session(self):
        """Flush database and cleanup."""
        
        self._running = False
        
        # write to database
        if self._database_changed:
            with open(settings.files['database'], 'ab') as databasefile:
                writer = csv.writer(databasefile, quoting=csv.QUOTE_MINIMAL)
                for user in self._user_list:
                    writer.writerow([user.login(), user.password(), user.group()])

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
