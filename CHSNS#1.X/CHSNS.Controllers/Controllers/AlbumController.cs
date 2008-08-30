
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
		/// ��һ�����,���ദ�б�
		/// </summary>
		public void index() {
			ViewData.Add("tabs", this.QueryNum("tabs"));
			ViewData.Add("Ownerid", this.QueryLong("userid") == 0 ? CHSNSUser.Current.UserID : this.QueryLong("userid"));
			ViewData.Add("Albumid", this.QueryLong("albumid"));

			Dictionary dict = new Dictionary();//����
			dict.Add("@Ownerid", this.QueryLong("userid") == 0 ? CHSNSUser.Current.UserID : this.QueryLong("userid"));//��һ
			dict.Add("@Viewerid", CHSNSUser.Current.UserID);//�ζ�
			dict.Add("@albumid", this.QueryLong("albumid"));//����

			//IList<Album> i = ChAlumna.CastleExt.SpExecute.GetList<Album>("Album_Info", p);
			DataRowCollection drs = DataBaseExecutor.GetRows("Album_Info", dict);
			if (drs.Count != 0)
				ViewData.Add("album", drs[0]);
			// ViewData.Add("photos", album.GetPhotos().Rows);
			View();

		}
		//�����
		public void random() {
			Chsword.Reader.Albums al = new Chsword.Reader.Albums();
			ViewData.Add("items", al.GetAlbumRandomTable().Rows);
			View();
		}
		/// <summary>
		/// ĳ�˵�����б�
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

