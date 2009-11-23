/*
 * Created by 邹健
 * Date: 2007-12-26
 * Time: 12:39
 * 
 * 
 */

using System.Data;
using System.Data.SqlClient;
using Chsword;

namespace CHSNS.Controllers.Components
{
	public enum EventType {
		ProfileList = 0,
		Friend = 1
	}
	/// <summary>
	/// Description of Event.
	/// </summary>
	public class Event : ViewComponent
	{
		object _userid = 0;
		object _type = 0;
		object _template="";
		public override void Initialize()
		{
			if(ComponentParams.Contains("userid"))
				_userid=ComponentParams["userid"];
			if(ComponentParams.Contains("type"))
				_type=ComponentParams["type"];
			//if(ComponentParams.Contains("template"))
			//	_template=ComponentParams["template"];
			base.Initialize();
		}
		public override void Render(){
			this.Context.ContextVars["eventrows"] =  GetEvent().Rows;
			this.Context.ContextVars.Add("this",this);
			this.RenderView("","Event");
		}
		public override bool SupportsSection(string name)
        {
            return name == "header" || name == "bottom";
        }
		DataTable GetEvent() {
			SqlParameter[] p = new SqlParameter[4] { 
				new SqlParameter("@userid", System.Data.SqlDbType.BigInt),
				new SqlParameter("@type", System.Data.SqlDbType.TinyInt),
				new SqlParameter("@page", System.Data.SqlDbType.BigInt),
				new SqlParameter("@everyPage", System.Data.SqlDbType.BigInt)
			};
			p[0].Value = _userid;
			p[1].Value = _type;
			p[2].Value = 1;
			p[3].Value = 10;
			DoDataBase dd = new DoDataBase();
			return dd.DoDataTable("Event_List", p);
		}
	}
}
