using System;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace CHSNS.Models {
	public partial class CHSNSDBDataContext {
		[Function(Name = "NEWID", IsComposable = true)]
		public Guid NEWID() {
			return ((Guid)(ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod()))).ReturnValue));
		}
	}
}


