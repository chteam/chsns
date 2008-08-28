using System;
using System.Text;
using CHSNS;
using Chsword;
namespace Chsword.Reader {
	public class NewGroup : Databases, Interface.IShowAll {
		string GetMyJiFen() {
			return base.GetObjectbyId1(CHUser.UserID, "@userid", "GetScore").ToString();
		}

		#region IShowAll ≥…‘±
		public string ShowAll(string Items, int NowPage) {
			StringBuilder sbout = new StringBuilder(CHCache.GetTemplateCache("NewGroup"));
			sbout.Replace("$Jifen$", GetMyJiFen());
			DataSetCache dc = new DataSetCache();
			sbout.Replace("$category$", dc.GroupCategory_List());
			return sbout.ToString();
		}
		#endregion
	}
}
