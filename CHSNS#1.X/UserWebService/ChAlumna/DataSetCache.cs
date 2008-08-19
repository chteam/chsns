namespace ChAlumna {
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using System.Text;
	using System.Web;
	
	using Chsword;

	public class DataSetCache : Chsword.Reader.Databases {
	//	static DataSetCache _DataSetCache;
		static public DataSetCache Current {
			get {
				if (HttpContext.Current.Application["datasetcache_current"] == null) {
					HttpContext.Current.Application.Lock();
					HttpContext.Current.Application["datasetcache_current"] = new DataSetCache();
					HttpContext.Current.Application.UnLock();
				}
				return HttpContext.Current.Application["datasetcache_current"] as DataSetCache;
			}
		}

		#region 学校缓存
		public string GetFieldName(long fieldid) {
			return University(fieldid);
		}
		public string GetMiniFieldName(long fid, long mfid) {
			return GetXueyuanName(fid, mfid);
		}
		public string University(long uid) {
			DataRow[] drs = DataSetCache.AllUniversity_DataTable().Select(
				string.Format("id={0}", uid));
			if (drs.Length == 0)
				return string.Empty;
			else
				return drs[0]["school"].ToString();
		}
		static public DataTable AllUniversity_DataTable() {
			string name = "DataTable.AllUniversity";
			if (ChCache.IsNullorEmpty(name)) {
				DoDataBase dd = new DoDataBase();
				SqlParameter[] p = new SqlParameter[2] {
					new SqlParameter("@province", SqlDbType.NVarChar,50),
					new SqlParameter("@schoolclass", SqlDbType.Int)
				};
				p[0].Value = "";
				p[1].Value = 0;
				ChCache.SetCache(
					name,
					dd.DoDataTable("SchoolList_byProvince", p)
					);
			}
			return HttpContext.Current.Cache[name] as DataTable;
		}
		static public DataTable SchoolList(string Province_str, int SchoolClass) {
			string name = String.Format("DataTable.School.{0}", Province_str);
			if (ChCache.IsNullorEmpty(name)) {
				DoDataBase dd = new DoDataBase();
				SqlParameter[] p = new SqlParameter[2] {
					new SqlParameter("@province", SqlDbType.NVarChar,50),
					new SqlParameter("@schoolclass", SqlDbType.Int)
				};
				p[0].Value = Province_str;
				p[1].Value = SchoolClass;
				ChCache.SetCache(name, dd.DoDataTable("SchoolList_byProvince", p));
			}
			return HttpContext.Current.Cache[name] as DataTable;
		}
		#endregion
		
		#region 学院缓存
		static public DataTable XueYuanList(string school) {
			string name = String.Format("DataTable.XueYuan.{0}", school);
			if (ChCache.IsNullorEmpty(name)){
				DoDataBase dd = new DoDataBase();
				SqlParameter[] p = new SqlParameter[1] {
					new SqlParameter("@School", SqlDbType.NVarChar,50)
				};
				p[0].Value = school;
				ChCache.SetCache(name, dd.DoDataTable("GetXueYuan",p));
			}
			return HttpContext.Current.Cache[name] as DataTable;
			//本缓存名形如 DataSet.School.XueYuan.佳木斯大学
		}
		static public DataTable XueYuanList(long schoolid) {
			DataRow[] dr = AllUniversity_DataTable().Select(
				string.Format("id={0}", schoolid));
			string school;
			if (!(dr.Length > 0))
				return null;
			else
				school = dr[0]["school"].ToString();
			return XueYuanList(school);
			//本缓存名形如 DataSet.School.XueYuan.佳木斯大学
		}
		static public string Xueyuan(long schoolid, long xueyuanid) {
			DataRow [] dr=XueYuanList(schoolid).Select(
				string.Format("id={0}", xueyuanid));
			if (dr.Length > 0)
				return dr[0]["xueyuan"].ToString();
			else
				return "";

		}
		public string GetXueyuanName(long schoolid, long xueyuanid) {
			return DataSetCache.Xueyuan(
									schoolid,
									xueyuanid
								);
		}
		
		#endregion
		

		#region 寝室缓存
		
		public DataRowCollection QinShiRows(string school) {
			return DataSetCache.QinshiList(school).Rows;
		}
		static public DataTable QinshiList(string school) {
			string name = String.Format("DataSet.Qinshi.{0}", school);
			if (ChCache.IsNullorEmpty(name))
				ChCache.SetCache(name, DataBaseExecutor.GetDataTable_str1(school, "@School", "GetQinShi"));
			return HttpContext.Current.Cache[name] as DataTable;
		}
		static public StringBuilder QinshiOptionList(string school) {
			StringBuilder sb = new StringBuilder();
			foreach(DataRow dr in QinshiList(school).Rows){
				sb.AppendFormat(ChCache.GetConfig("Option"), dr["id"], dr["Qinshi"]);
			}
			return sb;
		}
		#endregion

		#region 省区
		public DataRowCollection ProvinceRows() {
			return DataSetCache.ProvinceList().Rows;
		}
		static public DataTable ProvinceList() {
			string name = "DataSet.Province";
			if (ChCache.IsNullorEmpty(name)){
				DoDataBase db = new DoDataBase();
				ChCache.SetCache(name, db.DoDataTable("ProvinceList"));
			}
			return HttpContext.Current.Cache[name] as DataTable;
		}
		 
		static public string ProvinceOptionList() {
			string name = "OptionList.Province";
			
			if (ChCache.IsNullorEmpty(name)) {
				System.Data.DataTable dt = ProvinceList();
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < dt.Rows.Count; i++)
					sb.AppendFormat(ChCache.GetConfig("Option")
						, dt.Rows[i]["id"], dt.Rows[i]["name"]);

				ChCache.SetCache(name, sb.ToString());
			}
			return HttpContext.Current.Cache[name].ToString();
		}
		#endregion

		#region 市
		public DataRowCollection CityRows(int Province) {
			string name = String.Format("DataSet.City.{0}", Province);
			if (ChCache.IsNullorEmpty(name)) {
				Dictionary dict = new Dictionary();
				dict.Add("@pid", Province);
				ChCache.SetCache(name, DataBaseExecutor.GetRows("CityList", dict));
			} 
			return HttpContext.Current.Cache[name] as DataRowCollection;
		} 
		public string CityOptionList(int Province) {
			string name = String.Format("OptionList.City.{0}", Province.ToString());
			//System.Data.DataTable dt = .Tables[0];
			if (ChCache.IsNullorEmpty(name)) {
				StringBuilder sb = new StringBuilder();
				foreach (DataRow dr in CityRows(Province))
					sb.AppendFormat(
						ChCache.GetConfig("Option")
						, dr["id"].ToString(),
						dr["name"].ToString()
						);

				ChCache.SetCache(name, sb.ToString());
			}
			return HttpContext.Current.Cache[name].ToString();
		}
		#endregion

		#region 群分类
		public DataTable GroupCategory_DataTable() {
			string name = "DataTable.Category.Group";
			if (ChCache.IsNullorEmpty(name)) {
				DoDataBase ddb = new DoDataBase();
				ChCache.SetCache(
					name,
					ddb.getDataTable_SqlText("select id,[name],[count] from category where [type]=0")//0是群分类
					);
			}
			return (DataTable)HttpContext.Current.Cache[name];
		}
		public String GroupCategory_List() {
			string name = "OptionList.Category.Group";
			if (ChCache.IsNullorEmpty(name)) {
				StringBuilder sb = new StringBuilder();
				foreach (DataRow dr in GroupCategory_DataTable().Rows) {
					sb.AppendFormat(
						ChCache.GetConfig("Option"),
						dr["id"],
						dr["name"]
						);
				}
				ChCache.SetCache(name, sb.ToString());
			}
			return HttpContext.Current.Cache[name].ToString();
		}
		#endregion

		#region 视频日志分类（系统）
		static public DataTable SuperCategory_DataTable() {
			string name = "DataTable.Category.SuperSystem";
			if (ChCache.IsNullorEmpty(name)) {
				DoDataBase ddb = new DoDataBase();
				ChCache.SetCache(
					name,
					ddb.getDataTable_SqlText("select id,[name],[count] from category where [type]=1")//1是视频分类
					, new TimeSpan(0, 20, 0)
					);
			}
			return HttpContext.Current.Cache[name] as DataTable;
		}
		static public String SuperCategory_List() {
			string name = "OptionList.Category.SuperSystem";
			if (ChCache.IsNullorEmpty(name)) {
				StringBuilder sb = new StringBuilder();
				foreach (DataRow dr in SuperCategory_DataTable().Rows) {
					sb.AppendFormat(
						ChCache.GetConfig("Option"),
						dr["id"],
						dr["name"]
						);
				}
				ChCache.SetCache(name, sb.ToString(), new TimeSpan(0, 20, 0));//20分刷新列表
			}
			return HttpContext.Current.Cache[name].ToString();
		}
		#endregion
	}
}
