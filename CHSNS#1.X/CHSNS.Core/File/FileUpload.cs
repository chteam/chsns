using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace CHSNS {
	public class FileUpload {
		public HttpPostedFileBase File { get; set; }
		public HttpContextBase HttpContext { get; set; }
		public double Size { get; set; }
		public string Path { get; set; }
		public IEnumerable<String> FileExtList { get; set; }

		public string Upload() {
			var ext = System.IO.Path.GetExtension(File.FileName).ToLower();
			if (FileExtList != null && FileExtList.Count() != 0 && FileExtList.Contains(ext))
				return "error:您上传的文件扩展名不正确";
			if (string.IsNullOrEmpty(Path) || File == null)
				return "error:路径有错误,无文件或目录为空";
			if (File.ContentLength > Size * 1000000)
				return string.Format("error:文件请小于{0}M", Size);
			var serverfullpath = HttpContext.Server.MapPath(Path);
			var path = System.IO.Path.GetDirectoryName(serverfullpath);
			if (System.IO.Directory.Exists(path))
				System.IO.Directory.CreateDirectory(path);
			File.SaveAs(serverfullpath);
			return Path;
		}

//        string UploadImage(HttpPostedFileBase file1, bool isSaveSource) {
//            var dt = DateTime.Now;
//            var path = Path.PhotoPath(dt);

////			var serverfullpath = Server.MapPath(path);
//            //if (string.IsNullOrEmpty(serverfullpath) || file1 == null) return "error:路径有错误,无文件或目录为空";
//            //if (file1.ContentLength > 2004800) return "error:文件请小于2M";

//            //System.IO.Directory.CreateDirectory(serverfullpath);

//        //	var fileExtension = System.IO.Path.GetExtension(file1.FileName).ToLower();
//        //	var AllowImageExt = ConfigSerializer.Load<List<string>>("AllowImageExt");

//        //	var fileOK = AllowImageExt.Contains(fileExtension);
//        //	if (!fileOK) return "error:您上传的文件扩展名不正确";
//            //  fileExtension = ".jpg";
//            var sourcefn = Path.SourcePhoto(CHUser.UserID, dt, fileExtension);
//            var photo = Path.Photo(CHUser.UserID, dt, fileExtension, "");
//            var ThumbPhoto = Path.ThumbPhoto(CHUser.UserID, dt, fileExtension);
//            try {
//                if (isSaveSource) file1.SaveAs(Server.MapPath(sourcefn));
//            } catch (Exception) {
//                return "error:文件无法上传，源文件无法保存";
//            }

//            #region 按比例生成缩略图
//            var imgSrc = Image.FromStream(file1.InputStream);
//            try {
//                Thumbnail.CreateThumbnail(
//                    imgSrc,
//                    Server.MapPath(photo),
//                    800,
//                    600
//                    );
//                Thumbnail.CreateThumbnail(
//                    imgSrc,
//                    Server.MapPath(ThumbPhoto),
//                    140,
//                    140
//                    );
//            } catch (Exception) {
//                return "error:文件无法上传，图没缩略";
//            }
//            imgSrc.Dispose();
//            #endregion
//            //SetStarLevel(CHUser.UserID); //更新
//            return photo;
//        }
	}
}
