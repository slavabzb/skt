from setuptools import setup, find_packages
from monitor import settings

setup (
       name=settings.__name__,
       version=settings.__version__,
       packages=find_packages(),

       author='Vyacheslav Bezbordov',
       author_email='vyacheslav.bezborodov@gmail.com',
  
       )