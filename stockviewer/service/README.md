# Сервис

Установка:

1. cp service.nginx /etc/nginx/sites-available/
2. ln -s /etc/nginx/sites-available/service.nginx /etc/nginx/sites-enabled/service.nginx
3. cp service.ini /etc/uwsgi/apps-available/
4. ln -s /etc/uwsgi/apps-available/service.ini /etc/uwsgi/apps-enabled/service.ini
5. service nginx reload
6. service uwsgi restart
