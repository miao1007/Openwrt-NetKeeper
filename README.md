#Openwrt-NetKeeper


###Overview

这是Netkeeper的路由器拨号插件，没有心跳，支持重庆Netkeeper，武汉E信，杭州。详细介绍见[这里](http://www.right.com.cn/forum/thread-141979-1-1.html)

心跳已经反编译出来了，不过应该是烂尾了，没时间移植了（用脚本语言发套接字就可以）.... <https://github.com/miao1007/android-netkeeper>


###Before Start
* Install a 64-bit Ubuntu on your PC or Virtual-Machine
* Download the [Lastest GCC](http://downloads.openwrt.org/snapshots/trunk/)



###Getting Start

1. Git clone and **read** the code.

2. Unzip the GCC to anywhere
		
4. edit /src/makefile, change the defalut `CC` and `-I`  to your GCC‘s location

```
#Get Lastest GCC in http://downloads.openwrt.org/snapshots/trunk/
#This is a demo for Netgear WNDR3800(AR71XX)

#TODO : Change the location for your GCC’s location
CC=/home/leon/netkeeper/OpenWrt-Toolchain-ar71xx-for-mips_34kc-gcc-4.8-linaro_uClibc-0.9.33.2/toolchain-mips_34kc_gcc-4.8-linaro_uClibc-0.9.33.2/bin/mips-openwrt-linux-gcc
CFLAGS=-Os -Wall

all:sxplugin.so

sxplugin.so:
$(CC) $(CFLAGS) sxplugin.c -fPIC -I/home/leon/netkeeper/OpenWrt-Toolchain-ar71xx-for-mips_34kc-gcc-4.8-linaro_uClibc-0.9.33.2/toolchain-mips_34kc_gcc-4.8-linaro_uClibc-0.9.33.2/include -shared -o sxplugin.so
```

5. run `make` in terminal

3. Upload your "sxplugin.so"

		scp  {drag your `.so` file here}   root@192.168.1.1:/usr/lib/pppd/2.4.7/

4. Configure your router

		ssh root@192.168.1.1
		vi /etc/config/network


	To configure your wan interface
	
		config interface 'NetKeeper'
        	option proto 'pppoe'
        	option ifname 'eth0.2'
        	option pppd_options 'plugin sxplugin.so'
        	option username 'phone number'
        	option password 'xxxxx'
        	option metric '0'
    
5. sync your router's time.

6. reconnect your NetKeeper interface in Luci

##Troubleshooting

1. Search wiki before ask question <https://github.com/miao1007/Openwrt-NetKeeper/wiki>
2. Submit new [issue](https://github.com/miao1007/Openwrt-NetKeeper/issues/new) with your Log in OpenWRT.

##Acknowledgements
* [NETKEEPER ON WINDOWS](http://www.purpleroc.com/html/507231.html)
* [CQUPT NETKEEPER](http://bbs.cqupt.edu.cn/nForum/#!article/Unix_Linux/13624)

##Developed By
Leon - miao1007@gmail.com

##License

    Copyright 2013,2014 miao1007@gmail.com

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
