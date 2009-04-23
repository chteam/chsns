/*
* 
* http协议操作模块：简化了 Get和Post请求。
* 
* */
using System.IO;

namespace CHSNS {
	using System;
	using System.Net;

	/// <summary>
	/// HttpProc 的摘要说明。
	/// </summary>
	public class HttpProc {
		/// <summary>
		/// 创建请求
		/// </summary>
		/// <returns>请求对象</returns>
		private HttpWebRequest CreateRequest() {
			HttpWebRequest 请求;

			请求 = (HttpWebRequest)HttpWebRequest.Create(_strUrl);//创建请求
			请求.Accept = "*/*"; //接受任意文件
			请求.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.1.4322)"; // 模拟使用IE在浏览
			//请求.AllowAutoRedirect = false;//这里不允许302
			请求.CookieContainer = new CookieContainer();//cookie容器，
			请求.Referer = this.strRefUrl; //当前页面的引用

            请求.Headers["Accept-Language"] = "	zh-cn,zh;q=0.5";   
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
			if (this._cookiePost != null) {
				System.Uri u = new Uri(_strUrl);
				//doenet处理cookie的bug：请求的服务器和cookie的Host必须一直，否则不发送或获取！

				//这里修改成一致！
				foreach (System.Net.Cookie c in _cookiePost) {
					c.Domain = u.Host;
				}

				请求.CookieContainer.Add(_cookiePost);
			}

			//如果需要发送数据，就以Post方式发送
			if (_strPostdata != null && _strPostdata.Length > 0) {
				请求.ContentType = "application/x-www-form-urlencoded";//作为表单请求
				请求.Method = "POST";//方式就是Post

				//发送http数据：朝请求流中写post的数据
				byte[] b = this._encoding.GetBytes(this._strPostdata);
				请求.ContentLength = b.Length;
				Stream sw = null;
				try {
					sw = 请求.GetRequestStream();
					sw.Write(b, 0, b.Length);
				} catch (System.Exception ex) {
					this._strErr = ex.Message;
				} finally {
					if (sw != null) { sw.Close(); }
				}

			}
			return 请求; //返回创建的请求对象

		}

		/// <summary>
		/// 处理请求
		/// </summary>
		/// <returns>返回当前处理的文本</returns>
		public string Proc() {

			HttpWebRequest 请求 = CreateRequest();//请求
			HttpWebResponse 响应 = null; ;

		StreamReader sr = null;


			try {
				//这里得到响应

				响应 = (HttpWebResponse)请求.GetResponse();

				sr = new StreamReader(响应.GetResponseStream(), this.encoding);

				this._ResHtml = sr.ReadToEnd(); // 这里假定响应的都是html文本
			} catch (System.Exception ex) {
				this._strErr = ex.Message;//发生错误就返回空文本
				return "";
			} finally {
				if (sr != null) { sr.Close(); }
			}
			//状态码
			this._strCode = 响应.StatusCode.ToString();

			if (this._strCode == "302") //如果是302重定向的话就返回新的地址。
                        {
				this._ResHtml = 响应.Headers["location"];
			}

			//得到cookie
			if (响应.Cookies.Count > 0) {
				this._cookieGet=(响应.Cookies); //得到新的cookie：注意这里没考虑cookie合并的情况
			}
			return this.ResHtml;
		}

		/// <summary>
		/// 加载验证码
		/// </summary>
		/// <returns>验证码的图象</returns>
		public System.Drawing.Image LoadPWDext() {
	//	this.strUrl = "验证码URL";
			System.Drawing.Image img = null;
			HttpWebRequest 请求 = CreateRequest();
			HttpWebResponse 响应; ;
			try {
				响应 = (HttpWebResponse)请求.GetResponse();
				img = System.Drawing.Image.FromStream(响应.GetResponseStream());//直接作为stream创建图象。
				//得到cookie
			    if (响应.Cookies.Count > 0)
			    {
			        _cookieGet = 响应.Cookies;
			    }
			}
			catch (Exception ex)
			{
			    Console.WriteLine(ex.Message);
			}
		    return img;
		}


