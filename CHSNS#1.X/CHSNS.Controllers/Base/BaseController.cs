
using System.Web.Mvc;
using System;
using CHSNS.Filter;

namespace CHSNS.Controllers {
	
//	[Helper(typeof(StringHelper),"String")]
	[OnlineFilter]
	abstract public class BaseController : BaseBlockController  {

	}
}