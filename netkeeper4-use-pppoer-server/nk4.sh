#!/bin/sh
#启动pppoe服务器。TODO：检测是否有pppoe服务器进程，再启动
sleep 1
pppoe-server -k -I br-lan

#删掉之前的log，加快读取速度
rm /tmp/pppoe.log

while :
do
#读取log最后一个账号
    username=$(grep "network.wan.username" /tmp/pppoe.log  | tail -n 1 | cut -b 66-)

    if [ "$username" != "$username_old" ]
    then
        ifdown netkeeper
        uci set network.netkeeper.username="\r$username"
        uci set network.netkeeper.password="$(grep "network.wan.password" /tmp/pppoe.log  | tail -n 1 | cut -b 64-)"
        uci commit
        ifup netkeeper
        username_old="$username"
        echo "new username $username"
    fi
#    echo "wait"
    sleep 10

done
