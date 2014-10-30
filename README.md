#Openwrt-NetKeeper
这是重庆地区的Netkeeper的拨号插件，没有心跳，详细教程见[这里](http://www.right.com.cn/forum/thread-141979-1-1.html)

###Download
* <b>Source code</b>:
	Source code are available in /src
* <b>Trunk</b>: Compiled code are available for
	* Huawei HG255D
	* Netgear WNDR3800


###How to complie the plugin for your platform
1. Download the [Lastest GCC](http://downloads.openwrt.org/snapshots/trunk/)

2. Unzip it to anywhere

3. git my source code

		git clone https://github.com/miao1007/Openwrt-NetKeeper.git
		cd Openwrt-NetKeeper/src
		git clone https://github.com/squadette/pppd.git
		
4. edit /src/makefile, chnage the defalut GCC location to your GCC location

5. run `make` in terminal

3. Upload your "sxplugin.so"

		scp  {your so's location}   root@192.168.1.1:/usr/bin/pppd/2.4.7

4. Configure your router

		ssh root@192.168.1.1
		vi /etc/config/network


	To configure your wan interface
	
		config interface 'NetKeeper'
        	option proto 'pppoe'
        	option ifname 'eth2.2（可能是eth0.2，反正就是wan口）'
        	option pppd_options 'plugin 
        	option username 'phone number'
        	option password 'xxxxx'
        	option metric '0'
    
    

5. ifup your NetKeeper interface in Luci

##Acknowledgements
* 无私制作HG255D镜像的同学，我也找不到引用源了
* 研究闪讯的重邮/浙江/江苏前辈

##Developed By
Leon - miao1007@gmail.com
