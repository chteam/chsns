using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CHSNS {
	public class SingletonApplication<T> : ISingleton<T> where T : class, new() {
		string _SingletonString;
		public SingletonApplication(string singletonString) {
			_SingletonString = singletonString;
		}
		public T Value {
			get {
				if (HttpContext.Current.Application[SingletonString] == null) {
					HttpContext.Current.Application.Lock();
					HttpContext.Current.Application[SingletonString] = new T();
					HttpContext.Current.Application.UnLock();
				}
				return HttpContext.Current.Application[SingletonString] as T;
			}
			set {
				HttpContext.Current.Application[SingletonString] = value;
			}
		}
		public string SingletonString {
			get { return _SingletonString; }
		}
	}
}

