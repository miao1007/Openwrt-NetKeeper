using SimpleNetkeeper_Win;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using logger = JiangXiCracker.SnkLog;

namespace JiangXiCracker
{
    class HubeiPortal : AbsXinliPortal
    {

        private const string AES_KEY_PASSWORD = "pass012345678910",
            AES_KEY_SESSION = "jyangzi5@163.com";

        private string Session { get; set; }

        private List<Cookie> Cookie { get; set; }

        private static Dictionary<string,string> Headers { get; set; }

        private static Dictionary<string , string> ErrorMsg { get; set; }

        private static Dictionary<string, string> getHeaders() {
            if (Headers == null) {
                Headers = new Dictionary<string, string>();
                Headers.Add("App", "HBZD");
                Headers.Add("User-Agent", "Mozilla/Android/6.0/Letv X620/ffffffff-9404-802f-ffff-ffff89a12926");
            }
            return Headers;
        }

        private static void initErrMsg()
        {
            if (ErrorMsg != null) {
                return;
            }
            ErrorMsg = new Dictionary<string, string>();
            ErrorMsg.Add("No Service response", "宽带认证服务异常，请联系10000客服");
            ErrorMsg.Add("is Locked", "宽带欠费或者状态不正常（被锁定）");
            ErrorMsg.Add("return Account Locked", "账户被锁定，请确认是否欠费");
            ErrorMsg.Add("return Credit is ZERO", "账号余额为0，不能登录");
            ErrorMsg.Add("ai-Service-Password", "宽带密码错误");
            ErrorMsg.Add("ai-vlan-id", "VLAN属性错误，请联系电信维修人员");
            ErrorMsg.Add("Called Number", "306 : 客户端已过期，请获取新版使用");
            ErrorMsg.Add("NAS-IP-Address", "NAS属性错误，请联系电信维修人员");
            ErrorMsg.Add("database authen forbiden", "宽带账号不存在，请联系10000客服");
            ErrorMsg.Add("return Illegal Account", "309 : 客户端已过期，请获取新版使用");
            ErrorMsg.Add("Null String", "宽带账号为空");
            ErrorMsg.Add("return Service Not Available", "宽带认证服务异常，请联系10000客服");
            ErrorMsg.Add("comm with Remote Radius Error", "漫游地接入服务无响应");
            ErrorMsg.Add("Checking LM, policy", "账号已超过最大在线数量");
            ErrorMsg.Add("not from same nas port", "未从指定端口上网，禁止登陆");
            ErrorMsg.Add("IsValidClientAccount", "非e信上网错");
            ErrorMsg.Add("User-Name not start with", "316 : 客户端已过期，请获取新版使用");
            ErrorMsg.Add("return Call Time is ZERO", "账号剩余时间为0，无法连接");
            ErrorMsg.Add("Option60,Check Error", "IPTV账号密码错误");
            ErrorMsg.Add("ai-school-scope", "319 : 你的帐号不在指定的学校范围，不能登录");
            ErrorMsg.Add("ai-Node-Id", "320 : 你的帐号不在指定的学校范围，不能登录");
            ErrorMsg.Add("Wrong Password", "321 : 宽带密码错误");
            ErrorMsg.Add("EXin User Password Validity Check Failed", "322 : 宽带密码错误");
            ErrorMsg.Add("ai-vlan-scope-exclude", "323 : 你的帐号不在指定的学校范围，不能登录");
            ErrorMsg.Add("EXin User Password Error", "324 : 宽带密码错误");
        }

        private static string getErrorMsg(string resp) {
            initErrMsg();
            foreach (string x in ErrorMsg.Keys) {
                if (resp.Contains(x)) {
                    return ErrorMsg[x];
                }
            }
            return resp;
        }

