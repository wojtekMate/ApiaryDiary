#!/bin/bash
echo Deploy application on branch $TRAVIS_BRANCH to server:
sshpass -p $ApiaryDiaryIPPassword ssh -o 'StrictHostKeyChecking=no' root@$ApiaryDiaryIPAddress "docker-compose up -d"
