namespace CHSNS.Service {
	/// <summary>
	/// 中介者
	/// </summary>
	public interface IService {
		IDBManager DBExt { get; set; }
	//	DataBaseExecutor DataBaseExecutor { get; set; }
	}
}