        private HttpWebRequest createRequest(string url, List<Cookie> cookie) {
            HttpWebRequest hRequest = null;
            try
            {
                hRequest = (HttpWebRequest)HttpWebRequest.Create("http://" + Host + "/" + url);

                Dictionary<string, string> header = getHeaders();
                foreach (string x in header.Keys)
                {
                    try
                    {
                        hRequest.Headers.Add(x, header[x]);
                    }
                    catch (Exception)
                    {
                        logger.log("[SnkHubei] Secret set header failed [" + x + "]");
                    }
                }
                if (header.ContainsKey("User-Agent"))
                {
                    hRequest.UserAgent = header["User-Agent"];
                }
                hRequest.KeepAlive = true;
                hRequest.CookieContainer = new CookieContainer();


                if (cookie != null && cookie.Count > 0)
                {
                    CookieCollection cc = new CookieCollection();
                    foreach (Cookie x in cookie)
                    {
                        cc.Add(x);
                    }
                    hRequest.CookieContainer.Add(cc);
                }

                hRequest.Timeout = 10 * 1000;
                
            }
            catch (Exception e)
            {
                logger.log("[SnkHubei] [Error] Create Http Failed. " + e.Message );
                LastErrorMsg = "创建连接失败。";
                return null;
            }

            return hRequest;
        }

        private static string getSessionEnc(string session) {
            return SnkTool.toHex(Encrypt.aesEcbEnc(session, AES_KEY_SESSION));
        }

        private static string getPasswordEnc(string sess) {
            return SnkTool.toHex(Encrypt.aesEcbEnc(sess, AES_KEY_PASSWORD));
        }

        public override bool authenticate()
        {
            HttpWebRequest hRequest = createRequest("wf.do", this.Cookie);
            if (hRequest == null)
            {
                LastErrorMsg = "(5/10) 创建链接失败";
                logger.log("[SnkHubei] [Error] authenticate create connection failed");
                return false;
            }

            hRequest.Headers["Charset"] = "UTF-8";
            hRequest.ContentType = "application/x-www-form-urlencoded";

            string postData = "password=" + getPasswordEnc(this.Password)
                   + "&clientType=android&username=" + this.UserName 
                   + "&key=" + getSessionEnc(this.AccessToken)
                   + "&code=8&clientip=" + this.LocalIpAddress;

            hRequest.ContentLength = postData.Length;
            hRequest.Method = "POST";

            try {
                byte[] dataParsed = Encoding.Default.GetBytes(postData.ToString());
                hRequest.GetRequestStream().Write(dataParsed, 0, dataParsed.Length);

                HttpWebResponse hWebResponse = hRequest.GetResponse() as HttpWebResponse;

                string resp = parseToHtml(hWebResponse , Encoding.GetEncoding("GBK"));

                if (resp.IndexOf("auth00") >= 0) {
                    LastErrorMsg = "连接成功.";
                    logger.log("[SnkHubei] [Info] authenticate 连接成功，返回数据[" + resp + "]");
                    return true;
                }

                LastErrorMsg = "连接失败[" + getErrorMsg(resp) + "]";
                logger.log("[SnkHubei] [Error] authenticate 连接失败，返回数据[" + resp + "]");
            }
            catch(Exception e)
            {
                LastErrorMsg = "(6/10) 由于异常连接失败";
                logger.log("[SnkHubei] [Error] authenticate " + e.Message);
            }
            return false;
        }

        public override string connect(string name, string pass)
        {
            this.UserName = name;
            this.Password = pass;

            if (this.loadRedirect() && this.getSecret() && this.authenticate()) {
                return "Success";
            }

            return null;
        }


