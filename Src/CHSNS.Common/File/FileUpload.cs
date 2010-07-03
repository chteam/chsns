using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHSNS
{
    public class FileUpload : IFileProcess
    {
        public FileUpload(IIOFactory ioFactory)
        {
            IOFactory = ioFactory;
        }

        private IIOFactory IOFactory { get; set; }

        public HttpPostedFileBase File { get; set; }

        #region IFileProcess Members

        /// <summary>
        /// 单位：M
        /// </summary>
        public double Size { get; set; }

        public IPathBuilder PathBuilder { get; set; }
        public IEnumerable<String> FileExtList { get; set; }
        public string Log { get; set; }

        public void ExistsCreateDictionary()
        {
            string path = System.IO.Path.GetDirectoryName(PathBuilder.DescPath);
            if (! IOFactory.Folder.Exists(path))
                IOFactory.Folder.Create(path);
        }

        public bool Validate()
        {
            string ext = System.IO.Path.GetExtension(File.FileName).ToLower();
            if (FileExtList != null && FileExtList.Count() != 0 && !FileExtList.Contains(ext))
            {
                Log = "error:您上传的文件扩展名不正确";
                return false;
            }
            if (string.IsNullOrEmpty(PathBuilder.DescPath) || File == null)
            {
                Log = "error:路径有错误,无文件或目录为空";
                return false;
            }
            if (File.ContentLength > Size*1000000)
            {
                Log = string.Format("error:文件请小于{0}M", Size);
                return false;
            }
            return true;
        }

        public string Save()
        {
            if (!Validate()) return Log;
            ExistsCreateDictionary();
            File.SaveAs(PathBuilder.DescPath);
            return PathBuilder.SourcePath;
        }

        #endregion
    }
}