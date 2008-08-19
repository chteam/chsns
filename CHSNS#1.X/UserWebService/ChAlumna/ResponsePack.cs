namespace ChAlumna
{
	using System;
	using System.Web;
	using System.Collections;
	/// <summary>
	/// Services 返回的包,Template为模板,可返回可不返回,Datas为数据集Collection
	/// </summary>
	public class ResponsePack
	{
		String _Template = null;
		ICollection _Datas;
		public String Template {
			get { return _Template; }
			set { _Template = value; }
		}
		public ICollection Datas {
			get { return _Datas; }
			set { _Datas = value; }
		}


	}
}
