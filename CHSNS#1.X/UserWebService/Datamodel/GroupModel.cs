using System;
using System.Collections.Generic;
using System.Text;

namespace Chsword.Datamodel {
	public class GroupModel  {
		long _groupid;
		private string _Groupname;
		private string _summmary;
		private long _CreateUserid;
		private string _Publish;
		private byte _GroupClass;
		private int _AdminCount;
		private long _LogCount;
		private long _ViewCount;
		private long _MaxUserCount;
		byte _JoinLevel;
		private byte _ShowLevel;
		private string _MagicBox;
		private long _UserCount;
		string _LogoUrl;
		DateTime _addtime;
		string _Other0;
		long _Num0;
		string _Other1; string _Other2;
		int _Relation;
		int _UserLevel;
		long _ViewUserid;
		bool _IsRss;

		bool _Exists = true;//群是否存在

		long _category = 0;

		public long Category {
			get { return _category; }
			set { _category = value; }
		}
		/// <summary>
		/// 当前群是否存在
		/// </summary>
		public bool Exists {
			get {
				return _Exists;
			}
			set {
				_Exists = value;
			}
		}
		public bool IsRss {
			get {
				return _IsRss;
			}
			set {
				_IsRss = value;
			}
		}
		public byte Joinlevel {
			get { return _JoinLevel; }
			set { _JoinLevel = value; }
		}



		public int Relation {
			get {
				return _Relation;
			}
			set {
				_Relation = value;
			}
		}
		public byte Showlevel {
			get { return _ShowLevel; }
			set { _ShowLevel = value; }
		}


		public long UserCount {
			get { return _UserCount; }
			set { _UserCount = value; }
		}



		public string MagicBox {
			get { return _MagicBox; }
			set { _MagicBox = value; }
		}


		public string LogoUrl {
			get { return _LogoUrl; }
			set { _LogoUrl = value; }
		}

		public DateTime Addtime {
			get { return _addtime; }
			set { _addtime = value; }
		}


		public long Num0 {
			get { return _Num0; }
			set { _Num0 = value; }
		}


		public string Other0 {
			get { return _Other0; }
			set { _Other0 = value; }
		}


		public string Other1 {
			get { return _Other1; }
			set { _Other1 = value; }
		}

		public string Other2 {
			get { return _Other2; }
			set { _Other2 = value; }
		}
		public long Groupid {
			get { return _groupid; }
			set { _groupid = value; }
		}

		public string Groupname
		{
			get { return _Groupname; }
			set { _Groupname = value; }
		}

		public string Summmary {
			get { return _summmary; }
			set { _summmary = value; }
		}

		public long CreateUserid {
			get { return _CreateUserid; }
			set { _CreateUserid = value; }
		}

		public string Publish {
			get { return _Publish; }
			set { _Publish = value; }
		}

		public byte GroupClass {
			get { return _GroupClass; }
			set { _GroupClass = value; }
		}

		public int AdminCount {
			get { return _AdminCount; }
			set { _AdminCount = value; }
		}

		public long LogCount {
			get { return _LogCount; }
			set { _LogCount = value; }
		}

		public int UserLevel {
			get {
				return _UserLevel;
			}
			set {
				_UserLevel = value;
			}
		}
		public long ViewCount {
			get { return _ViewCount; }
			set { _ViewCount = value; }
		}

		public long MaxUserCount {
			get { return _MaxUserCount; }
			set { _MaxUserCount = value; }
		}
		public long ViewUserid {
			get {
				return _ViewUserid;
			}
			set {
				_ViewUserid = value;
			}
		}
	}
}
