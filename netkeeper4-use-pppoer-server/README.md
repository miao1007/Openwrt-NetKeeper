# netkeeper4.x pppoe服务器拦截账号法

根据 issue [#138](https://github.com/miao1007/Openwrt-NetKeeper/issues/138) 提供的思路，测试了一下，可以配置成功。作为单片机码农，不太会写shell脚本，面向搜索引擎写了一个。我自己测试可以用，可以做到配置好之后，只需要电脑开创翼拨号，路由器就可以捕捉账号，并联网。心跳我不懂，测试的时候也没断。但是效率/BUG未知。

主要目的抛砖引玉。
## 一、使用方法
### （一）路由器端
配置完了再接wan口，不然会遇到Timeout waiting for PADO packets提示。要等一段时间才能拨号。原因不懂。
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
#### 4.修改pppoe接口密码为自己的密码，并关闭端口开机自动连接。
### （二）电脑端

1.网线接路由器lan口

2.netkeeper输入账号密码拨号，会提示691错误，关闭netkeeper。

3.这个时候路由器会截取真实账号，并进行拨号。

## 二、个人测试环境：
路由器：tenda-ac9 [lede17.01.0](https://downloads.lede-project.org/releases/17.01.0/targets/bcm53xx/generic)固件

地点：CQUPT

等毕业答辩完了我用newifi mini测一下
