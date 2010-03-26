using System;
using System.Web;
using System.Web.Mvc;
using CHSNS.Config;

using System.Collections.Generic;
using CHSNS.Model;
using Image=System.Drawing.Image;
using CHSNS.Models;

namespace CHSNS.Controllers {
    //[Helper(typeof(ChHelper))]
    [LoginedFilter]
    public class UploadController : BaseController {

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
            var uploadPath = CHContext.Path.UploadPath(CHUser.UserId);
            if (string.IsNullOrEmpty(uploadPath) || file1 == null) return WriteErr("error:·���д���");
            IOFactory.Folder.Create(uploadPath);
            if (file1.ContentLength > 2004800) return WriteErr("error:�ļ���С��2M");
            var fileExtension = System.IO.Path.GetExtension(file1.FileName).ToLower();
            if (!ConfigSerializer.Load<List<string>>("AllowImageExt").Contains(fileExtension)) 
                return WriteErr("error:���ϴ����ļ���չ������ȷ");
            var fileName = CHContext.Path.NewPhoto(CHUser.UserId, fileExtension);
            var photourl = System.IO.Path.Combine(uploadPath, fileName);
            if (isSaveSource) IOFactory.StoreFile.Save(file1.InputStream,photourl );
            //��������������ͼ
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
            //SetStarLevel(CHUser.UserId); //����
            DbExt.Photo.Add(new Photo
                                {
                                    Title = "ͷ��" + DateTime.Now.ToString("yyyyMMddhhmm"),
                                    UserId = CHUser.UserId,
                                    Summary = "",
                                    Domain = CHContext.Site.Upload.Domain,
                                    Url = photourl
                                });
            DbExt.UserInfo.ChangeFace(CHUser.UserId, System.IO.Path.Combine(CHContext.Site.Upload.Domain, photourl));
            //����ͷ���ַ
            //����ͷ���ַ�������
            return
                WriteJs("parent.uploadsuccess('" + CHContext.Path.ThumbUrl(photourl, ThumbType.Big, CHContext) + "'); ");
        }

    }
}