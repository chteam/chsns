using CHSNS.Config;
using CHSNS.Data;
namespace CHSNS {
	public class ChHelper {
		public SiteConfig ChSite {
			get {
				return SiteConfig.Current;
			}
		}
		public CHSNSUser ChUser() {
			return CHSNS.CHSNSUser.Current;
		}
		public Path Path {
			get {
				return CHSNS.Path.Current;
			}
		}
		public DataSetCache DataCache {
			get {
				return DataSetCache.Current;

			}
		}
		DBExt _db = null;
		public DBExt DB {
			get {
				if (_db == null)
					_db = new DBExt(
						new DataBaseExecutor(
								new SqlDataOpener(
								SiteConfig.SiteConnectionString)
								));
				return _db;
			}
		}

	}
}
