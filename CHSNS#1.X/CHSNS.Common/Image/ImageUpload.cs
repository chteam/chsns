using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using CHSNS.Config;

namespace CHSNS {
    public class ImageUpload
    {
        public IContext Context { get; set; }
        public ImageUpload(IContext context)
        {
            Context = context;
        }
		private FileUpload FileUpload { get; set; }
		public DateTime Time { get; set; }
		public string Ext { get; set; }
		public IEnumerable<ThumbnailPair> ThumbDict { get; set; }
		public ImageUpload(HttpPostedFileBase file, 
			HttpContextBase context, 
			IEnumerable<string> ext,
			DateTime dt,IEnumerable<ThumbnailPair> thumbdict){
			ThumbDict = thumbdict;
			Time = dt;
			Ext = System.IO.Path.GetExtension(file.FileName);
			FileUpload = new FileUpload {
			                            	File = file,
			                            	FileExtList = ext,
			                            	HttpContext = context,
                                            Path = Path.Photo(Context.User.UserID, Time, Ext, "source"),
			                            	Size = 2,
			                            };
		}
		public string Upload(){
			if (!FileUpload.Validate()) return FileUpload.Log;
			#region 按比例生成缩略图

			FileUpload.ExistsCreateDictionary(FileUpload.HttpContext.Server.MapPath(FileUpload.Path));
			var imgSrc = Image.FromStream(FileUpload.File.InputStream);
			foreach (var p in ThumbDict) {
				Thumbnail.CreateThumbnail(
					imgSrc,
					FileUpload.HttpContext.Server.MapPath(
                        Path.Photo(Context.User.UserID, Time, Ext, p.ImageType.ToString())),
					p.Size
					);
			}
			imgSrc.Dispose();

			#endregion

			return FileUpload.Path;
		}
	}
}
