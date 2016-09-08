import getpass
import csv
import settings

class user():
    def __init__(self, login, password):
        """Constructor."""
        
        self._login = login
        self._password = password

    def show_list(self):
        """Print all the registered users."""


    def register(self):
        """Signup user to the system."""

        # get a new user info
        login = raw_input('Enter login: ')
        pass0 = getpass.getpass('Enter password: ')

        if not pass0:
            print('Empty password')
            return

        pass1 = getpass.getpass('Confirm password: ')

        if pass0 != pass1:
            print('Password is not confirmed')
            return

        # write to database
        with open(settings.files['database'], 'ab') as databasefile:
            writer = csv.writer(databasefile, quoting=csv.QUOTE_MINIMAL)
            writer.writerow([login, pass0])

    def login(self):
        """Signin user into the system."""

        if not self._data.user:
            self._data.user = raw_input('Login: ')
        if not self._data.password:
            self._data.password = getpass.getpass('Password: ')

        # open up the database
        with open(settings.files['database'], 'rb') as databasefile:
            reader = csv.reader(databasefile)
            for row in reader:
                if row[0] == self._data.user and row[1] == self._data.password:
                    self._logged = True

        self._logged = False

    def is_logged(self):
        return self._logged
