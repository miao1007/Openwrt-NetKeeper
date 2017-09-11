#!/bin/sh

#start pppoe-server
if [ -n "$(ps | grep pppoe-server | grep -v grep)" ]
then
    killall pppoe-server
fi
pppoe-server -k -I br-lan

#clear logs
cat /dev/null > /tmp/pppoe.log

while :
do
    #read the last username in pppoe.log
    if [ "$(grep 'user=' /tmp/pppoe.log | grep 'rcvd' | tail -n 1 | cut -d \" -f 5)" == "]" ]
    then
        username=$(grep 'user=' /tmp/pppoe.log | grep 'rcvd' | tail -n 1 | cut -d \" -f 2)
    fi

    if [ "$username" != "$username_old" ]
    then
        ifdown netkeeper
        uci set network.netkeeper.username="$username"
        uci set network.netkeeper.password="$(grep 'user=' /tmp/pppoe.log | grep 'rcvd' | tail -n 1 | cut -d \" -f 4)"
        uci commit
        ifup netkeeper
        username_old="$username"
        logger -t nk4 "new username $username"
    fi
    
    sleep 10

    #close pppoe if log fail
    if [ -z "$(ifconfig | grep "netkeeper")" ]
    then
        ifdown netkeeper
    fi

done
