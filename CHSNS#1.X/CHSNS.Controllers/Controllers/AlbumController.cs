
using System;
//using Chsword.Reader;
using CHSNS.Extension;
using CHSNS.Filter;
using CHSNS.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using CHSNS;
namespace CHSNS.Controllers {
	[LoginedFilter]
	public class AlbumController : BaseController {
		/// <summary>
		/// 打开一个相册,是相处列表
		/// </summary>
		public void index() {
			ViewData.Add("tabs", this.QueryNum("tabs"));
			ViewData.Add("Ownerid", this.QueryLong("userid") == 0 ? CHSNSUser.Current.UserID : this.QueryLong("userid"));
			ViewData.Add("Albumid", this.QueryLong("albumid"));

			Dictionary dict = new Dictionary();//参数
			dict.Add("@Ownerid", this.QueryLong("userid") == 0 ? CHSNSUser.Current.UserID : this.QueryLong("userid"));//参一
			dict.Add("@Viewerid", CHSNSUser.Current.UserID);//参二
			dict.Add("@albumid", this.QueryLong("albumid"));//参三

			//IList<Album> i = ChAlumna.CastleExt.SpExecute.GetList<Album>("Album_Info", p);
			DataRowCollection drs = DataBaseExecutor.GetRows("Album_Info", dict);
			if (drs.Count != 0)
				ViewData.Add("album", drs[0]);
			// ViewData.Add("photos", album.GetPhotos().Rows);
			View();

		}
		//随机出
		public void random() {
			Chsword.Reader.Albums al = new Chsword.Reader.Albums();
			ViewData.Add("items", al.GetAlbumRandomTable().Rows);
			View();
		}
		/// <summary>
		/// 某人的相册列表
		/// </summary>
		public void list() {
			// index = ;
			Chsword.Reader.Albums al = new Chsword.Reader.Albums();
			al.Viewerid = CHSNSUser.Current.UserID;
			al.Ownerid = this.QueryLong("userid") == 0 ? CHSNSUser.Current.UserID : this.QueryLong("userid");
			ViewData.Add("albums", al);
			ViewData.Add("tabs", this.QueryNum("tabs"));

			ViewData.Add("rows", al.GetAlbums().Rows);
			View();
		}
	}
}

