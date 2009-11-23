namespace CHSNS
{
	///<summary>
	/// ICHSNSDB接口
	///</summary>
	public interface ICHSNSDB
	{
		///<summary>要实现DataBaseExecutor方法
		///</summary>
		DataBaseExecutor DataBaseExecutor { get; set; }
	}
}