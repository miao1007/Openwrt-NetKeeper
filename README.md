#Openwrt-NetKeeper
这是重庆地区的Netkeeper的路由器拨号插件，没有心跳，详细教程见[这里](http://www.right.com.cn/forum/thread-141979-1-1.html)

###Download
* **Source code**:
	Source code are available in /src

###How to complie the plugin for your platform
1. Download the [Lastest GCC](http://downloads.openwrt.org/snapshots/trunk/)

2. Unzip the GCC to anywhere

		
4. edit /src/makefile, chnage the defalut GCC location to your GCC‘s location

5. run `make` in terminal

3. Upload your "sxplugin.so"

		scp  {drag your so's location here}   root@192.168.1.1:/usr/bin/pppd/2.4.7

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
    
    

5. ifup your NetKeeper interface in Luci

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
