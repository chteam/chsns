using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace CHSNS.SystemApplication {

	public class FaceInfo : ISystemApplication {
		Assembly Ass{
			get{
				return  Assembly.GetExecutingAssembly();
			}
		}
		#region ISystemApplication 成员

		public Dictionary<string, string> PositionView {
			get {
				throw new NotImplementedException();
			}
		}

		public string GUID {
			get { return "{0E851E00-63B3-4854-B000-AF0DDDCD3607}"; }
		}

		public string Name {
			get { return "头像"; }
		}

		public string Version {
			get { 
				return "v1.0"; }
		}
		public string BaseViewFolder {
			get {
				return "FaceInfo";
			}
		}

		public string Description {
			get { return "头像信息设置与显示"; }
		}

		public int Position {
			get { return 1; }
		}

		#endregion
	}
}
