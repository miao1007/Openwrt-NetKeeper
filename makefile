#去OP官网下载交叉编译需要的GCC
CC={你的gcc文件夹的位置}/mipsel-openwrt-linux-uclibc-gcc-4.6.3
# CFLAGS=-Os -Wall

all:sxplugin.so

sxplugin.so:
        $(CC) $(CFLAGS) sxplugin.c -fPIC -I{你的gcc文件夹的位置}/include -shared -o sxplugin.so