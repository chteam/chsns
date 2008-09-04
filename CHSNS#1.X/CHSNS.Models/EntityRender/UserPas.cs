using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CHSNS;
namespace CHSNS.Models {
	public class UserPas {
		long _ownerID = 0;

		public long OwnerID {
			get {
				if (_ownerID == 0)
					_ownerID = CHSNSUser.Current.UserID;
				return _ownerID;
			}
			set { _ownerID = value; }
		}
		public string OwnerName {
			get {
				return User.Field<string>("name");
			}
		}
		public long ViewerID { get; set; }
		bool? _exists = null;
		public bool Exists {
			get {
				if (_exists == null) {
					return !(this.OwnerID < 10000 || User == null);
				}
				return _exists.Value;
			}
		}
		public DataRow User { get; set; }
		bool? _hasright = null;
		public bool HasRight {
			get {
				if (_hasright == null)
					_hasright = (User != null
					&& (User.Field<byte>("Relation") >= User.Field<byte>("AllShowLevel")
					|| CHUser.IsAdmin));

				return _hasright.Value;
			}
		}
		public bool IsMagicBox {
			get {
				return User.Field<Boolean>("isMagicBox");
			}
		}
		public bool IsMe { get { return OwnerID == ViewerID; } }
		public bool IsOnline { get; set; }
	}
}
