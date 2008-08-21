/*
 * Created by 邹健
 * Date: 2007-10-19
 * Time: 16:57
 * 
 * 
 */
using System;
using System.Data;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using CHSNS;
namespace Chsword
{
	/// <summary>
	/// Description of Message
	/// </summary>
	[WebService
	 (	Name = "Message",
	  Description = "Message",
	  Namespace = "http://5field.com"
	 )
	]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	public class Message : Chsword.WebServices
	{
		[WebMethod(EnableSession=true)]
		public string Remove_Select(string id,byte issend)
		{
			
			SqlParameter[] p = new SqlParameter[3]{
				new SqlParameter("@messageid", SqlDbType.NVarChar ,4000),
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@type", SqlDbType.TinyInt)
			};
			p[0].Value = id;
			p[1].Value =ChSession.Userid;
			p[2].Value = issend;
			DoDataBase dd = new DoDataBase();
			string ret = dd.DoParameterSql("Message_Remove_Select", p);
			return "成功删除";
		}
		
       static  public Byte SendMessageText(Int64 From_UserId, Int64 To_UserId, String Title, String Body)
        {
            return MessageInsert(From_UserId, To_UserId, Title, Body, false);
        }
        static public Byte SendMessageHtml(Int64 From_UserId, Int64 To_UserId, String Title, String Body)
        {
            return MessageInsert(From_UserId, To_UserId, Title, Body, true);
        }
        
        
       #region 发信对数据库
		static Byte MessageInsert(Int64 From_UserId, Int64 To_UserId, String Title, String Body, Boolean flag)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@FromId", SqlDbType.BigInt);
            p[0].Value = From_UserId;
            p[1] = new SqlParameter("@ToId", SqlDbType.BigInt);
            p[1].Value = To_UserId;
            p[2] = new SqlParameter("@Body", SqlDbType.NVarChar, 4000);
            p[2].Value = Body;
            p[3] = new SqlParameter("@Title", SqlDbType.NVarChar, 200);
            p[3].Value = Title;
            p[4] = new SqlParameter("@IsHtml", SqlDbType.Bit);
            p[4].Value = flag;
            DoDataBase dd = new DoDataBase();
            return Byte.Parse(dd.DoParameterSql("MessageInsert", p));
            //'-1--收信人信箱已满
            //'1成功
            //'0--发信人或收信人不存在
        }
       #endregion
	}
}
