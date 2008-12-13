namespace CHSNS {
	/// <summary>
	/// 用户角色类型
	/// </summary>
	public enum RoleType {
		/// <summary>
		/// 网站创建者
		/// </summary>
		Creater = 255,
		/// <summary>
		/// 网站编辑
		/// </summary>
		Editor = 200,
		/// <summary>
		/// 网站一般用户
		/// </summary>
		General = 1,
		/// <summary>
		/// 锁定用户
		/// </summary>
		Locked = -1,
	}
}
