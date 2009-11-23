using System.Collections;
using System.Security.Permissions;
using System.Web;

namespace CHSNS
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	[AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public interface IPagedList : IEnumerable {
		bool HasPreviousPage { get; }
		bool HasNextPage { get; }
		int TotalPages { get; }
		int CurrentPage { get; set; }
		int PageSize { get; set; }
		int TotalCount { get; set; }
	}
}