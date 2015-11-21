#download latest GCC in https://github.com/miao1007/Openwrt-NetKeeper/wiki#2-%E5%A6%82%E4%BD%95%E4%B8%8B%E8%BD%BDgcc
#This is a demo for MTK7620A

#TODO:填写gcc中bin与include所在的目录（根目录）
LOCATION=../../OpenWrt-Toolchain-ramips-for-mipsel_24kec+dsp-gcc-4.8-linaro_uClibc-0.9.33.2/toolchain-mipsel_24kec+dsp_gcc-4.8-linaro_uClibc-0.9.33.2
#TODO:请注意不同型号(mips/mipsel)路由器此处gcc文件名可能略有不同
CC=$(LOCATION)/bin/mipsel-openwrt-linux-gcc
#TODO:可能需要修改pppd的版本，取决于路由器的/usr/lib/pppd/，目前主流的14.09是2.4.7
PPPD_VER=2.4.7
CFLAGS=-Os -Werror -I$(LOCATION)/include -fPIC -DPPPOE_VER='"${PPPD_VER}"'

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
# Shanxi Yixun : sh_xi@xiaoyuan01
# ShanDong Telecome : 560Ox!a0yuanOlIz  (For 3.7.3 Augest Version)
# ShanDong Telecome : shdOx!a0yuan01lz  (For 3.7.3 October 27th Version)

# TODO: Change PREFIX1
# 
# NanChangV32: '1'
# Others: '\n'

all:chongqing_sxplugin wuhan_sxplugin hangzhou_sxplugin nanchang_sxplugin qinghai_sxplugin shandongmobile_sxplugin hebei_sxplugin shandongmobile_sxplugin shanxi_yixun_sxplugin hainan_sxplugin
	@find *.so
	@echo "拨号组件编译成功，注意修改confnetwork.sh的sxplugin名称为本省的名称，以及拨号帐号与密码!，然后运行make upload"

#you can also upload only your province's so file
upload:
	@echo "正在上传拨号组件，请输入路由器ssh密码"
	scp *.so root@192.168.1.1:/usr/lib/pppd/${PPPD_VER}/
	@echo "正在上传网络配置脚本，请输入路由器ssh密码"
	scp confnetwork.sh root@192.168.1.1:/tmp/
	@echo "正在登录路由器，请在输入路由器ssh密码后，运行sh /tmp/confnetwork.sh"
	ssh root@192.168.1.1

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
	
shanxi_yixun_sxplugin:
	@$(CC) $(CFLAGS) sxplugin.c -DRADIUS='"sh_xi@xiaoyuan01"' -DPREFIX1="'\n'" -shared -o $@.so

shandong_telecom_aug_sxplugin:
	@$(CC) $(CFLAGS) sxplugin.c -DRADIUS='"560Ox!a0yuanOlIz"' -DPREFIX1="'\n'" -shared -o $@.so
	
shandong_telecom_oct_sxplugin:
	@$(CC) $(CFLAGS) sxplugin.c -DRADIUS='"shdOx!a0yuan01lz"' -DPREFIX1="'\n'" -shared -o $@.so

hainan_sxplugin:
	@$(CC) $(CFLAGS) hainan_sxplugin.c -shared -o $@.so

#clean *.so 
clean:
	rm *.so
