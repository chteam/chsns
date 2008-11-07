namespace CHSNS.HttpHandler
{
	/// <summary>
	/// Compression HttpHandler
	/// </summary>
	public class CompressionHttpHandler : System.Web.IHttpHandler
	{
		#region private object
		private const string GZIP = "gzip";
		private const string DEFLATE = "deflate";
		#endregion

		#region IHttpHandler 成员
		/// <summary>
		/// true
		/// </summary>
		public bool IsReusable
		{
			get { return true; }
		}
		/// <summary>
		/// process request
		/// </summary>
		/// <param name="context"></param>
		public void ProcessRequest(System.Web.HttpContext context)
		{
			string filepath = context.Request.FilePath;
			filepath = filepath.Substring(0, filepath.LastIndexOf("."));
			filepath = context.Server.MapPath(filepath);//转成本地路径

			if (IsEncodingAccepted(GZIP, context))
			{
				filepath += ".gz";
				SetEncoding(GZIP, context);
			}
			else
			{
				if (IsEncodingAccepted(DEFLATE, context))
				{
					filepath += ".de";
					SetEncoding(DEFLATE, context);
				}
			}
			if (System.IO.File.Exists(filepath))
				context.Response.WriteFile(filepath);
		}
		#endregion

		#region static methods
		/// <summary>
		/// 判断浏览器是否支持指定的压缩
		/// </summary>
		/// <param name="encoding"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		static public bool IsEncodingAccepted(string encoding, System.Web.HttpContext context)
		{
			if (context != null)
				return context.Request.Headers["Accept-encoding"] != null && context.Request.Headers["Accept-encoding"].Contains(encoding);
			return false;
		}
		/// <summary>
		/// 设置浏览器当前的压缩类型
		/// </summary>
		/// <param name="encoding"></param>
		/// <param name="context"></param>
		static public void SetEncoding(string encoding, System.Web.HttpContext context)
		{
			if (context != null)
				context.Response.AppendHeader("Content-encoding", encoding);
		}
		#endregion
	}
}