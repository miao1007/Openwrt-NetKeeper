#Download Lastest GCC in http://downloads.openwrt.org/snapshots/trunk/
#This is a demo for Netgear WNDR3800(AR71XX)

#TODO : Change the location for your GCC’s location
CC=/home/leon/netkeeper/OpenWrt-Toolchain-ar71xx-for-mips_34kc-gcc-4.8-linaro_uClibc-0.9.33.2/toolchain-mips_34kc_gcc-4.8-linaro_uClibc-0.9.33.2/bin/mips-openwrt-linux-gcc
CFLAGS=-Os -Wall

all:sxplugin.so

sxplugin.so:
	$(CC) $(CFLAGS) sxplugin.c -fPIC -I/home/leon/netkeeper/OpenWrt-Toolchain-ar71xx-for-mips_34kc-gcc-4.8-linaro_uClibc-0.9.33.2/toolchain-mips_34kc_gcc-4.8-linaro_uClibc-0.9.33.2/include -shared -o sxplugin.so