        public override bool getSecret()
        {
            HttpWebRequest hRequest = createRequest("wf.do?device=Phone%3ALetv+X620%5CSDK%3A23&clientType=android&code=1&version=6.0&clientip=" + LocalIpAddress, null);
            if (hRequest == null) {
                LastErrorMsg = "(3/10) 创建链接获取参数失败";
                logger.log("[SnkHubei] [Error] Secret create connection failed");
                return false;
            }
            try
            {
                WebResponse hResp = hRequest.GetResponse();
                if (hResp != null && hResp is HttpWebResponse)
                {
                    HttpWebResponse hRespWeb = hResp as HttpWebResponse;

                    this.AccessToken = parseToHtml(hRespWeb);

                    if (hRespWeb.Cookies.Count == 0)
                    {
                        LastErrorMsg = "(4/10) 获取参数失败";
                        logger.log("[SnkHubei] [Error] Secret resp [" + this.AccessToken + "]");
                        if (this.AccessToken == "nat01") {
                            LastErrorMsg = "(4/10) 电信服务器认为你不在校园网环境\n请更新路由器WAN口IP然后重试或者找电信报修";
                        }
                        return false;
                    }

                    this.Cookie = new List<System.Net.Cookie>();
                    foreach (Cookie x in hRespWeb.Cookies)
                    {
                        this.Cookie.Add(x);
                        logger.log("[SnkHubei] [Info] Secret " + x.Name + " = " + x.Value);
                    }

                    logger.log("[SnkHubei] [Info] Secret Data = " + this.AccessToken);

                    return true;
                }
                else {
                    throw new Exception("Response invalid");
                }
            }
            catch (Exception e)
            {
                LastErrorMsg = "(4/10) 由于异常无法获取拨号参数";
                logger.log("[SnkHubei] [Error] Secret " + e.Message);
            }
            return false;
        }

        public override bool loadRedirect()
        {
            if (!string.IsNullOrWhiteSpace(this.RouterIpAddress)) {
                //use client
                this.Host = "58.53.196.165:8080";
                this.LocalIpAddress = this.RouterIpAddress;
                logger.log("[SnkHubei] 使用路由器IP地址[" + this.LocalIpAddress + "]");
                return true;
            }

            HttpWebRequest hRequest = null;

            try
            {
                hRequest = (HttpWebRequest)HttpWebRequest.Create(REDIRECT_ADDR);
                hRequest.AllowAutoRedirect = false;
                hRequest.Timeout = 5 * 1000;
            }
            catch (Exception)
            {
                logger.log("[SnkHubei] [Error] Create Http Failed.");
                LastErrorMsg = "(1/10) 获取NAS服务器失败。";
                return false;
            }

            try
            {
                WebResponse hResp = hRequest.GetResponse();
                if (hResp != null && hResp is HttpWebResponse)
                {
                    HttpWebResponse hRespWeb = hResp as HttpWebResponse;
                    if (hRespWeb.StatusCode == HttpStatusCode.Found)
                    {
                        string location = hRespWeb.Headers["Location"];
                        this.RedirectUrl = location;

                        ////http://58.53.196.165:8080?userip=100.64.64.76&wlanacname=&nasip=59.175.245.211&usermac=74-c3-30-12-e5-d7
                        //get ip from link
                        int index = location.IndexOf("?");
                        if (index < 0)
                        {
                            throw new Exception("Redirect Url Invalid , url=" + location);
                        }

                        this.Host = location.Substring(7, location.IndexOf("?", 7) - 7);

                        string keyval = location.Substring(index + 1);
                        Dictionary<string, string> kv = SnkTool.getParamToDict(keyval);
                        if (kv == null || kv.Count == 0 || !kv.ContainsKey("userip"))
                        {
                            throw new Exception("Parameter invalid , url=" + location);
                        }

                        this.LocalIpAddress = kv["userip"];

                        logger.log("[SnkHubei] [Info] RedirUrl[" + location + "] IP[" + LocalIpAddress + "] HOST[" + Host + "]");
                        return true;
                    }
                    else
                    {
                        LastErrorMsg = "(2/10) 你似乎已经连接了？状态 " + hRespWeb.StatusCode;
                        return false;
                        //throw new Exception("Status Code Invalid , code=" + hRespWeb.StatusCode);
                    }
                }
            }
            catch (Exception e)
            {
                LastErrorMsg = "(2/10) 找不到登录服务器，请尝试重启路由器";
                logger.log("[SnkHubei] [Error] Redir " + e.Message);
            }
            return false;
        }
    }
}
