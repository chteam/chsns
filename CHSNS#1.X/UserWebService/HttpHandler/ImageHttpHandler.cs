namespace ChAlumna
{
	using System;
	using System.Web;
	using ChAlumna.Models;
	using ChAlumna.Config;

    public class ImageHttpHandler : IHttpHandler
    {
        #region IHttpHandler ��Ա

        public bool IsReusable {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context) {
            string FileName = context.Server.MapPath(context.Request.FilePath);
            if (context.Request.UrlReferrer == null
                || string.IsNullOrEmpty(context.Request.UrlReferrer.Host)) {
                context.Response.ContentType = "image/JPEG";
                context.Response.WriteFile("~/images/no.gif");//���滻ͼƬ
            } else {
                if (context.Request.UrlReferrer.Host.IndexOf(SiteConfig.Currect.BaseConfig.Domain) > -1) {
                    //�������������
                    context.Response.ContentType = "image/JPEG";
                    context.Response.WriteFile(FileName);
                } else {
                    context.Response.ContentType = "image/JPEG";
                    context.Response.WriteFile("~/images/no.gif");
                }
            }
        }

        #endregion
    }
}
