#!bin/sh
wget https://downloads.openwrt.org/barrier_breaker/14.07/ramips/mt7620a/OpenWrt-Toolchain-ramips-for-mipsel_24kec%2bdsp-gcc-4.8-linaro_uClibc-0.9.33.2.tar.bz2 | tar -xjf 
##git clone source code
git clone --depth=1 https://github.com/miao1007/Openwrt-NetKeeper.git

##read and edit makefile and confnetwork.sh carefully

##make
cd Openwrt-NetKeeper/src/
make all
##ssh password for router is required
make upload