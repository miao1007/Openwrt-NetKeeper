#download latest GCC in https://github.com/miao1007/Openwrt-NetKeeper/wiki#2-%E5%A6%82%E4%BD%95%E4%B8%8B%E8%BD%BDgcc
#This is a demo for Netgear WNDR3800(AR71XX)

#TODO:填写gcc中bin与include所在的目录（根目录）
LOCATION=../../OpenWrt-Toolchain-ramips-for-mipsel_24kec+dsp-gcc-4.8-linaro_uClibc-0.9.33.2/toolchain-mipsel_24kec+dsp_gcc-4.8-linaro_uClibc-0.9.33.2
#TODO:请注意不同型号(mips/mipsel)路由器此处gcc文件名可能略有不同
CC=$(LOCATION)/bin/mipsel-openwrt-linux-gcc
CFLAGS=-Os -Werror -I$(LOCATION)/include -fPIC

# TODO: change RADIUS
# 
# ChongQing Netkeeper: cqxinliradius002
# ChongQing Netkeeper(0094): xianxinli1radius
# WuHan E xin: hubtxinli01
# Hangzhou(Tested on HDU): singlenet01
# NanChangV18: nanchang3.0
# NanChangV12~V17: radius
# NanChangV29: nanchang3.0
# NanChangV32: jiangxi4.0
# QingHai: qhtel@xiaoyuanyi
# hebei: hebeicncxinli002
# ShanDong Mobile : shandongmobile13

# TODO: Change PREFIX1
# 
# NanChangV32: '1'
# Others: '\n'

all:chongqing_sxplugin wuhan_sxplugin hangzhou_sxplugin nanchang_sxplugin qinghai_sxplugin shandongmobile_sxplugin hebei_sxplugin shandongmobile_sxplugin hainan_sxplugin
	@echo "file generated successfully!"
	@ls -l *.so

#2.4.7 or 2.4.8, depends on your OS
upload:
	scp *.so root@192.168.1.1:/usr/lib/pppd/2.4.7/

chongqing_sxplugin:
	@$(CC) $(CFLAGS) sxplugin.c -DRADIUS='"xianxinli1radius"'  -DPREFIX1="'\n'" -shared -o $@.so

wuhan_sxplugin:
	@$(CC) $(CFLAGS) sxplugin.c -DRADIUS='"hubtxinli01"' -DPREFIX1="'\n'" -shared -o $@.so

hangzhou_sxplugin:
	@$(CC) $(CFLAGS) sxplugin.c -DRADIUS='"singlenet01"' -DPREFIX1="'\n'" -shared -o $@.so

nanchang_sxplugin:
	@$(CC) $(CFLAGS) sxplugin.c -DRADIUS='"jiangxi4.0"' -DPREFIX1="'1'" -shared -o $@.so

qinghai_sxplugin:
	@$(CC) $(CFLAGS) sxplugin.c -DRADIUS='"qhtel@xiaoyuanyi"' -DPREFIX1="'\n'" -shared -o $@.so


shandongmobile_sxplugin:
	@$(CC) $(CFLAGS) sxplugin.c -DRADIUS='"shandongmobile13"' -DPREFIX1="'\n'" -shared -o $@.so

hebei_sxplugin:
	@$(CC) $(CFLAGS) sxplugin.c -DRADIUS='"hebeicncxinli002"' -DPREFIX1="'\n'" -shared -o $@.so


hainan_sxplugin:
	@$(CC) $(CFLAGS) hainan_sxplugin.c -shared -o hainan_sxplugin.so

#clean *.so 
clean:
	rm *.so
