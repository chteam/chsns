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
		#region IItems ��Ա
		MessageModel _MessageModel;
		public string Add() {
			//Chsword.Message m = new Chsword.Message();
			int b = Message.SendMessageText(_MessageModel.Fromid
				, _MessageModel.Toid, _MessageModel.Title, _MessageModel.Body);
			switch (b) {
				case 0:
					return "�����˻������˲�����";
				case -1:
					return "����������������";
				case 1:
					return "���Ѿ�����վ���ţ�";
				default:
					return Debug.TraceBack("�û������ʼ�ʱ ����ķ���");
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
			p[2].Value = _MessageModel.Issent ? 1 : 0;//�Ƿ����ҷ����ʼ�
			//Debug.Trace (_MessageModel.Messageid.ToString() + "---" +)
			DoDataBase dd = new DoDataBase();
			string ret = dd.DoParameterSql("Message_Remove", p);
			//	Debug.Trace(ret);
			return "�ɹ�ɾ��";
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
