import csv
import settings

from modules import user

class system():
    def __init__(self):
        self._database_changed = False
        self._user_list = []
        
        # load the database
        with open(settings.files['database'], 'rb') as databasefile:
            reader = csv.reader(databasefile)
            for row in reader:
                login = row[0]
                password = row[1]
                self._user_list.append(user(login, password))
                
    
    def start_session(self):
        pass
