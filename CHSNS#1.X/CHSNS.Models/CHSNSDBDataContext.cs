using System;
using System.Data.EntityClient;
using System.Data.Linq.Mapping;
using System.Reflection;


namespace CHSNS.Models {
	public class CHSNSDBDataContext : CHSNSDBEntities {
		public CHSNSDBDataContext(string s) : base(s) { }
		public CHSNSDBDataContext(EntityConnection connection) : base(connection) { }

		public Guid NEWID() {
			return Guid.NewGuid();
		}
	}
}


