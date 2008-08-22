using System;
using CHSNS;

namespace Chsword.Execute {
	/// <summary>
	/// �Ժ��ѽ��в���
	/// </summary>
	public class FriendExecuter:Reader.Databases,Interface.IItems {
		private long _fromid;
		private long _toid;
		public FriendExecuter(long fromid, long toid) {
			_fromid = fromid;
			_toid = toid;
		}

		#region IItems ��Ա
		/// <summary>
		/// ��Ӻ��ѣ��Ӻ��ѵ�ȷ��
		/// </summary>
		/// <returns></returns>
		string Chsword.Interface.IItems.Add() {
			if (_toid<10000)
				return "error:���紫������(From Chsword.InterFace.IItem.Add)";
			if(_toid==_fromid)
				return "error:���ܼ��Լ�Ϊ����";
			short gt = DoFriend("Friend_Add");
			switch (gt) { 
				case 9:
					return "error:�Է���������";
				case 8:
					return "error:���˺�������";
				case 1:
					Message.SendMessageHtml(_fromid,
						_toid,
						CHUser.Username + "�Ѿ�ͬ�����Ϊ����",
						CHUser.Username + "�Ѿ�ͬ�����Ϊ����"
						);
					return string.Empty;
				case 2:
					Message.SendMessageHtml(_fromid,
						_toid,
						CHUser.Username + "�������Ϊ����",
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
					return "error:δ֪�����ݿ�����";
			}
		}
		/// <summary>
		/// ������ѹ�ϵ
		/// </summary>
		/// <returns></returns>
		string Chsword.Interface.IItems.Remove() {
			if (_toid < 10000 && _toid != 0)
				return "error:���紫������(From Chsword.InterFace.IItem.Remove)";
			short gt = DoFriend("Friend_Remove");
			switch (gt) {
				case 1:
					return string.Empty;
				default:
					return "error:δ֪�����ݿ�����";
			}
		}
		/// <summary>
		/// ����Ϊ�ر����
		/// </summary>
		/// <returns></returns>
		string Chsword.Interface.IItems.Update() {
			if (_toid < 10000)
				return "error:���紫������(From Chsword.InterFace.IItem.Update)";
			throw new Exception("The method or operation is not implemented.");
		}
		/// <summary>
		/// ���ر���ѽ���
		/// </summary>
		/// <returns></returns>
		string Chsword.Interface.IItems.Update2() {
			if (_toid < 10000)
				return "error:���紫������(From Chsword.InterFace.IItem.unUpdate)";
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion
		/// <summary>
		/// ������ѣ������ݿ����
		/// </summary>
		/// <param name="StoredProcedure">���ݿ�Ĵ洢������</param>
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
