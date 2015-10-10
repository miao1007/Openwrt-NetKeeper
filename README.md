#Openwrt-NetKeeper


###Overview

This is an algorithm(C/Linux) to generate the real username during PPPoE. I disassembled the code from the Android version , modified it to run the algorithm on OpenWRT.

这是一个基于OpenWRT的闪讯拨号算法的实现。通过对Android版的反编译，获得到了拨号流程，并把它移植到OpenWRT上运行，~~实现打破毒瘤电信垄断的效果~~。

论坛见[这里](http://www.right.com.cn/forum/thread-141979-1-1.html)

心跳已经通过Android版反编译出来了，不过应该是烂尾了，找工作没时间移植了（用脚本语言发套接字就可以）.... <https://github.com/miao1007/android-netkeeper>


###How Does It Work
![How does it work](mdassets/hownetkeeperwork.png)

###Supported Province
1. 武汉E信
2. 重庆
3. 杭州
4. 南昌(V18~V32)
5. 海南
6. 青海/新疆
7. 河北
8. 山东移动

See more at [supported radius](https://github.com/miao1007/Openwrt-NetKeeper/blob/master/src/makefile#L10)

###Features
1. 算法非常有效率，基于位运行优化，嵌入式设备也能轻松运行；
2. 可移植强，仅有的几个库文件在任何设备均可使用；
3. 自适应帐号长度，支持带后缀与不带后缀的运算；
4. 支持原厂OpenWrt、PandoraBox（但并不推荐）。

###Before Start
* Install a 64-bit Ubuntu(14.04) on your PC or Virtual-Machine

##Getting Start
Samples for MTK7620A in ChongQing

####Download cross-compile gcc
```
wget https://downloads.openwrt.org/barrier_breaker/14.07/ramips/mt7620a/OpenWrt-Toolchain-ramips-for-mipsel_24kec%2bdsp-gcc-4.8-linaro_uClibc-0.9.33.2.tar.bz2
tar -xjf https://downloads.openwrt.org/barrier_breaker/14.07/ramips/mt7620a/OpenWrt-Toolchain-ramips-for-mipsel_24kec%2bdsp-gcc-4.8-linaro_uClibc-0.9.33.2.tar.bz2
##git clone source code
git clone https://github.com/miao1007/Openwrt-NetKeeper.git

##read and edit makefile and confnetwork.sh carefully

##make
cd Openwrt-NetKeeper/src/
make all
##ssh password for router is required
make upload
```

##config router
ssh into the router and run the script

```
sh /tmp/confnetwork.sh ```

finially sync your router's time and reconnect your NetKeeper interface  in browser

##Troubleshooting

1. Search wiki before ask question <https://github.com/miao1007/Openwrt-NetKeeper/wiki>
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