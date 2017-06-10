# netkeeper4.x pppoe服务器拦截账号法

根据 issue [#138](https://github.com/miao1007/Openwrt-NetKeeper/issues/138) 提供的思路，测试了一下，可以配置成功。作为单片机码农，不太会写shell脚本，面向搜索引擎写了一个。我自己测试可以用，可以做到配置好之后，只需要电脑开创翼拨号，路由器就可以捕捉账号，并联网。

如果拨号失败，会自动关闭pppoe拨号。

心跳我不懂，我们学校是不会断网，希望有人能给出解决方案。

用top命令看了一下，cpu是0%，不会拖累路由器性能。如果这个测法不对，希望给出测试结果。

## 一、使用方法
### （一）路由器端
#### 1.将netkeeper4文件夹下所有文件拷入openwrt的/root/目录。
#### 2.安装pppoe服务端
安装自己路由器对应版本的ipk(这里以我的路由器为例)。

方法一(路由器可以上网)：
```sh
opkg update
opkg install rp-pppoe-server
```

方法二(路由器无法上网，自行下载对应ipk，这里以tengda-ac9为例)：
```sh
opkg install rp-pppoe-common_3.12-1_arm_cortex-a9.ipk
opkg install rp-pppoe-server_3.12-1_arm_cortex-a9.ipk
```
#### 3.运行nk4conf.sh。
```sh
sh nk4conf.sh
```
### （二）电脑端

1.网线接路由器lan口

2.netkeeper输入账号密码拨号，会提示691错误，关闭netkeeper。

3.这个时候路由器会截取真实账号，并进行拨号。

## 二、个人测试环境：
路由器：

tenda-ac9 [lede17.01.0](https://downloads.lede-project.org/releases/17.01.0/targets/bcm53xx/generic)固件

newifi mini [PandoraBox 17.01](http://downloads.pandorabox.com.cn/pandorabox-16-10-stable/targets/ralink/mt7620/)固件

hg255d/hc5661a PandoraBox固件 {Base on OpenWrt BARRIER BREAKER (14.09, r865)}

地点：CQUPT

## 三、问题
### （一）如果账号里出现双引号"，会获取失败。希望有人能解决。
log格式
```
rcvd [PAP AuthReq id=0xf user="username" password="passwd"]
```
我的处理方法：
```sh
username=$(grep 'user=' /tmp/pppoe.log | grep 'rcvd' | tail -n 1 | cut -d \" -f 2)
```

## 四、ipk下载
可以在路由器里运行
```
opkg update
```
一般会返回类似网址，去网址里找包
```
Downloading http://downloads.openwrt.org.cn/PandoraBox/ralink/packages/routing/Packages.gz.
```
