#!/bin/bash
pass=$haslo
Ip=46.101.251.246
echo root@"$Ip"
sshpass -p $pass  ssh root@$Ip 'docker-compose up'
echo end
