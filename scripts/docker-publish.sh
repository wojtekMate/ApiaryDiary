#!/bin/bash
pass=$haslo
Ip=46.101.251.246
echo "$pass"
echo root@"$Ip"
sshpass -p "$pass"  ssh root@"$Ip" 'docker-compose up'
echo wykonano
echo $Ip
