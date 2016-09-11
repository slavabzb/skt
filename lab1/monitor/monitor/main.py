#!/usr/bin/env python

from argparse import ArgumentParser

import modules

def main(args):
    """Program entry point. The program starts here."""
    
    modules.system.system(args).start_session()


def parse_args():
    """Parse command line arguments."""
    
    # create a parser
    parser = ArgumentParser()
    parser.add_argument('--user', '-u', help='user login')
    parser.add_argument('--password', '-p', help='user password')

    # parse arguments
    return parser.parse_args()
    
if __name__ == '__main__':
    main(parse_args())
