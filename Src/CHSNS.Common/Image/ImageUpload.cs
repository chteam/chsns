using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using CHSNS.Common.PathBuilder;
using CHSNS.Config;

namespace CHSNS {
    public class ImageUpload
    {
        public IContext Context { get; set; }
		private FileUpload FileUpload { get; set; }
		public DateTime Time { get; set; }
		public string Ext { get; set; }
		public IEnumerable<ThumbnailPair> ThumbDict { get; set; }
		public ImageUpload(HttpPostedFileBase file, 
			IContext context, 
			IEnumerable<string> ext,
			DateTime dt,IEnumerable<ThumbnailPair> thumbdict){
			ThumbDict = thumbdict;
			Time = dt;
            Context = context;
			Ext =  System.IO.Path.GetExtension(file.FileName);
            FileUpload = new FileUpload(Context.IOFactory) {
		                                   File = file,
		                                   FileExtList = ext,
		                                   //HttpContext = context,
		                                   PathBuilder = new ServerPathBuilder(Context.HttpContext.Server,
		                                                                       Path.Photo(Context.User.UserId, Time, Ext,
		                                                                                  "source")
		                                       ),
		                                   Size = 2,
		                               };
		}
		public string Upload(){
			if (!FileUpload.Validate()) return FileUpload.Log;
			#region 按比例生成缩略图

            FileUpload.ExistsCreateDictionary();
			using(var imgSrc = Image.FromStream(FileUpload.File.InputStream))
			{
			    foreach (var p in ThumbDict)
			    {
			        Thumbnail.CreateThumbnail(
			            imgSrc,
			            Context.HttpContext.Server.MapPath(
			                Path.Photo(Context.User.UserId, Time, Ext, p.ImageType.ToString())),
			            p.Size, Context.IOFactory
			            );
			    }
			}

		    #endregion

		    return FileUpload.PathBuilder.DescPath;
		}
	}
}
