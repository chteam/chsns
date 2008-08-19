/*
 * Created by 邹健
 * Date: 2007-10-14
 * Time: 20:53
 * 
 * 
 */
using ChAlumna;
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Chsword.Reader
{
	/// <summary>
	/// Description of Album.
	/// </summary>
	public  class Albums :Databases 
	{
		long _ownerid;
		long _viewerid;
		int _nowpage=1;
		int _everypage=6;
		DataTable _Info=null;
		public	DataTable GetAlbums(){
			SqlParameter[] sp = new SqlParameter[4]{
				new SqlParameter("@ownerid", SqlDbType.BigInt),
				new SqlParameter("@viewerid", SqlDbType.BigInt),
				new SqlParameter("@page", SqlDbType.Int),
				new SqlParameter("@everypage", SqlDbType.Int)
			};
			sp[0].Value = _ownerid;
			sp[1].Value =_viewerid;
			sp[2].Value = _nowpage;
			sp[3].Value = _everypage;
			DoDataBase db = new DoDataBase();
			return db.DoDataSet("Albums_List", sp).Tables[0];
		}
		public DataTable GetInfo(){
			if(_Info==null)
				_Info=base.GetDataSetbyId2(_ownerid, "@ownerid",
				                           _viewerid, "@viewerid",
				                           "Albums_Info"
				                          ).Tables[0];
			return _Info;
		}
		public DataTable GetAlbumRandomTable(){
			DoDataBase db = new DoDataBase();
			return db.DoDataSet("Album_RandomList").Tables[0];
		}

		#region protype
		public string Ownername{
			get{
				return GetInfo().Rows[0]["name"].ToString();
			}
		}
		public string AlbumCount{
			get{
				return GetInfo().Rows[0]["AlbumCount"].ToString();
			}
		}
		public string Relation{
			get{
				return GetInfo().Rows[0]["Relation"].ToString();
			}
		}
		public long Ownerid {
			get { return _ownerid; }
			set { _ownerid = value; }
		}
		public long Viewerid {
			get { return _viewerid; }
			set { _viewerid = value; }
		}
		public int Nowpage {
			get {
				return _nowpage;
			}
			set {
				_nowpage=value;
			}
		}
		
		public int Everypage {
			get {
				return _everypage;
			}
			set {
				_everypage=value;
			}
		}
		#endregion
	}
}

