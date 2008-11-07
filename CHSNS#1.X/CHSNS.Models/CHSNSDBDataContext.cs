using System;
using System.Data.EntityClient;


namespace CHSNS.Models {
	public class CHSNSDBDataContext : CHSNSDBEntities {
		public CHSNSDBDataContext(string s) : base(s) { }
		public CHSNSDBDataContext(EntityConnection connection) : base(connection) { }

		public Guid NEWID() {
			return Guid.NewGuid();
		}
	}
}


