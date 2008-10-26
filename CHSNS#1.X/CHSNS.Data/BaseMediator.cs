namespace CHSNS.Data {
	public class BaseMediator : IMediator {

		#region IMediator 成员
		public BaseMediator(IDBExt id) {
			DBExt = id;
			DataBaseExecutor = id.DataBaseExecutor;
		}
		public IDBExt DBExt { get; set; }

		public DataBaseExecutor DataBaseExecutor { get; set; }

		#endregion
	}
}
