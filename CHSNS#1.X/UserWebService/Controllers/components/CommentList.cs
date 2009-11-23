/*
 * Created by 邹健
 * Date: 2007-12-25
 * Time: 23:44
 * 
 * 
 */
namespace ChAlumna.Controllers.components
{
	using System;
	using System.Data;
	using System.Data.SqlClient;
	using Chsword;
	using Castle.MonoRail.Framework;
	/// <summary>
	/// Description of ViewList.
	/// </summary>
	public class CommentList : BaseViewComponent
	{
		int _Everypage = 10;
		int _Nowpage = 1;
		int _type = 0;//类型0为回复1为日志2相册,3为SuperNote
		long _Logid = 0;
		long _Ownerid = 0;
		string _CountId = "";//显示COUNT的ID标签
		DataRowCollection _Rows = null;
		public override void Initialize() {
			if (ComponentParams.Contains("type"))
				int.TryParse(ComponentParams["type"].ToString(), out _type);
			if (ComponentParams.Contains("EveryPage"))
				int.TryParse(ComponentParams["EveryPage"].ToString(), out _Everypage);
			if (ComponentParams.Contains("Nowpage"))
				int.TryParse(ComponentParams["Nowpage"].ToString(), out _Nowpage);
			if (ComponentParams.Contains("Logid"))
				long.TryParse(ComponentParams["Logid"].ToString(), out 	_Logid);
			if (ComponentParams.Contains("Ownerid"))
				long.TryParse(ComponentParams["Ownerid"].ToString(), out 	_Ownerid);
			if (ComponentParams.Contains("Countid"))
				_CountId = ComponentParams["Countid"].ToString();
			
			_Rows = GetReplyList();
			base.Initialize();
		}
		public override void Render() {
			Context.ContextVars.Add("EveryPage", _Everypage);
			Context.ContextVars.Add("type", _type);
			Context.ContextVars.Add("Nowpage", _Nowpage);
			Context.ContextVars.Add("Logid", _Logid);
			Context.ContextVars.Add("Ownerid", _Ownerid);
			Context.ContextVars.Add("Count", GetCount());
			Context.ContextVars.Add("Countid", _CountId);
			Context.ContextVars.Add("rows", GetReplyList());
			this.RenderView("", "CommentList");
		}
		private string GetCount() {
			DoDataBase dd = new DoDataBase();
			SqlParameter[] sp = new SqlParameter[2];
			sp[0] = new SqlParameter("@id", SqlDbType.BigInt);
			sp[0].Value = _Ownerid;
			sp[1] = new SqlParameter("@type", SqlDbType.TinyInt);
			sp[1].Value = _type;
			return dd.DoParameterSql("CommentCount", sp);
		}
		public DataRowCollection GetReplyList() {
			SqlParameter[] sp = new SqlParameter[5]{
				new SqlParameter("@ownerid", SqlDbType.BigInt),
				new SqlParameter("@page", SqlDbType.BigInt),
				new SqlParameter("@everyPage", SqlDbType.BigInt),
				new SqlParameter("@type", SqlDbType.TinyInt),
				new SqlParameter("@logid", SqlDbType.BigInt)
			};
			sp[0].Value = _Ownerid;
			sp[1].Value = _Nowpage;
			sp[2].Value = _Everypage;
			sp[3].Value = _type;
			sp[4].Value = _Logid;
			DoDataBase db = new DoDataBase();
			return db.DoDataTable("CommentSelect", sp).Rows;
		}
	}
}
