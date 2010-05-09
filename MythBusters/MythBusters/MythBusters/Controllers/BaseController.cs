using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoNei;

namespace MythBusters.Controllers
{
	[SessionKeyFilter]
    public class BaseController : Controller,IXiaoNeiHandler
    {
    	public XiaoNeiApi Api { get; set; }
    	public bool IsDebug { get; set; }
    	public string UserID { get; private set; }
		public XiaoNeiApi GetApi()
		{
            return Api = new XiaoNeiApi("c7f9c729cd74485897f033609083ba75",
                "26e76666962147549ee365330b692b96",
						 Request.QueryString["xn_sig_session_key"], this);
		}

    }
}
