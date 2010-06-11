using System;
using System.Security.Principal;

namespace CHSNS
{
	public class CHPrincipal : IPrincipal
	{
		#region IPrincipal Members

		public IIdentity Identity
		{
			get;
			set;
		}

		public bool IsInRole(string role)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
