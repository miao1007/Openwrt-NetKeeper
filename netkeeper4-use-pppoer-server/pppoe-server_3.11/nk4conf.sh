#!/bin/sh
#测试版本4.7.9.589，@cqupt

#安装pppoe-server
#opkg update
#opkg install rp-pppoe-server

#/etc/ppp/option 改 logfile /dev/null 为 logfile /tmp/pppoe.log
sed -i "s/dev/tmp/" /etc/ppp/options
sed -i "s/null/pppoe.log/" /etc/ppp/options
#pppoe-server带的rp-pppoe.so无法加载，调用openwrt自带的rp-pppoe.so
cp /etc/ppp/plugins/rp-pppoe.so /etc/ppp/plugins/rp-pppoe.so.bak
cp /usr/lib/pppd/2.4.7/rp-pppoe.so /etc/ppp/plugins/rp-pppoe.so
#/etc/ppp/pppoe-server-options 改require-pap为require-chap
sed -i "s/require-pap/require-chap/" /etc/ppp/pppoe-server-options
#/etc/ppp/chap-secrets添加一个用户(不添加无法运行)
echo "test * test *">>/etc/ppp/chap-secrets

#uci delete network.wan
uci delete network.wan6
uci commit network

uci set network.netkeeper=interface
uci set network.netkeeper.ifname=eth0.2
uci set network.netkeeper.macaddr=aabbccddeeff
uci set network.netkeeper.proto=pppoe
#TODO:set pppoe password
uci set network.netkeeper.username=username
uci set network.netkeeper.password=password
uci set network.netkeeper.metric='0'
uci commit network
#set firewall
uci set firewall.@zone[1].network='wan netkeeper' 
uci commit firewall
/etc/init.d/firewall restart
/etc/init.d/network reload
/etc/init.d/network restart

#使pppoe支持转义字符
cp /lib/netifd/proto/ppp.sh /lib/netifd/proto/ppp.sh_bak
sed -i '/proto_run_command/i username=`echo -e "$username"`' /lib/netifd/proto/ppp.sh
sed -i '/proto_run_command/i password=`echo -e "$password"`' /lib/netifd/proto/ppp.sh

#设置启动脚本
cp /root/nk4 /etc/init.d/nk4
chmod +x /etc/init.d/nk4
/etc/init.d/nk4 enable

