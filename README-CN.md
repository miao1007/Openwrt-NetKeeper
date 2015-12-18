#Openwrt-NetKeeper 闪讯拨号for OpenWrt


###简述

这是一个基于OpenWRT的闪讯拨号算法的实现。通过对Android版的反编译，获得到了拨号流程，并把它移植到OpenWRT上运行，~~实现打破毒瘤电信垄断的效果~~。

论坛见[这里](http://www.right.com.cn/forum/thread-141979-1-1.html)

心跳已经通过Android版反编译出来了，不过应该是烂尾了，找工作没时间移植了（用脚本语言发套接字就可以）.... <https://github.com/miao1007/android-netkeeper>


###工作原理
![How does it work](mdassets/hownetkeeperwork.png)

###支持地区
1. 武汉E信
2. 重庆
3. 杭州
4. 南昌(V18~V32)
5. 海南
6. 青海/新疆
7. 河北
8. 山东移动

查看更多： [supported radius](https://github.com/miao1007/Openwrt-NetKeeper/blob/master/src/makefile#L10)

###特性
1. 算法非常有效率，基于位运行优化，嵌入式设备也能轻松运行；
2. 可移植强，仅有的几个库文件在任何设备均可使用；
3. 自适应帐号长度，支持带后缀与不带后缀的运算；
4. 支持原厂OpenWrt、PandoraBox（但并不推荐）。

##配置安装

###准备工作
* 请安装一个64位的Ubuntu(推荐[14.04](http://releases.ubuntu.com/14.04/)) 系统 （虚拟机也可以）

###开始安装
以重庆地区MTK7620A方案路由器为例

####1. 下载gcc交叉编译器
在Ubuntu上执行：
```
wget https://downloads.openwrt.org/barrier_breaker/14.07/ramips/mt7620a/OpenWrt-Toolchain-ramips-for-mipsel_24kec%2bdsp-gcc-4.8-linaro_uClibc-0.9.33.2.tar.bz2
tar -xjf https://downloads.openwrt.org/barrier_breaker/14.07/ramips/mt7620a/OpenWrt-Toolchain-ramips-for-mipsel_24kec%2bdsp-gcc-4.8-linaro_uClibc-0.9.33.2.tar.bz2
```

##克隆项目到本地
```
git clone https://github.com/miao1007/Openwrt-NetKeeper.git

```

####2. 配置
仔细阅读并更改 makefile 和 confnetwork.sh 中的 `TODOS` 部分

####3. 上传
```
##make
cd Openwrt-NetKeeper/src/
make all
##ssh password for router is required
make upload
```

####4. 配置路由器
请用ssh登陆路由器并运行脚本
```
sh /tmp/confnetwork.sh 
```
最后请同步一下路由器时间并在浏览器中重连一下闪讯

##疑难问题

1. 请先在[wiki](https://github.com/miao1007/Openwrt-NetKeeper/wiki)中查找答案
2. 提交新的[issue](https://github.com/miao1007/Openwrt-NetKeeper/issues/new) （请附上系统日志）


##感谢
* [NETKEEPER ON WINDOWS](http://www.purpleroc.com/html/507231.html)
* [CQUPT NETKEEPER](http://bbs.cqupt.edu.cn/nForum/#!article/Unix_Linux/13624)

##作者
Leon - <miao1007@gmail.com>


##License

1. GPL
2. 勿做**TAOBAO**用途