		#region 构造函数
		public HttpProc() {
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="地址">发送的地址</param>
		/// <param name="要发送的cookie">要发送cookies集合</param>
		public HttpProc(string 地址, CookieCollection 要发送的cookie)
		{
		    _strUrl = 地址;
		    _cookiePost = 要发送的cookie;
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="地址">发送的地址</param>
		/// <param name="发送数据">要发送的数据</param>
		public HttpProc(string 地址, string 发送数据)
		{
		    _strUrl = 地址;
		    _strPostdata = 发送数据;

		}


		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="地址">发送的地址</param>
		public HttpProc(string 地址) {
			_strUrl = 地址;
		}


		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="地址">发送的地址</param>
		/// <param name="发送数据">要发送的数据</param>
		/// <param name="要发送的cookie">要发送cookies集合</param>
		public HttpProc(string 地址, string 发送数据, CookieCollection 要发送的cookie)
		{
		    _strUrl = 地址;
		    _strPostdata = 发送数据;
		    _cookiePost = 要发送的cookie;
		}
		#endregion

		#region 地址
		private string _strUrl;
		/// <summary>
		/// 请求http的地址
		/// </summary>
		public string strUrl {
			get {
				return _strUrl;
			}
			set {
				_strUrl = value;
			}
		}
		#endregion

		#region 来源地址
		private string _strRefUrl;
		/// <summary>
		/// 当前页面的引用地址
		/// </summary>
		public string strRefUrl {
			get {
				return _strRefUrl;
			}
			set {
				_strRefUrl = value;
			}
		}
		#endregion

		#region 数据
		private string _strPostdata;
		/// <summary>
		/// 发送出去的数据
		/// </summary>
		public string strPostdata {
			get { return _strPostdata; }
			set { _strPostdata = value; }
		}
		#endregion

		#region 要发送的cookie集合
		private CookieCollection _cookiePost;
		/// <summary>
		/// 发送的cookie集合
		/// </summary>
		public CookieCollection cookiePost {
			get {
				return _cookiePost;
			}
			set { _cookiePost = value; }
		}
		#endregion

		#region 获取的cookie集合
		private CookieCollection _cookieGet = new CookieCollection();
		/// <summary>
		/// 发送的cookie集合
		/// </summary>
		public CookieCollection cookieGet {
			get {
				return _cookieGet;
			}
			//set {
			//    _cookieGet = value;
			//}
		}
		#endregion

		#region 代理

	    /// <summary>
	    /// 代理服务器
	    /// </summary>
	    public IWebProxy Proxy { get; set; }

	    #endregion

		#region 是否发送成功
		private bool _succeed;
		/// <summary>
		/// 是否执行成功
		/// </summary>
		public bool succeed {
			get { return _succeed; }
			set { _succeed = value; }
		}
		#endregion

		#region 响应的html结果
		private string _ResHtml;
		/// <summary>
		/// 返回的html结果，以文本方式
		/// </summary>
		public string ResHtml {
			get {

				return _ResHtml;


			}
		}
		#endregion

		#region 响应码
		private string _strCode;
		/// <summary>
		/// 响应代码
		/// </summary>
		public string strCode {
			get { return _strCode; }
			set { _strCode = value; }
		}
		#endregion

		#region 错误文本
		private string _strErr;
		/// <summary>
		/// 错误文本
		/// </summary>
		public string strErr {
			get { return _strErr; }
			set { _strErr = value; }
		}
		#endregion

		#region 编码
		private System.Text.Encoding _encoding = System.Text.Encoding.Default;
		public System.Text.Encoding encoding {
			get { return _encoding; }
			set { _encoding = value; }
		}
		#endregion

	}
}

