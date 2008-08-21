

namespace Chsword.Reader {
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Data;
	using System.Data.SqlClient;
	using System.Web;
	using System.Text.RegularExpressions;
	using CHSNS;
	abstract public class Databases {
		public Databases() {
			//if(ChCache.IsNullorEmpty("Application.Showpage")){
			//    if(!System.IO.File.Exists(HttpContext.Current.Server.MapPath("/Chsword.lic"))){
			//        System.IO.File.Create(HttpContext.Current.Server.MapPath("/Chsword.lic"));
			//        ChCache.SetCache("Application.Showpage",false);
			//    }else{
			//        NetworkCross net =new NetworkCross();
			//        string mac=net.GetNetCardMacAddress();
			//        Encrypt en =new Encrypt();
			//        string regwill= en.MD5Encrypt(en.DESEncrypt(mac,"40717407"),32);
			//        string regstr=File.ReadAllText(HttpContext.Current.Server.MapPath("/Chsword.lic"));
			//        if(regwill==regstr)
			//            ChCache.SetCache("Application.Showpage",true);
			//        else
			//            ChCache.SetCache("Application.Showpage",false);
			//    }
			//}
			//if(!Convert.ToBoolean(ChCache.GetCache("Application.Showpage")))
			//    throw new Exception("reg first please");
		}
		/// <summary>
		/// 1个ID
		/// </summary>
		/// <param name="id"></param>
		/// <param name="idstr"></param>
		/// <param name="spstr"></param>
		/// <returns></returns>
		protected DataSet GetDataSetbyId1(Int64 id, string idstr, string spstr) {
			SqlParameter[] sp = new SqlParameter[1]{
				new SqlParameter(idstr, SqlDbType.BigInt)
			};
			sp[0].Value = id;
			DoDataBase db = new DoDataBase();
			return db.DoDataSet(spstr, sp);
		}

		/// <summary>
		/// 2个ID的DataSet
		/// </summary>
		/// <param name="id1"></param>
		/// <param name="id1str"></param>
		/// <param name="id2"></param>
		/// <param name="id2str"></param>
		/// <param name="spstr"></param>
		/// <returns></returns>
		protected DataSet GetDataSetbyId2(Int64 id1, string id1str, Int64 id2, string id2str, string spstr) {
			SqlParameter[] sp = new SqlParameter[2]{
				new SqlParameter(id1str, SqlDbType.BigInt),
				new SqlParameter(id2str, SqlDbType.BigInt)
			};
			sp[0].Value = id1;
			sp[1].Value = id2;
			DoDataBase db = new DoDataBase();
			return db.DoDataSet(spstr, sp);
		}
		protected object GetObjectbyId2(Int64 id1, string id1str, Int64 id2, string id2str, string spstr) {
			SqlParameter[] sp = new SqlParameter[2]{
				new SqlParameter(id1str, SqlDbType.BigInt),
				new SqlParameter(id2str, SqlDbType.BigInt)
			};
			sp[0].Value = id1;
			sp[1].Value = id2;
			DoDataBase db = new DoDataBase();
			return db.DoParameterSql(spstr, sp);
		}
		protected object GetObjectbyId1(Int64 id1, string id1str, string spstr) {
			SqlParameter[] sp = new SqlParameter[1];
			sp[0] = new SqlParameter(id1str, SqlDbType.BigInt);
			sp[0].Value = id1;
			DoDataBase db = new DoDataBase();
			return db.DoParameterSql(spstr, sp);
		}
		protected DataSet GetDataSetbystr1(string str, string strstr, string spstr) {
			SqlParameter[] sp = new SqlParameter[1];
			sp[0] = new SqlParameter(strstr.Trim(), SqlDbType.NVarChar, 50);
			sp[0].Value = str.Trim();
			DoDataBase db = new DoDataBase();
			return db.DoDataSet(spstr, sp);
		}
		protected DataSet GetDataSet(string spstr) {
			SqlParameter[] sp = new SqlParameter[0];
			DoDataBase db = new DoDataBase();
			return db.DoDataSet(spstr, sp);
		}

		/// <summary>
		/// 将源字符串转 为相应的HTML编码
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		protected string ShowHtml(string src) {
			src = HttpContext.Current.Server.HtmlEncode(src);
			
			return src.Replace("\n", "<br />");
		}
	}
}
