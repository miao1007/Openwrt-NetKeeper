Openwrt-NetKeeper
=================

这是重庆地区的Netkeeper的拨号插件，没有心跳，详细教程见[这里](http://www.right.com.cn/forum/thread-141979-1-1.html)

说明
-----------------
* src为源码目录，用于不同平台的交叉编译器能编译出适合该CPU的代码
* trunk为成品，现在我只有HG255D的成品，如果你编译成功了其他CPU的，可以fork我

教程
-----------------
1. 下载与配置适合你的gcc编译器
  * 去OP官网下载GCC,[点我](http://downloads.openwrt.org.cn/PandoraBox/)进入
  * 自己找到你的路由器的型号，比如ralink ，不同CPU不能混用 ，然后找package里面的叫做类似“OpenWrt-Toolchain-你的CPU-for-mipsel_r2-gcc-4.6...”这个包 
  * 解压到任意地方

2. 下载源码
  * `git clone https://github.com/miao1007/Openwrt-NetKeeper.git`
  * 打开文本编辑器，修改src/sxplugin.c里面的gcc文件路径
  * `cd Openwrt-NetKeeper/src`
  * `git clone https://github.com/squadette/pppd.git`
  * `make`

3. 上传固件
  * `scp  {你的so文件的位置}   root@192.168.1.1:/usr/bin/pppd/2.4.5`

4. 配置路由
  * `ssh root@192.168.1.1`
  * `vi /etc/config/network`


我要配置的是WAN口，需要添加如下代码:
		
	config interface 'NetKeeper'
        option proto 'pppoe'
        option ifname 'eth2.2（可能是eth0.2，反正就是wan口）'
        option pppd_options 'plugin sxplugin.so'
        option username '手机号'
        option password '密码'
        option metric '0'
    
    

插网线，路由器对好时间就可以了

感谢如下同学
-----------------
* 无私制作HG255D镜像的同学，我也找不到引用源了
* 研究闪讯的重邮/浙江/江苏前辈

联系方式
-----------------
Email : miao1007@gmail.com
