using System;
using System.Web.Mvc;

namespace CHSNS
{
	public interface IDataBinder
	{
		object ExtractValue(string target, ViewContext context);
		IDisposable NestedBindingScope(object rootDataItem);
	}
}