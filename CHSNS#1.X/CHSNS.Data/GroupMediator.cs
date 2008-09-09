using System.Collections.Generic;
using System.Data;
using CHSNS.Models;

namespace CHSNS.Data {
	public class GroupMediator :BaseMediator {
		public GroupMediator(DBExt id) : base(id) { }
		/// <summary>
		/// 群订阅的信息
		/// </summary>
		/// <param name="count">返回多少条</param>
		/// <returns></returns>
		public DataRowCollection TakeIns(int count){
			return DataBaseExecutor.GetRows("RssList",
				"@userid", CHSNSUser.Current.UserID,
				"@page", 1,
				"@everypage", count,
				"@GroupClass", 0);
		}

	}
}
