using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace CHSNS.SystemApplication {
	public class BaseInfo : ISystemApplication {
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

		#endregion

		#region IBaseApplication 成员

		public string GUID {
			get { return "{1058FEDC-D819-4f0f-B359-7E635ABBA52F}"; }
		}

		public string Name {
			get { return "基本信息"; }
		}

		public string Version {
			get { 
				return "v1.0"; }
		}
		public string ControllerName {
			get {
				return "BaseInfo";
			}
		}



		public int Position {
			get { return 1; }
		}



		public string Description {
			get { return "基本信息"; }
		}

		#endregion

	}
}
