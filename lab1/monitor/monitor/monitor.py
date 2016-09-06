#!/usr/bin/env python

from argparse import ArgumentParser

import modules
import settings

def main(args):
    """Program entry point. The program starts here."""
    
    # call the handler depending on arguments
    args.func(args)

def parse_args():
    """Parse command line arguments."""
    
    # create a top-level parser
    parser = ArgumentParser()

    # create subparsers to split functionality
    subparsers = parser.add_subparsers(title='subcommands')
    
    # working with users
    user_commands = subparsers.add_parser('user', help='working with users')
    user_commands.add_argument('--show', help='show registered users', action='store_true')
    user_commands.set_defaults(func=modules.user.main)
    
    # system commands
    system_commands = subparsers.add_parser('system', help='system commands')
    system_commands.add_argument('--login', help='login into the system', action='store_true')
    system_commands.set_defaults(func=modules.system.main)
    
    # return parsed arguments
    return parser.parse_args()
    
if __name__ == '__main__':
    main(parse_args())
