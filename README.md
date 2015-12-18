#Openwrt-NetKeeper

[中文说明](/README-CN.md)
###Overview

This is an algorithm(C/Linux) to generate the real username during PPPoE. I disassembled the code from the Android version , modified it to run the algorithm on OpenWRT.

Click [here](http://www.right.com.cn/forum/thread-141979-1-1.html) to see BBS topic.


###How Does It Work
![How does it work](mdassets/hownetkeeperwork.png)

###Supported Province

See all suppported provinces at [supported radius](https://github.com/miao1007/Openwrt-NetKeeper/blob/master/src/makefile#L10)

###Features
1. Efficiency algorithm, specially optimized for embedded system.
2. Portable, you can swift this script to other devices.
3. Auto-fit all kinds of username input.
4. Support both OpenWRT and PandoraBox(not recommend).

###Before Start
* Install a 64-bit Ubuntu(recommend [14.04](http://releases.ubuntu.com/14.04/)) on your PC or Virtual-Machine

###Getting Start
Samples for MTK7620A in ChongQing

####1. Download cross-compile gcc
on your Ubuntu device:
```
wget https://downloads.openwrt.org/barrier_breaker/14.07/ramips/mt7620a/OpenWrt-Toolchain-ramips-for-mipsel_24kec%2bdsp-gcc-4.8-linaro_uClibc-0.9.33.2.tar.bz2
tar -xjf https://downloads.openwrt.org/barrier_breaker/14.07/ramips/mt7620a/OpenWrt-Toolchain-ramips-for-mipsel_24kec%2bdsp-gcc-4.8-linaro_uClibc-0.9.33.2.tar.bz2

##git clone source code
git clone https://github.com/miao1007/Openwrt-NetKeeper.git

```

####2. Config
Read and edit makefile and confnetwork.sh `TODOS` carefully

####3. Upload
```
##make
cd Openwrt-NetKeeper/src/
make all
##ssh password for router is required
make upload
```

####4. Config router
ssh into the router and run the script

```
sh /tmp/confnetwork.sh 
```

finially sync your router's time and reconnect your NetKeeper interface  in browser

##Troubleshooting

1. Search [wiki](https://github.com/miao1007/Openwrt-NetKeeper/wiki) before ask question 
2. Submit new [issue](https://github.com/miao1007/Openwrt-NetKeeper/issues/new) with your log in OpenWRT.

##TODO
add js script for timesync

##Acknowledgements
* [NETKEEPER ON WINDOWS](http://www.purpleroc.com/html/507231.html)
* [CQUPT NETKEEPER](http://bbs.cqupt.edu.cn/nForum/#!article/Unix_Linux/13624)

##Developed By
Leon - <miao1007@gmail.com>


##License

1. GPL
2. No **TAOBAO** use