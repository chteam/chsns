using System;
using System.Data;
using System.Data.SqlClient;
namespace Chsword.Execute {
	public class GroupSettingExecuter {
		public string SettingUpdate(Datamodel.GroupModel g) {
			SqlParameter[] p = new SqlParameter[6] { 
				new SqlParameter("@groupid", SqlDbType.BigInt),
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@publish", SqlDbType.NVarChar, 4000),
				new SqlParameter("@showlevel", SqlDbType.TinyInt),
				new SqlParameter("@joinlevel", SqlDbType.TinyInt),
				new SqlParameter("@groupname", SqlDbType.NVarChar, 50)
			};
			p[0].Value = g.Groupid;
			p[1].Value = g.ViewUserid;
			p[2].Value = g.Publish;
			p[3].Value = g.Showlevel;
			p[4].Value = g.Joinlevel;
			p[5].Value = g.Groupname;
			DoDataBase dd = new DoDataBase();
			int ret = int.Parse(dd.DoParameterSql("GroupSetting_Update", p));
			switch (ret) {
				case -1:
					return Debug.TraceBack("�ǹ���Ա���ܽ��д˲���");
				case 1:
					return "���³ɹ�";
				case -2:
					return "���³ɹ�";
				default:
					Debug.Trace("SettingUpdate δ֪�������ݿ�ķ���ֵ����Ԥ��֮��");
					return "δ֪����";
			}
		}
		public string DeleteMember(Datamodel.GroupModel g, long exeid) {
			GroupUserExecuter gue = new GroupUserExecuter();
			gue.Groupid = g.Groupid;
			gue.Userid = g.ViewUserid;//������id
			gue.Executerid = exeid;
			return gue.Remove();
		}
	}
}
