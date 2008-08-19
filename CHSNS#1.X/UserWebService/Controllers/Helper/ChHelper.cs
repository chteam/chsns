namespace ChAlumna
{
	using Castle.MonoRail.Framework.Helpers;
	using ChAlumna.Config;
	using ChAlumna.Data;
	public class ChHelper : AbstractHelper
	{
		public SiteConfig ChSite {
			get {
				return SiteConfig.Currect;
			}
		}
		public ChUser ChUser() {
			return ChAlumna.ChUser.Current;
		}
		public Path Path {
			get {
				return ChAlumna.Path.Current;
			}
		}
		public DataSetCache DataCache {
			get {
				return DataSetCache.Current;

			}
		}
		public MsSqlDB DB {
			get {
				return new MsSqlDB(this.CurrentContext.Session);
			}
		}

	}
}
