#download latest GCC in https://github.com/miao1007/Openwrt-NetKeeper/wiki#2-%E5%A6%82%E4%BD%95%E4%B8%8B%E8%BD%BDgcc
#This is a demo for Netgear WNDR3800(AR71XX)

#TODO:填写gcc中bin与include所在的目录（根目录）
LOCATION=/home/leon/netkeeper/OpenWrt-Toolchain-ar71xx-for-mips_34kc-gcc-4.8-linaro_uClibc-0.9.33.2/toolchain-mips_34kc_gcc-4.8-linaro_uClibc-0.9.33.2
#TODO:请注意不同型号(mips/mipsel)路由器此处gcc文件名可能略有不同
CC=$(LOCATION)/bin/mips-openwrt-linux-gcc	
CFLAGS=-Os -Wall

all:sxplugin.so hainan_sxplugin.so

sxplugin.so:
	$(CC) $(CFLAGS) sxplugin.c -fPIC -I$(LOCATION)/include -shared -o sxplugin.so

#generate plugin for *.so
hainan_sxplugin.so:
	$(CC) $(CFLAGS) hainan_sxplugin.c -fPIC -I$(LOCATION)/include -shared -o hainan_sxplugin.so

#clean *.so 
clean:
	@rm *.so
