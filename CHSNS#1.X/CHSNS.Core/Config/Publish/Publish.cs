
namespace CHSNS.Config
{
	using System;
	public class Publish
	{
		string _body;

		public string Body {
			get { return _body; }
			set { _body = value; }
		}
		DateTime _addTime = DateTime.Now;

		public DateTime AddTime {
			get { return _addTime; }
			set { _addTime = value; }
		}
		bool _isShow = false;

		public bool IsShow {
			get { return _isShow; }
			set { _isShow = value; }
		}

	}
}
