using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CHSNS;
using CHSNS.Models;
namespace CHSNS.ModelPas {
	public class UserPas {
		long _ownerID = 0;

		public long OwnerID {
			get {
				if (_ownerID == 0)
					_ownerID = CHUser.UserID;
				return _ownerID;
			}
			set { _ownerID = value; }
		}
		public long ViewerID { get; set; }
		bool? _exists = null;
		public bool Exists {
			get {
				if (_exists == null) {
					if (this.OwnerID < 999) return false;
					if (Profile == null) return false;
					if (Profile.ShowLevel > 150) return false;
					return true;
				}
				return _exists.Value;
			}
		}
		public Profile Profile { get; set; }
		public BasicInformation Basic { get; set; }
		public int Relation { get; set; }
		public bool IsMe { get { return OwnerID == ViewerID; } }
		public bool IsOnline { get; set; }
	}
}
