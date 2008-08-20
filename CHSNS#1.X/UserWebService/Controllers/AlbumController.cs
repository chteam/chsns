namespace ChAlumna.Controllers
{
	using System;
	//using Chsword.Reader;
using Castle.MonoRail.Framework;
using ChAlumna.Models;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using CHSNS;
	[Filter(ExecuteEnum.BeforeAction,typeof(LoginedFilter))]
    public class AlbumController : BaseController
    {
        /// <summary>
        /// 打开一个相册,是相处列表
        /// </summary>
		public void index() {
			ViewData.Add("tabs", QueryNum("tabs"));
			ViewData.Add("Ownerid", QueryLong("userid") == 0 ? ChUser.Current.Userid : QueryLong("userid"));
			ViewData.Add("Albumid", QueryLong("albumid"));

			Dictionary dict = new Dictionary();//参数
			dict.Add("@Ownerid", QueryLong("userid") == 0 ? ChUser.Current.Userid : QueryLong("userid"));//参一
			dict.Add("@Viewerid", ChUser.Current.Userid);//参二
			dict.Add("@albumid", QueryLong("albumid"));//参三

			//IList<Album> i = ChAlumna.CastleExt.SpExecute.GetList<Album>("Album_Info", p);
			DataRowCollection drs = DataBaseExecutor.GetRows("Album_Info", dict);
			if (drs.Count != 0)
				ViewData.Add("album", drs[0]);
			// ViewData.Add("photos", album.GetPhotos().Rows);

		}
        //随机出
        public void random() {
            Chsword.Reader.Albums al = new Chsword.Reader.Albums();
            ViewData.Add("items", al.GetAlbumRandomTable().Rows);
        }
        /// <summary>
        /// 某人的相册列表
        /// </summary>
        public void list() {
           // index = ;
			Chsword.Reader.Albums al = new Chsword.Reader.Albums();
            al.Viewerid = ChUser.Current.Userid;
            al.Ownerid = QueryLong("userid") == 0 ? ChUser.Current.Userid : QueryLong("userid");
            ViewData.Add("albums", al);
            ViewData.Add("tabs",QueryNum("tabs"));

            ViewData.Add("rows", al.GetAlbums().Rows);

        }
    }
}

