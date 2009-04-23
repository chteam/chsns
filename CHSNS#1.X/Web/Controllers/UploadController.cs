using System;
using System.Web;
using System.Web.Mvc;
using CHSNS.Config;

using System.Collections.Generic;
using Image=System.Drawing.Image;

namespace CHSNS.Controllers {
	//[Helper(typeof(ChHelper))]
	[LoginedFilter]
	public class UploadController : BaseController {
		#region Action
		public ActionResult File(string mode) {
			if (string.IsNullOrEmpty(mode))
				throw new Exception("����Ϊ��");
			var vd = new ListItem {
				Text = mode.ToLower()
			};
			return View(vd);
		}
		[LoginedFilter]
		[AcceptVerbs("Post")]
		public ActionResult Face(string mode) {
			var li = new ListItem {
				Text = mode,
				Value = UploadImage(Request.Files["file1"], Path.FaceMapPath(CHUser.UserID), true)
			};

			return View("File", li);
		}
		[NonAction]
		static string WriteErr(string msg) {
			return WriteJs("parent.uploaderror('" + msg + "');");
		}
		[NonAction]
		static string WriteJs(string jsContent) {
			return "<script type='text/javascript'>" + jsContent.Replace(@"\", @"\\") + "</script>";
		}
		[NonAction]
		public string UploadImage(HttpPostedFileBase file1, string serverfullpath, bool isSaveSource) {
			string fn = CHUser.UserID.ToString();
			if (string.IsNullOrEmpty(serverfullpath) || file1 == null) return WriteErr("error:·���д���");
	IOFactory.Folder.Create(serverfullpath);
			if (file1.ContentLength > 2004800) return WriteErr("error:�ļ���С��2M");
			string fileExtension =System.IO.Path.GetExtension(file1.FileName).ToLower();
			var AllowImageExt = ConfigSerializer.Load<List<string>>("AllowImageExt");

			bool fileOK = AllowImageExt.Contains(fileExtension);
			if (!fileOK) return WriteErr("error:���ϴ����ļ���չ������ȷ");
			fileExtension = ".jpg";

			try {
				if (isSaveSource)
					file1.SaveAs(string.Format("{0}{1}{2}", serverfullpath, fn, fileExtension));
			} catch (Exception ex) {
				return WriteErr("error:�ļ��޷��ϴ�:" + ex.Message);
			}
			#region ��������������ͼ
			Image imgSrc = Image.FromStream(file1.InputStream);
			try {
				foreach (ThumbnailPair keyvalue in ConfigSerializer.Load<List<ThumbnailPair>>("ThumbnailSize"))
					Thumbnail.CreateThumbnail(
						imgSrc,
						string.Format("{0}{1}{2}{3}", serverfullpath, fn, keyvalue.ImageType, fileExtension),
						keyvalue.Size.Width,
						keyvalue.Size.Height
						);
			} catch (Exception) {
			    return "";
                    //WriteErr(
                    //    Debug.TraceBack("error:�ļ��޷��ϴ�:" +
                    //    string.Format("{0}{1}{3}{2}", serverfullpath, fn, fileExtension, ThumbType.Big))
                    //    );

			}
			imgSrc.Dispose();
			#endregion
			//SetStarLevel(CHUser.UserID); //����
			return
				WriteJs("parent.uploadsuccess('" + Path.GetFace(CHUser.UserID.ToString(), ThumbType.Big) + "'); ");
		}

		#endregion
	}
}