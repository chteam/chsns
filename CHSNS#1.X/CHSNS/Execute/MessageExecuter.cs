using System;
using System.Collections.Generic;
using System.Text;
using CHSNS;
using Chsword.Datamodel;
using System.Data.SqlClient;
using System.Data;

namespace Chsword.Execute
{
	public class MessageExecuter : Interface.IItems
	{
		#region IItems 成员
		MessageModel _MessageModel;
		public string Add() {
			//Chsword.Message m = new Chsword.Message();
			int b = Message.SendMessageText(_MessageModel.Fromid
				, _MessageModel.Toid, _MessageModel.Title, _MessageModel.Body);
			switch (b) {
				case 0:
					return "发信人或收信人不存在";
				case -1:
					return "收信人信箱已满；";
				case 1:
					return "你已经向发了站内信；";
				default:
					return Debug.TraceBack("用户发送邮件时 意外的返回");
			}
		}

		public string Remove() {
			SqlParameter[] p = new SqlParameter[3]{
			new SqlParameter("@messageid", SqlDbType.BigInt),
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@type", SqlDbType.TinyInt)
			};
			p[0].Value = _MessageModel.Messageid;
			p[1].Value = _MessageModel.Fromid;
			p[2].Value = _MessageModel.Issent ? 1 : 0;//是否是我发的邮件
			//Debug.Trace (_MessageModel.Messageid.ToString() + "---" +)
			DoDataBase dd = new DoDataBase();
			string ret = dd.DoParameterSql("Message_Remove", p);
			//	Debug.Trace(ret);
			return "成功删除";
		}

		public string Update() {
			throw new Exception("The method or operation is not implemented.");
		}

		public string Update2() {
			throw new Exception("The method or operation is not implemented.");
		}
		public MessageModel MessageModel {
			private get {
				return _MessageModel;
			}
			set {
				_MessageModel = value;
			}
		}

		#endregion
	}
}
