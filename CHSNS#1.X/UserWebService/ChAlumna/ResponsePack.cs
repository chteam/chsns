namespace ChAlumna
{
	using System;
	using System.Web;
	using System.Collections;
	/// <summary>
	/// Services ���صİ�,TemplateΪģ��,�ɷ��ؿɲ�����,DatasΪ���ݼ�Collection
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
