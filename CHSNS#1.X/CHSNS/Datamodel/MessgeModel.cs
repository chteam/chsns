using System;
using System.Collections.Generic;
using System.Text;

namespace Chsword.Datamodel {
	public class MessageModel {
		long _Messageid;
		long _Fromid;
		long _Toid;
		string _name;
		string _Title;
		string _Body;
		bool _Issent;//是不是我发的
		DateTime _Sendtime;
		bool _Ishtml;

		public string Body {
			get {	
				return _Body;
			}
			set {
				_Body = value;
			}
		}
		public long Fromid {
			get {
				return _Fromid;
			}
			set {
				_Fromid = value;
			}
		}
		public bool Ishtml {
			get {
				return _Ishtml;
			}
			set {
				_Ishtml = value;
			}
		}
		public bool Issent {
			get {
				return _Issent;
			}
			set {
				_Issent = value;
			}
		}
		public long Messageid {
			get {
				return _Messageid;
			}
			set {
				_Messageid = value;
			}
		}
		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}
		public DateTime Sendtime {
			get {
				return _Sendtime;
			}
			set {
				_Sendtime = value;
			}
		}
		public string Title {
			get {
				return _Title;
			}
			set {
				_Title = value;
			}
		}
		public long Toid {
			get {
				return _Toid;
			}
			set {
				_Toid = value;
			}
		}

	}
}
