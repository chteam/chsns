namespace CHSNS
{
	public enum ShowType
	{
		/// <summary>
		/// 只有我
		/// </summary>
		保密 = 200,
		/// <summary>
		/// 我的好友
		/// </summary>
		好友 = 150,
		/// <summary>
		/// 同校或同Field
		/// </summary>
		相同Field = 100,
		/// <summary>
		/// 所有同类Field+好友
		/// </summary>
		本站用户 = 50,
		/// <summary>
		/// 所有人,即公开
		/// </summary>
		完全公开 = 0
	}
}