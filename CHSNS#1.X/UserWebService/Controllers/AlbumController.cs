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
        /// ��һ�����,���ദ�б�
        /// </summary>
		public void index() {
			ViewData.Add("tabs", QueryNum("tabs"));
			ViewData.Add("Ownerid", QueryLong("userid") == 0 ? ChUser.Current.Userid : QueryLong("userid"));
			ViewData.Add("Albumid", QueryLong("albumid"));

			Dictionary dict = new Dictionary();//����
			dict.Add("@Ownerid", QueryLong("userid") == 0 ? ChUser.Current.Userid : QueryLong("userid"));//��һ
			dict.Add("@Viewerid", ChUser.Current.Userid);//�ζ�
			dict.Add("@albumid", QueryLong("albumid"));//����

			//IList<Album> i = ChAlumna.CastleExt.SpExecute.GetList<Album>("Album_Info", p);
			DataRowCollection drs = DataBaseExecutor.GetRows("Album_Info", dict);
			if (drs.Count != 0)
				ViewData.Add("album", drs[0]);
			// ViewData.Add("photos", album.GetPhotos().Rows);

		}
        //�����
        public void random() {
            Chsword.Reader.Albums al = new Chsword.Reader.Albums();
            ViewData.Add("items", al.GetAlbumRandomTable().Rows);
        }
        /// <summary>
        /// ĳ�˵�����б�
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

