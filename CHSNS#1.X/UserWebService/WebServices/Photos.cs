/*
 * Created by 邹健
 * Date: 2007-10-17
 * Time: 20:35
 * 
 * 
 */
namespace CHSNS
{
	using System;
	using System.Data;
	using System.Web;
	using System.Text;
	using System.Collections;
	using System.Web.Services;
	using System.Web.Services.Protocols;
	using System.ComponentModel;
	using System.Data.SqlClient;
	using Chsword;
	using CHSNS;
	/// <summary>
	/// Description of Photos
	/// </summary>
	[WebService
	 (	Name = "Photos",
	  Description = "Photos",
	  Namespace = "http://www.Photos.example"
	 )
	]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService()]
	public class Photos : Chsword.WebServices
	{
		[WebMethod(EnableSession=true)]
		public string Album_Update(long albumid,string Name,string Location,string Description,byte Showlevel)
		{
			SqlParameter[] sqlParameter = new SqlParameter[6]{
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@name", SqlDbType.NVarChar, 50),
				new SqlParameter("@Location", SqlDbType.NVarChar, 50),
				new SqlParameter("@Showlevel", SqlDbType.TinyInt),
				new SqlParameter("@Description", SqlDbType.NVarChar, 150),
				new SqlParameter("@albumid", SqlDbType.BigInt),
			};
			sqlParameter[0].Value = ChSession.Userid;
			sqlParameter[1].Value = Name;
			sqlParameter[2].Value = Location;
			sqlParameter[3].Value = Showlevel;
			sqlParameter[4].Value = Description;
			sqlParameter[5].Value = albumid;
			DoDataBase db = new DoDataBase();
			if(db.DoParameterSql("Album_Update", sqlParameter)=="1")
				return "修改成功";
			return "error:您已经存在此相册,改个名字试试吧";
		}
		[WebMethod(EnableSession=true)]
		public string Album_Add(string Name,string Location,string Description,byte Showlevel)
		{
			SqlParameter[] sqlParameter = new SqlParameter[5]{
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@name", SqlDbType.NVarChar, 50),
				new SqlParameter("@Location", SqlDbType.NVarChar, 50),
				new SqlParameter("@Showlevel", SqlDbType.TinyInt),
				new SqlParameter("@Description", SqlDbType.NVarChar, 150)
			};
			sqlParameter[0].Value = ChSession.Userid;
			sqlParameter[1].Value = Name;
			sqlParameter[2].Value = Location;
			sqlParameter[3].Value = Showlevel;
			sqlParameter[4].Value = Description;
			DoDataBase db = new DoDataBase();
			if(db.DoParameterSql("Album_Add", sqlParameter)=="1")
				return "创建成功";
			return "error:您已经存在此相册,改个名字试试吧";
		}
		[WebMethod(EnableSession=true)]
		public string Album_Remove(long albumid)
		{
			SqlParameter[] sp = new SqlParameter[2]{
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@id", SqlDbType.BigInt),
			};
			sp[0].Value = ChSession.Userid;
			sp[1].Value = albumid;
			DoDataBase db = new DoDataBase();
			DataTable dt= db.DoDataSet("Album_SelectAllPhoto",sp).Tables[0];
			foreach(DataRow dr in dt.Rows ){
				System.IO.File.Delete(
					Server.MapPath(
						Path.ClientUserPhotosFolder()+dr["Path"].ToString()
					)
				);
				System.IO.File.Delete(
					Server.MapPath(
						string.Format("{0}{1}.jpg",
						              Path.ClientUserThumbFolder(),
						              System.IO.Path.GetFileNameWithoutExtension(dr["Path"].ToString())
						             )
					)
				);
			}

			SqlParameter[] sqlParameter = new SqlParameter[3]{
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@Albumid", SqlDbType.BigInt),
				new SqlParameter("@FileSizeCount", SqlDbType.BigInt)
			};
			sqlParameter[0].Value = ChSession.Userid;
			sqlParameter[1].Value = albumid;
			sqlParameter[2].Value = Path.DirectorySize(
				new System.IO.DirectoryInfo( Server.MapPath(Path.ClientUserFolder()))
			);
			DoDataBase db1 = new DoDataBase();
			if(db1.DoParameterSql("Album_Remove", sqlParameter)=="1")
				return "成功删除";
			return "error:意外错误";
		}
		[WebMethod(EnableSession=true)]
		public DataTable AlbumsTable(long userid,int page,int everypage){
			Chsword.Reader.Albums al = new Chsword.Reader.Albums();
			al.Viewerid=ChSession.Userid;
			al.Ownerid=(userid==0)?ChSession.Userid:userid;
			al.Nowpage=page;
			al.Everypage=everypage;
			return al.GetAlbums();
		}
		[WebMethod(EnableSession=true)]
		public DataRowCollection PhotosRows(long albumid,long ownerid,int currentPage,int everypage){
			Dictionary dict = new Dictionary();
			dict.Add("@ownerid",(ownerid==0)?ChSession.Userid:ownerid);
			dict.Add("@viewerid",ChUser.Current.Userid);
			dict.Add("@page",currentPage);
			dict.Add("@everypage",everypage);
			dict.Add("@albumid", albumid);
			return DataBaseExecutor.GetRows("Album_List", dict);
		}
		[WebMethod(EnableSession=true)]
		public string Photo_Remove(long photoid,string path)
		{
			try{
			string ppath=Server.MapPath(path);
			string tpath=Server.MapPath(string.Format("{0}{1}.jpg",Path.ClientUserThumbFolder(),System.IO.Path.GetFileNameWithoutExtension(path)));
			long filesize=0;
			if(System.IO.File.Exists(ppath)){
				filesize+=Path.FileSize(ppath);
				System.IO.File.Delete(ppath);
			}
			if(System.IO.File.Exists(tpath)){
				filesize+=Path.FileSize(tpath);
				System.IO.File.Delete(tpath);
			}

			SqlParameter[] sqlParameter = new SqlParameter[3]{
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@photoid", SqlDbType.BigInt),
				new SqlParameter("@FileSize", SqlDbType.BigInt)
			};
			sqlParameter[0].Value = ChSession.Userid;
			sqlParameter[1].Value = photoid;
			sqlParameter[2].Value = filesize;
			DoDataBase db1 = new DoDataBase();
			if(db1.DoParameterSql("Photo_Remove", sqlParameter)=="1")
				return "成功删除";
			}catch(Exception ex){
				return "error:意外错误"+ex.Message;
			}
			return "error:意外错误";
		}
		[WebMethod(EnableSession=true)]
		public bool Photo_Cover(long photoid){
			SqlParameter[] sqlParameter = new SqlParameter[2]{
				new SqlParameter("@userid", SqlDbType.BigInt),
				new SqlParameter("@photoid", SqlDbType.BigInt)
			};
			sqlParameter[0].Value = ChSession.Userid;
			sqlParameter[1].Value = photoid;
			DoDataBase db1 = new DoDataBase();
			if(db1.DoParameterSql("Photo_Cover", sqlParameter)=="1")
				return true;
			else
				return false;
		}

		//public DataTable GetPhotos() {

		//}
	}
}
