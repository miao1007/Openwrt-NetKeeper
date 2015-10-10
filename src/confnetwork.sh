#!bin/sh
#this is a sample for Netkeeper in Chongqing
uci set network.netkeeper=interface
uci set network.netkeeper.proto='pppoe'
uci set network.netkeeper.ifname='eth0.2'
#set your province's plugin name
uci set network.netkeeper.pppd_options='plugin chongqing_sxplugin.so'
#set pppoe account and password
uci set network.netkeeper.username='153xxxx'
uci set network.netkeeper.password='xxxxx'
uci set network.netkeeper.metric='0'
uci commit network
             
#set firewall                                    
uci set firewall.@zone[1].network='wan netkeeper' 
uci commit firewall
/etc/init.d/firewall restart