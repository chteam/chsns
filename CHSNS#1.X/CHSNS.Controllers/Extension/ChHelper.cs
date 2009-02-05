using CHSNS.Config;
using CHSNS.Data;
namespace CHSNS.Helper {
	public class ChHelper {
		public SiteConfig ChSite {
			get {
				return SiteConfig.Current;
			}
		}

		public Path Path {
			get {
				return CHSNS.Path.Current;
			}
		}


		DBExt _db;
		public DBExt DB {
			get {
				if (_db == null)
					_db = new DBExt();
				return _db;
			}
		}

	}
}
