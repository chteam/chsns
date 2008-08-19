namespace ChAlumna.Controllers.components
{
	using System;
	using System.Data;
	public class PostList : BaseViewComponent
	{
		//DataRowCollection _rows;
		string _template = "SubjectList";
		int _nowpage = 1;
		int _everypage = 20;
		long _groupid;
		public override void Initialize() {
		//    if (ComponentParams.Contains("source"))
		//        _rows = ComponentParams["source"] as DataRowCollection;
			if (ComponentParams.Contains("template"))
				_template = ComponentParams["template"].ToString();
			if (ComponentParams.Contains("nowpage"))
				int.TryParse(ComponentParams["nowpage"].ToString(), out _nowpage);
			if (ComponentParams.Contains("everypage"))
				int.TryParse(ComponentParams["everypage"].ToString(), out _everypage);
			if (ComponentParams.Contains("groupid"))
				long.TryParse(ComponentParams["groupid"].ToString(), out _groupid);
			base.Initialize();
		}
		public override void Render() {
			Context.ContextVars["PostListRows"] = PostListRows;
			Context.ContextVars["Groupid"] = _groupid;
			this.RenderView("postlist", _template);
		}

		public DataRowCollection PostListRows {
			get{
				Dictionary dict = new Dictionary();
				dict.Add("@groupid",_groupid);
				dict.Add("@page",_nowpage);
				dict.Add("@everypage",_everypage);
				return DataBaseExecutor.GetRows("Group_NoteList",dict);
			}
		}
	}
}
