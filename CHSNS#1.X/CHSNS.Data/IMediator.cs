namespace CHSNS.Data {
	/// <summary>
	/// 中介者
	/// </summary>
	public interface IMediator {
		DBExt DBExt { get; set; }
		DataBaseExecutor DataBaseExecutor { get; set; }
	}
}
