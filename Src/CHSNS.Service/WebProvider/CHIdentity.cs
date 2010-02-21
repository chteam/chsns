using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace CHSNS
{
public 	class CHIdentity:IIdentity
	{
		#region IIdentity Members

	public string AuthenticationType
	{
		get;
		set;
	}

	public bool IsAuthenticated
	{
		get;
		set;
	}

	public string Name
	{
		get;
		set;
	}

		#endregion
	}
}
