#Download Lastest GCC in http://downloads.openwrt.org/snapshots/trunk/
#This is a demo for Netgear WNDR3800(AR71XX)

#TODO:填写gcc中bin与include所在的目录（根目录）
LOCATION=
CC=$(LOCATION)/bin/mips-openwrt-linux-gcc	#请注意不同型号路由器此处文件名可能略有不同
CFLAGS=-Os -Wall

all:sxplugin.so hainan_sxplugin.so

sxplugin.so:
	$(CC) $(CFLAGS) sxplugin.c -fPIC -I$(LOCATION)/include -shared -o sxplugin.so

hainan_sxplugin.so:
	$(CC) $(CFLAGS) hainan_sxplugin.c -fPIC -I$(LOCATION)/include -shared -o hainan_sxplugin.so
