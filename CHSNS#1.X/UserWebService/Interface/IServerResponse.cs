using System;

namespace Chsword.Interface {
	public interface IServerResponse {
		string Count {
			get;
			set;
		}
		string ResponseText {
			get;
			set;
		}
	}
}
