using System;

namespace CHSNS.SQLServerImplement {
    internal partial class CHSNSDBDataContext {
		//public CHSNSDBDataContext(string s) : base(s) { }
		//public CHSNSDBDataContext(EntityConnection connection) : base(connection) { }

		public Guid Newid() {
        
			return Guid.NewGuid();
		}
	}
}


