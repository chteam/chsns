using System.Web;

namespace CHSNS {
	[AspNetHostingPermission(System.Security.Permissions.SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	[AspNetHostingPermission(System.Security.Permissions.SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class ListItem {

		public bool Selected {
			get;
			set;
		}

		public string Text {
			get;
			set;
		}

		public string Value {
			get;
			set;
		}
	}
}
