namespace ChAlumna.Controllers
{
	using System;
	using Castle.MonoRail.Framework;
	using System.Web;
	using System.Collections;
	using Chsword;
	using System.Collections.Generic;
	using CHSNS;
	//[Helper(typeof(ChHelper))]
	[Filter(ExecuteEnum.BeforeAction, typeof(LoginedFilter))]
	public class UploadController : BaseBlockController
	{
		#region Photo
		static readonly string[] EXTARR = { ".bmp", ".jpg", ".png", ".gif", ".jpeg" };
		//static readonly string extarr = "|.bmp|.jpg|.png|.gif|.jpeg|";

		public void photo(HttpPostedFile file1) {
			string itemID = "";//����Ǹ����е�����ID
			if (Request.QueryString["id"] != null) {
				itemID = Request.QueryString["id"];

				ViewData.Add("itemId", itemID);
			}
			string Albumid = Request.QueryString["albumid"];
			if (IsPost) {//��������
				//picPath = picServer;
				doUpload(file1, itemID, Albumid);
			}
		}
		protected void doUpload(HttpPostedFile file, string itemID, string Albumid) {
			//string picPath = "";
			//string picServer = "";
			string _photoPath;
			string _thumbPath;
			try {
				//Debug.Trace(picPath+strNewPath);
				if (file.ContentLength > 544800) {
					WriteJs("alert('�ļ��е��~����С��500K��;');parent.hideModalPopup();");
					return;
				}
				string ext = GetExtension(file.FileName);
				if (string.IsNullOrEmpty(ext)) {
					return;
				}
				string chfilename = GetSaveFilePath() + ext;

				_photoPath = ChAlumna.Path.ClientUserPhotosFolder() + chfilename;
				_thumbPath = ChAlumna.Path.ClientUserThumbFolder() + chfilename;
				_thumbPath = _thumbPath.Replace(ext, ".jpg");
				string photoserver = ChServer.MapPath(_photoPath);
				string thumbserver = ChServer.MapPath(_thumbPath);
				if (!System.IO.Directory.Exists(ChServer.MapPath(ChAlumna.Path.ClientUserPhotosFolder())))
					System.IO.Directory.CreateDirectory(ChServer.MapPath(ChAlumna.Path.ClientUserPhotosFolder()));
				if (!System.IO.Directory.Exists(ChServer.MapPath(ChAlumna.Path.ClientUserThumbFolder())))
					System.IO.Directory.CreateDirectory(ChServer.MapPath(ChAlumna.Path.ClientUserThumbFolder()));


				#region ����ͼ
				double imgWidth, imgHeight;
				System.Drawing.Image imgSrc;//, imgChange;
				imgSrc = System.Drawing.Image.FromStream(file.InputStream);
				//imgChange = imgSrc.GetThumbnailImage(0,0, null, new System.IntPtr());
				double b = imagewhb(imgSrc);
				if (b >= 0.75) {
					imgWidth = 130;
					imgHeight = 130 / b;
				} else {
					imgHeight = 130 / b;
					imgWidth = 130;
				}
				//Debug.Trace(thumbserver);
				//imgChange = imgSrc.GetThumbnailImage((int)imgWidth, (int)(imgHeight), null, new System.IntPtr());

				#region ��������ӵ����ݿ�

				Dictionary dict = new Dictionary();
				dict.Add("@photoname","");
				dict.Add("@Albumid", Convert.ToInt64(Albumid));
					dict.Add("@userid",ChUser.Current.Userid);
					dict.Add("@Path",chfilename);
					dict.Add("@FileSize",4000 + file.ContentLength);
				DoDataBase dd = new DoDataBase();
				string ret = dd.DoParameterSql("Photo_Add", dict);


				//Chsword.Execute.PhotoExecuter pe = new Chsword.Execute.PhotoExecuter();
				//pe.Ablumid = Convert.ToInt64(Albumid);
				//pe.Path = chfilename;
				//pe.Filesize = 4000 + file.ContentLength;
				//string ret = pe.Add();


				#endregion
				if (ret != "full") {
					file.SaveAs(photoserver);
					ChAlumna.Image.CreateThumbnail(
							imgSrc,
							thumbserver,
							(int)imgWidth,
							(int)imgHeight
						);
					//imgChange.Save(thumbserver, System.Drawing.Imaging.ImageFormat.Jpeg);
				}
				imgSrc.Dispose();
				//imgChange.Dispose();
				#endregion
				if (ret == "full") {
					WriteJs("alert('���Ĵ洢�ռ�����,�������Ա��ϵ~;');parent.hideModalPopup();");
					return;
				}
				string urlPath = _photoPath;
				urlPath = urlPath.Replace("\\", "/");

				ChCache cache = new ChCache();
				WriteJs("parent.uploadsuccess('" + string.Format(ChCache.GetConfig("Photos", "Upload_Successed"), urlPath) + "','" + itemID + "'); ");

			} catch (Exception ex) {
				WriteJs("parent.uploaderror('" + ex.Message + ex.StackTrace + "');");
			}
		}
		private string GetSaveFilePath() {
			return DateTime.Now.ToString("yyyyMMddHHmmssffff");
		}
		private string GetExtension(string fileName) {

			string ext = System.IO.Path.GetExtension(fileName).ToLower();
			if ((EXTARR as IList).Contains(ext))
				return ext;
			WriteJs("parent.uploaderror('ͼƬ��ʽ����Ϊjpg png gif ��jpeg');");
			return string.Empty;

		}

