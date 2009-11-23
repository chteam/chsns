/*
 * Created by 邹健
 * Date: 2007-12-25
 * Time: 23:44
 * 
 * 
 */

using System;
using System.Data;
using System.Data.SqlClient;
using Chsword;
using Castle.MonoRail.Framework;
namespace ChAlumna.Controllers.components
{
	/// <summary>
	/// Description of ViewList.
	/// </summary>
	public class ViewList:ViewComponent
	{
		object _type=0;
		object _everyrow=3;
		object _Ownerid=0;
		object _count=6;
		public override void Initialize()
		{
			if(ComponentParams.Contains("type"))
				_type=ComponentParams["type"];
			if(ComponentParams.Contains("everyrow"))
				_everyrow=ComponentParams["everyrow"];
			if(ComponentParams.Contains("ownerid"))
				_Ownerid=ComponentParams["ownerid"];
			if(ComponentParams.Contains("count")){
				_count=ComponentParams["count"];
			}
			base.Initialize();
		}
		public override void Render()
		{
			this.Context.ContextVars["viewrows"] = GetViewTable().Rows;
			this.Context.ContextVars.Add("this",this);
			Context.ContextVars.Add("everyrow",_everyrow);
			this.RenderView("","ViewList");
		}
		private DataTable GetViewTable() {
			SqlParameter[] sp = new SqlParameter[4]{
				new SqlParameter("@viewerid", SqlDbType.BigInt),
				new SqlParameter("@ownerid", SqlDbType.BigInt),
				new SqlParameter("@viewclass", SqlDbType.Int),
				new SqlParameter("@count", SqlDbType.Int)
			};
			sp[0].Value = ChSession.UseridwithoutError;
			sp[1].Value = _Ownerid;
			sp[2].Value = _type;
			sp[3].Value = _count;
			DoDataBase db = new DoDataBase();
			return db.DoDataTable("ViewList", sp);
		}
		public string toFace(object uid){
			return Path.GetFace(uid.ToString(), ImgSize.small);
		}
	}
}