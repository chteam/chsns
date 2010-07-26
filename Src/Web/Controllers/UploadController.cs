using System;
using System.Web;
using System.Web.Mvc;
using CHSNS.Config;

using System.Collections.Generic;
using Image=System.Drawing.Image;
using CHSNS.Models;

namespace CHSNS.Controllers {
    //[Helper(typeof(ChHelper))]
    [Authorize]
    public partial class UploadController : BaseController
    {
       

        public virtual ActionResult File(string mode)
        {
            if (string.IsNullOrEmpty(mode))
                throw new ArgumentNullException("mode","不许为空");
            return Content("");
        }
        [Authorize]
        [HttpPost]
        public virtual ActionResult Face(HttpPostedFileBase filedata)
        {
            return UploadImage(filedata, true);
            
        }

        [NonAction]
        public ActionResult UploadImage(HttpPostedFileBase file1, bool isSaveSource)
        {
            var uploadPath = CHContext.Path.UploadPath(CHUser.UserId);
            if (string.IsNullOrEmpty(uploadPath) || file1 == null) return Content("error:路径有错误");
            IOFactory.Folder.Create(uploadPath);
            if (file1.ContentLength > 2004800) return Content("error:文件请小于2M");
            var fileExtension = System.IO.Path.GetExtension(file1.FileName).ToLower();
            if (!ConfigSerializer.Load<List<string>>("AllowImageExt").Contains(fileExtension)) 
                return Content("error:您上传的文件扩展名不正确");
            var fileName = CHContext.Path.NewPhoto(CHUser.UserId, fileExtension);
            var photourl = System.IO.Path.Combine(uploadPath, fileName);
            if (isSaveSource) IOFactory.StoreFile.Save(file1.InputStream,photourl );
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
            DataManager.Photo.Add(new Photo
                                {
                                    Title = "头像" + DateTime.Now.ToString("yyyyMMddhhmm"),
                                    UserId = CHUser.UserId,
                                    Summary = "",
                                    Domain = CHContext.Site.Upload.Domain,
                                    Url = photourl
                                });
            DataManager.UserInfo.ChangeFace(CHUser.UserId, System.IO.Path.Combine(CHContext.Site.Upload.Domain, photourl));
            //更新头像地址
            //将新头像地址存入相册
            return
                Content(CHContext.Path.ThumbUrl(photourl, ThumbType.Big, CHContext));
        }

    }
}