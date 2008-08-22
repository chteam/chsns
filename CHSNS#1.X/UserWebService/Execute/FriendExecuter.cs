using System;
using CHSNS;

namespace Chsword.Execute {
	/// <summary>
	/// 对好友进行操作
	/// </summary>
	public class FriendExecuter:Reader.Databases,Interface.IItems {
		private long _fromid;
		private long _toid;
		public FriendExecuter(long fromid, long toid) {
			_fromid = fromid;
			_toid = toid;
		}

		#region IItems 成员
		/// <summary>
		/// 添加好友，加好友的确认
		/// </summary>
		/// <returns></returns>
		string Chsword.Interface.IItems.Add() {
			if (_toid<10000)
				return "error:网络传输意外(From Chsword.InterFace.IItem.Add)";
			if(_toid==_fromid)
				return "error:不能加自己为好友";
			short gt = DoFriend("Friend_Add");
			switch (gt) { 
				case 9:
					return "error:对方好友已满";
				case 8:
					return "error:本人好友已满";
				case 1:
					Message.SendMessageHtml(_fromid,
						_toid,
						CHUser.Username + "已经同意加你为好友",
						CHUser.Username + "已经同意加你为好友"
						);
					return string.Empty;
				case 2:
					Message.SendMessageHtml(_fromid,
						_toid,
						CHUser.Username + "申请加你为好友",
						string.Format(
						ChCache.GetConfig("Message", "ApplyFriend"),
						CHUser.Username,
						_fromid)
						);
					return string.Empty;
				case 3:
				case 7:
					return string.Empty;
				default:
					return "error:未知的数据库意外";
			}
		}
		/// <summary>
		/// 解除好友关系
		/// </summary>
		/// <returns></returns>
		string Chsword.Interface.IItems.Remove() {
			if (_toid < 10000 && _toid != 0)
				return "error:网络传输意外(From Chsword.InterFace.IItem.Remove)";
			short gt = DoFriend("Friend_Remove");
			switch (gt) {
				case 1:
					return string.Empty;
				default:
					return "error:未知的数据库意外";
			}
		}
		/// <summary>
		/// 升级为特别好友
		/// </summary>
		/// <returns></returns>
		string Chsword.Interface.IItems.Update() {
			if (_toid < 10000)
				return "error:网络传输意外(From Chsword.InterFace.IItem.Update)";
			throw new Exception("The method or operation is not implemented.");
		}
		/// <summary>
		/// 从特别好友降级
		/// </summary>
		/// <returns></returns>
		string Chsword.Interface.IItems.Update2() {
			if (_toid < 10000)
				return "error:网络传输意外(From Chsword.InterFace.IItem.unUpdate)";
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion
		/// <summary>
		/// 处理好友，对数据库操作
		/// </summary>
		/// <param name="StoredProcedure">数据库的存储过程名</param>
		/// <returns></returns>
		short DoFriend(string StoredProcedure) {
			short result = 0;
			if (short.TryParse(GetObjectbyId2(_fromid, "@fromid", _toid, "@toid", StoredProcedure).ToString(),out result))
				return result ;
			else
				return 0;
		}

	}
}
