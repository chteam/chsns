using System;
using System.Collections.Generic;
using System.Text;

namespace Chsword.Reader {
	public class ServerResponse : Interface.IServerResponse {
		string _count;
		string _ResponseText;
		public string Count {
			get { return _count; }
			set { _count = value; }
		}

		public string ResponseText {
			get { return _ResponseText; }
			set { _ResponseText = value; }
		}

	}
}
