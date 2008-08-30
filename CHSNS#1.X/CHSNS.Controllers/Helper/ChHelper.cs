using CHSNS.Config;
using CHSNS.Data;
namespace CHSNS.Helper {
	public class ChHelper {
		public SiteConfig ChSite {
			get {
				return SiteConfig.Current;
			}
		}
		public CHSNSUser User{
			get {
				return CHSNSUser.Current;
			}
		}
		public Path Path {
			get {
				return CHSNS.Path.Current;
			}
		}
		StringHelper _str;
		public StringHelper Str {
			get {
				if (_str == null)
					_str = new StringHelper();
				return _str;
			}
		}
		public DataSetCache DataCache {
			get {
				return DataSetCache.Current;

			}
		}
		DBExt _db;
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
