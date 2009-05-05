using System;
using System.Web;
using System.Web.Mvc;
using CHSNS.Config;

using System.Collections.Generic;
using CHSNS.Model;
using Image=System.Drawing.Image;

namespace CHSNS.Controllers {
    //[Helper(typeof(ChHelper))]
    [LoginedFilter]
    public class UploadController : BaseController {

        public ActionResult File(string mode) {
            if (string.IsNullOrEmpty(mode))
                throw new Exception("不许为空");
            var vd = new ListItem {
                Text = mode.ToLower()
            };
            return View(vd);
        }
        [LoginedFilter]
        [AcceptVerbs("Post")]
        public ActionResult Face(string mode, HttpPostedFileBase file1) {
            var li = new ListItem {
                Text = mode,
                Value = UploadImage(file1, true)
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
        public string UploadImage(HttpPostedFileBase file1, bool isSaveSource)
        {
            var uploadPath = CHContext.Path.UploadPath(CHUser.UserID);
            if (string.IsNullOrEmpty(uploadPath) || file1 == null) return WriteErr("error:路径有错误");
            IOFactory.Folder.Create(uploadPath);
            if (file1.ContentLength > 2004800) return WriteErr("error:文件请小于2M");
            var fileExtension = System.IO.Path.GetExtension(file1.FileName).ToLower();
            if (!ConfigSerializer.Load<List<string>>("AllowImageExt").Contains(fileExtension)) 
                return WriteErr("error:您上传的文件扩展名不正确");
            var fileName = CHContext.Path.NewPhoto(CHUser.UserID, fileExtension);
            if (isSaveSource) IOFactory.StoreFile.Save(file1.InputStream, System.IO.Path.Combine(uploadPath, fileName));
            //按比例生成缩略图
            using (var imgSrc = Image.FromStream(file1.InputStream))
            {
                foreach (var keyvalue in ConfigSerializer.Load<List<ThumbnailPair>>("ThumbnailSize"))
                    Thumbnail.CreateThumbnail(
                        imgSrc,
                        CHContext.Path.ThumbPhoto(fileName, keyvalue.ImageType),
                        keyvalue.Size.Width,
                        keyvalue.Size.Height,
                        IOFactory
                        );
            }
            //SetStarLevel(CHUser.UserId); //更新
            DbExt.Photo.Add(new PhotoImplement
                                {
                                    Title = "头像" + DateTime.Now.ToString("yyyyMMddhhmm"),
                                    UserId=CHUser.UserID,
                                    
                                });
            //更新头像地址
            //将新头像地址存入相册
            return
                WriteJs("parent.uploadsuccess('" + Path.GetFace(CHUser.UserID.ToString(), ThumbType.Big) + "'); ");
        }

    }
}