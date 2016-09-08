import getpass
import csv
import settings

def user_show_list(args):
    print('Registered users')

def user_register(args):
    """Add a new user to database."""
    
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
    with open(settings.files['database'], 'wb') as databasefile:
        writer = csv.writer(databasefile, quoting=csv.QUOTE_MINIMAL)
        writer.writerow([login, pass0])

def main(args):
    if args.show:
        user_show_list(args)
    elif args.register:
        user_register(args)
