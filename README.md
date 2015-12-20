#Openwrt-NetKeeper

[中文说明](./README-CN.md)

This is an algorithm(C/Linux) to generate the real username during PPPoE. I disassembled the code from the Android version , modified it to run the algorithm on OpenWRT.

Click [here](http://www.right.com.cn/forum/thread-141979-1-1.html) to see BBS topic.

![How does it work](mdassets/hownetkeeperwork.png)


###Features
1. Efficiency algorithm, specially optimized for embedded system.
2. Portable, you can swift this script to other devices.
3. Auto-fit all kinds of username input.
4. Support both OpenWRT and PandoraBox(not recommend).


###Supported Province

See all suppported provinces at [supported radius](https://github.com/miao1007/Openwrt-NetKeeper/blob/master/src/makefile#L10)

##Usage

####1. Download the Latest release

1. [sxplugin.so](https://github.com/miao1007/Openwrt-NetKeeper/releases)
2. [confnetwork.sh](https://github.com/miao1007/Openwrt-NetKeeper/blob/master/src/confnetwork.sh)
 
after downloaded, please edit `pppd_options` `username ` `password ` in `confnetwork.sh` ,



####2. Upload
use scp(you can try [WinScp](https://winscp.net/download/winscp576.zip) on windows ) to upload

```
yourprovince_sxplugin.so -> /usr/lib/pppd/2.4.7/
confnetwork.sh -> /tmp/
```

####3. Config
ssh into the router and run the script

```
chmod a+x /tmp/confnetwork.sh
sh /tmp/confnetwork.sh 
```

finially sync your router's time and reconnect your NetKeeper interface in browser


##Development
This is for advanced development only. 

###1. Compile from source code

As a prerequisite you should setup a 64-bit Ubuntu(recommend [14.04](http://releases.ubuntu.com/14.04/)) with its dependencies. Or you can use [Coding.net's WorkSpace](https://ide.coding.net/) to compile the binary

####1.1. Get the source code on your machine

```
git clone --depth=1 https://github.com/miao1007/Openwrt-NetKeeper.git
```

####1.2. Get Toolchain

download latest [Toolchain](https://github.com/miao1007/Openwrt-NetKeeper/wiki#2-%E5%A6%82%E4%BD%95%E4%B8%8B%E8%BD%BDgcc)

or use script

```
#this is a sample for mipsel(Little Endian) device
wget https://downloads.openwrt.org/barrier_breaker/14.07/ramips/mt7620a/OpenWrt-Toolchain-ramips-for-mipsel_24kec%2bdsp-gcc-4.8-linaro_uClibc-0.9.33.2.tar.bz2 -O - | tar xj
#or chinese mirror
#wget http://mirrors.ustc.edu.cn/openwrt/barrier_breaker/14.07/ramips/mt7620a/OpenWrt-Toolchain-ramips-for-mipsel_24kec%2bdsp-gcc-4.8-linaro_uClibc-0.9.33.2.tar.bz2 -O - | tar xj
```


####1.3. Config

Read and edit `makefile` and `confnetwork.sh` **TODOS** carefully

####1.4. Compile
	

```
cd Openwrt-NetKeeper/src/
make all
```

####1.5. (Optinal)Download from Cloud
if using cloud IDE, try


```
tar zcf sxplugin_mipsel.tar *_sxplugin.so
```

and download.

###2. Config router

You can use my script to upload

```
make upload
```


##Troubleshooting

1. Search [wiki](https://github.com/miao1007/Openwrt-NetKeeper/wiki) before ask question 
2. Submit new [issue](https://github.com/miao1007/Openwrt-NetKeeper/issues/new) with your log in OpenWRT.


##Acknowledgements
* [NETKEEPER ON WINDOWS](http://www.purpleroc.com/html/507231.html)
* [CQUPT NETKEEPER](http://bbs.cqupt.edu.cn/nForum/#!article/Unix_Linux/13624)
* <https://sunflyer.cn/archives/239>

##Developed By
Leon - <miao1007@gmail.com>


##License

1. GPL
2. No **TAOBAO** use