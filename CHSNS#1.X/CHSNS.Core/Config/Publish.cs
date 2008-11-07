
namespace CHSNS.Config
{
	using System;
	public class Publish
	{
		public string Body { get; set; }

		DateTime _addTime = DateTime.Now;
		
		public DateTime AddTime {
			get { return _addTime; }
			set { _addTime = value; }
		}

		public bool IsShow { get; set; }
	}
}
