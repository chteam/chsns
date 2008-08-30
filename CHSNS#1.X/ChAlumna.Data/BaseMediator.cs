namespace CHSNS.Data {
	public class BaseMediator : IMediator {

		#region IMediator 成员
		public BaseMediator(DBExt id) {
			DBExt = id;
			DataBaseExecutor = id.DataBaseExecutor;
		}
		public DBExt DBExt { get; set; }

		public DataBaseExecutor DataBaseExecutor { get; set; }

		#endregion
	}
}