		#endregion



		#region face or img
		public void face(HttpPostedFile file1) {
			string itemID = Request.QueryString["id"];
			this.ViewData.Add("itemID", itemID);
			if (IsPost) {
				switch (Request.QueryString["type"].ToLower()) {
					case "userface":
						setUserFace("userface", file1, itemID);
						break;
					case "groupimg":
						setUserFace("groupimg", file1, itemID);
						break;
					default:
						break;
				}
			}
		}
		private void setUserFace(string mode, HttpPostedFile file,string itemID) {
			string fn = "";
			string serverpath = "";
			if (mode == "groupimg") {
				if (!string.IsNullOrEmpty(itemID))
					serverpath = ChAlumna.Path.GroupFolder(itemID);
				fn = itemID;
			}
			if (mode == "userface") {
				serverpath = ChAlumna.Path.UserFolder(ChUser.Current.Userid.ToString());
				fn = ChUser.Current.Userid.ToString().Substring(0, 3);
			}
			//Debug.Trace(mode + serverpath);

			if (string.IsNullOrEmpty(serverpath)) {
				WriteErr("error:·���д���");
				return;
			}
			string fp = string.Format("{0}face/", serverpath);
			string path = ChServer.MapPath(fp);
			System.IO.Directory.CreateDirectory(path);
		//	HttpPostedFile file = file1.PostedFile;
			if (file.ContentLength > 2004800) {
				WriteErr("error:�ļ���С��2M");
				return;
			}
			//HttpFileCollection MyFileColl = Request.Files;
		////	HttpPostedFile MyPostedFile = MyFileColl[0];
			bool fileOK = false;
			string fileExtension;
			fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
			string[] allowedExtensions = { ".bmp", ".jpg", ".jpeg", ".png", ".gif" };
			foreach (string alo in allowedExtensions) {
				if (alo == fileExtension) fileOK = true;
			}

			if (!fileOK) {
				WriteErr("error:���ϴ����ļ���չ������ȷ");
				return;
			}
			fileExtension = ".jpg";
			if (fileOK) {
				try {
					//file.SaveAs(string.Format("{0}{1}{2}", path, fn, fileExtension));
				} catch (Exception ex) {
					WriteErr("error:�ļ��޷��ϴ�:" + ex.Message);
					return;
				}
			} else {
				WriteErr("error:��ѡ����ȷ�ļ�·��");
				return;
			}
			#region ��������������ͼ

			double imgWidth, imgHeight;
			System.Drawing.Image imgSrc;//, imgChange;
			imgSrc = System.Drawing.Image.FromStream(file.InputStream);//MyPostedFile.InputStream);
			/*imgChange = imgSrc.GetThumbnailImage(0,0, null, new System.IntPtr());*/
			double b = imagewhb(imgSrc);

			try {
				Dictionary<int, ImgSize> changeDict = new Dictionary<int, ImgSize>();
				changeDict.Add(200, ImgSize.big);
				changeDict.Add(100, ImgSize.middle);
				changeDict.Add(50, ImgSize.small);
				changeDict.Add(20, ImgSize.tiny);
				foreach (KeyValuePair<int, ImgSize> keyvalue in changeDict) {
					if (b >= 0.75) {
						imgWidth = keyvalue.Key;
						imgHeight = keyvalue.Key / b;
					} else {
						imgHeight = 1.5 * keyvalue.Key;
						imgWidth = 1.5 * keyvalue.Key * b;
					}
					ChAlumna.Image.CreateThumbnail(
						imgSrc,
						string.Format("{0}{1}{3}{2}", path, fn, fileExtension, keyvalue.Value.ToString()),
						(int)imgWidth,
						(int)imgHeight
					);
				}
			} catch (Exception ex) {
				WriteErr(Debug.TraceBack("error:�ļ��޷��ϴ�:" + ex.Message + ex.StackTrace + ex.Source + string.Format("{0}{1}{3}{2}", path, fn, fileExtension, ImgSize.big.ToString())));
				return;
			}
			imgSrc.Dispose();
			//imgChange.Dispose();
			#endregion
			//Debug.Trace(Path.GetGroupImg(Session["userid"].ToString(), ImgSize.big));
			if (mode == "groupimg") {
				WriteJs("parent.uploadsuccess('" + Path.GetGroupImg(itemID, ImgSize.big) + "','" + itemID + "'); ");
				return;
			}
			if (mode == "userface") {
				SetStarLevel(ChSession.Userid);//����
				WriteJs("parent.uploadsuccess('" + Path.GetFace(ChUser.Current.Userid.ToString(), ImgSize.big) + "','" + itemID + "'); ");
				return;
			}
			WriteErr("error:δ֪����");
			//Global.User.SetStartLevel(Session("userid"))
			return;
		}
		public void SetStarLevel(long userid) {
			#region ˵��
			//�Ƿ�����ʵ�û�  ��־λ
			//	0				0			Ĭ�ϳ�ʼ
			//	1				0			��һ���ϴ�
			//	0				1			���δͨ��
			//	1				1			���ͨ��
			//	0,0  1,1->1,0
			//	0,1  1,0->����
			//''�Ǽ��û�������           0 0
			//'A���û��״��ϴ���Ƭʱ Ϊ    1 0 ��ʼ���û�������
			//'���û������ϴ�ʱΪ          0 1  ����
			//'���û�һ���ϴ�����Ϊ���Ϸ�ʱΪ 0 1 ����
			//'���û���˳ɹ��󶼽��� 1 1 Ϊ����
			//'0 0->1 0
			//'0 1->�ϴ��� Ϊ0 1
			//'1 1->�ϴ��� Ϊ1 0
			//'1 0->�ϴ�����Ϊ1 0
			#endregion
			System.Data.SqlClient.SqlParameter[] p = new System.Data.SqlClient.SqlParameter[1];
			p[0] = new System.Data.SqlClient.SqlParameter("@Userid", System.Data.SqlDbType.BigInt);
			p[0].Value = userid;
			DoDataBase dd = new DoDataBase();
			dd.DoParameterSql("SetStarLevel", p);
		}
		#endregion
		void WriteErr(string msg) {
			WriteJs("parent.uploaderror('" + msg + "');");
		}
		void WriteJs(string jsContent) {
			ViewData.Add("msg", "<script type='text/javascript'>" + jsContent.Replace(@"\", @"\\") + "</script>");
		}
		/// <summary>
		/// ͼƬ���ݱȴ���
		/// </summary>
		/// <param name="fn"></param>
		/// <returns></returns>
		double imagewhb(System.Drawing.Image img) {
			if (img.Height == 0)
				return 0;
			//System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(fn, true);
			return ((double)img.Width) / ((double)img.Height);

		}


	}
}