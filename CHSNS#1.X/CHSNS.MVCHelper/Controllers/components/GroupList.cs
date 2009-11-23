/*
 * Created by 邹健
 * Date: 2008 2 5
 * Time: 23:44
 * 
 * 
 */
namespace CHSNS.Controllers.Components
{
	using System;
	using System.Data;
	using System.Data.SqlClient;
	using Chsword;
	
	using CHSNS;
	/// <summary>
	/// Description of ViewList.
	/// </summary>
	public class GroupList : BaseViewComponent
	{
	//	DataRowCollection _rows;
		string _template = "";

		long _Ownerid;
		byte _groupclass = 0;
		int _nowpage = 1;
		int _everypage = 20;
		byte _type = 0;
		bool _autotoclass = false;
		public override void Initialize()
		{
			if (ComponentParams.Contains("template"))
				_template = ComponentParams["template"].ToString();
			if (ComponentParams.Contains("Ownerid"))
				long.TryParse(ComponentParams["Ownerid"].ToString(), out _Ownerid);
			if (ComponentParams.Contains("groupclass"))
				byte.TryParse(ComponentParams["groupclass"].ToString(), out _groupclass);
			if (ComponentParams.Contains("nowpage"))
				int.TryParse(ComponentParams["nowpage"].ToString(), out _nowpage);
			if (ComponentParams.Contains("everypage"))
				int.TryParse(ComponentParams["everypage"].ToString(), out _everypage);
			if (ComponentParams.Contains("type"))
				byte.TryParse(ComponentParams["type"].ToString(), out _type);
			if (ComponentParams.Contains("autotoclass"))
				bool.TryParse(ComponentParams["autotoclass"].ToString(), out _autotoclass);
			base.Initialize();
		}
		public override void Render()
		{
			this.Context.ContextVars["rows"] = GetGroupList();
			this.RenderView("grouplist", _template);
		}

		DataRowCollection GetGroupList() {
			Dictionary dict = new Dictionary();
			dict.Add("@userid", _Ownerid);
			dict.Add("@page", _nowpage);
			dict.Add("@everypage", _everypage);
			dict.Add("@GroupClass", _groupclass);
			dict.Add("@type", _type);
			return DataBaseExecutor.GetRows("GroupList", dict);
		}

	}
}
