/*
* 
* http协议操作模块：简化了 Get和Post请求。
* 
* */
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;

namespace CHSNS
{
    /// <summary>
    /// HttpProc 的摘要说明。
    /// </summary>
    public class HttpProc
    {
        /// <summary>
        /// 创建请求
        /// </summary>
        /// <returns>请求对象</returns>
        private HttpWebRequest CreateRequest()
        {
            var request = (HttpWebRequest) WebRequest.Create(StrUrl);
            request.Accept = "*/*"; //接受任意文件
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.1.4322)"; // 模拟使用IE在浏览
            //请求.AllowAutoRedirect = false;//这里不允许302
            request.CookieContainer = new CookieContainer(); //cookie容器，
            request.Referer = StrRefUrl; //当前页面的引用

            request.Headers["Accept-Language"] = "	zh-cn,zh;q=0.5";
            //使用代理
            //WebProxy myProxy = new WebProxy();
            //if (config.Proxy_DEF != "0") {
            //    //使用浏览器的代理
            //    myProxy = (WebProxy)请求.Proxy;
            //    //Console.WriteLine("\nThe actual default Proxy settings are {0}",myProxy.Address);

            //} else {
            //    //使用自定的代码
            //    myProxy.Address = new Uri(String.Format("http://{0}:{1}", config.Proxy_Server, config.Proxy_Port));

            //    myProxy.Credentials = new NetworkCredential(username, password);
            //    if (config.Proxy_Username.Length > 0 & config.Proxy_Pass.Length > 0) {
            //        myProxy.Credentials = new NetworkCredential(config.Proxy_Username, config.Proxy_Pass);
            //    }

            //    请求.Proxy = myProxy;
            //}

            //Console.WriteLine("\nThe Address of the  new Proxy settings are {0}",myProxy.Address);


            //如果附带cookie 就发送
            if (CookiePost != null)
            {
                var u = new Uri(StrUrl);
                //doenet处理cookie的bug：请求的服务器和cookie的Host必须一直，否则不发送或获取！

                //这里修改成一致！
                foreach (Cookie c in CookiePost)
                {
                    c.Domain = u.Host;
                }

                request.CookieContainer.Add(CookiePost);
            }

            //如果需要发送数据，就以Post方式发送
            if (!string.IsNullOrEmpty(StrPostdata))
            {
                request.ContentType = "application/x-www-form-urlencoded"; //作为表单请求
                request.Method = "POST"; //方式就是Post

                //发送http数据：朝请求流中写post的数据
                byte[] b = Encoding.GetBytes(StrPostdata);
                request.ContentLength = b.Length;
                Stream sw = null;
                try
                {
                    sw = request.GetRequestStream();
                    sw.Write(b, 0, b.Length);
                }
                catch (Exception ex)
                {
                    StrErr = ex.Message;
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                    }
                }
            }
            return request; //返回创建的请求对象
        }

        /// <summary>
        /// 处理请求
        /// </summary>
        /// <returns>返回当前处理的文本</returns>
        public string Proc()
        {
            var request = CreateRequest(); //请求
            HttpWebResponse response;
            StreamReader sr = null;
            try
            {
                //这里得到响
                response = (HttpWebResponse) request.GetResponse();
                sr = new StreamReader(response.GetResponseStream(), Encoding);
                ResHtml = sr.ReadToEnd(); // 这里假定响应的都是html文本
            }
            catch (Exception ex)
            {
                StrErr = ex.Message; //发生错误就返回空文本
                return "";
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
            //状态码
            StrCode = response.StatusCode.ToString();

            if (StrCode == "302") //如果是302重定向的话就返回新的地址。
            {
                ResHtml = response.Headers["location"];
            }

            //得到cookie
            if (response.Cookies.Count > 0)
            {
                CookieGet = (response.Cookies); //得到新的cookie：注意这里没考虑cookie合并的情况
            }
            return ResHtml;
        }

        /// <summary>
        /// 加载验证码
        /// </summary>
        /// <returns>验证码的图象</returns>
        public Image LoadPwDext()
        {
            //	this.StrUrl = "验证码URL";
            Image img = null;
            HttpWebRequest request = CreateRequest();
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse) request.GetResponse();
                img = Image.FromStream(response.GetResponseStream()); //直接作为stream创建图象。
                //得到cookie
                if (response.Cookies.Count > 0)
                {
                    CookieGet = response.Cookies;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return img;
        }


        public HttpProc()
        {
            CookieGet = new CookieCollection();
            Encoding = Encoding.Default;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">发送的地址</param>
        /// <param name="sentCookie">要发送cookies集合</param>
        public HttpProc(string url, CookieCollection sentCookie)
        {
            CookieGet = new CookieCollection();
            Encoding = Encoding.Default;
            StrUrl = url;
            CookiePost = sentCookie;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">发送的地址</param>
        /// <param name="postData">要发送的数据</param>
        public HttpProc(string url, string postData)
        {
            CookieGet = new CookieCollection();
            Encoding = Encoding.Default;
            StrUrl = url;
            StrPostdata = postData;
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">发送的地址</param>
        public HttpProc(string url)
        {
            CookieGet = new CookieCollection();
            Encoding = Encoding.Default;
            StrUrl = url;
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">发送的地址</param>
        /// <param name="postData">要发送的数据</param>
        /// <param name="cookiePost">要发送cookies集合</param>
        public HttpProc(string url, string postData, CookieCollection cookiePost)
        {
            CookieGet = new CookieCollection();
            Encoding = Encoding.Default;
            StrUrl = url;
            StrPostdata = postData;
            CookiePost = cookiePost;
        }


        /// <summary>
        /// 请求http的地址
        /// </summary>
        public string StrUrl { get; set; }


        /// <summary>
        /// 当前页面的引用地址
        /// </summary>
        public string StrRefUrl { get; set; }


        /// <summary>
        /// 发送出去的数据
        /// </summary>
        public string StrPostdata { get; set; }


        /// <summary>
        /// 发送的cookie集合
        /// </summary>
        public CookieCollection CookiePost { get; set; }


        /// <summary>
        /// 发送的cookie集合
        /// </summary>
        public CookieCollection CookieGet { get; set; }

        /// <summary>
        /// 代理服务器
        /// </summary>
        public IWebProxy Proxy { get; set; }


        /// <summary>
        /// 是否执行成功
        /// </summary>
        public bool Succeed { get; set; }


        /// <summary>
        /// 返回的html结果，以文本方式
        /// </summary>
        public string ResHtml { get; set; }


        /// <summary>
        /// 响应代码
        /// </summary>
        public string StrCode { get; set; }


        /// <summary>
        /// 错误文本
        /// </summary>
        public string StrErr { get; set; }


        public Encoding Encoding { get; set; }
    }
}

