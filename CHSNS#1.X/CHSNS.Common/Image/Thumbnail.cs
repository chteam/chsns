using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;

namespace CHSNS {
	///<summary>
	/// 生成缩略图的类
	///</summary>
	public class Thumbnail {
        static public void CreateThumbnail(Image img, string newFile, Size size, IIOFactory ioFactory) {
            CreateThumbnail(img, newFile, size.Width, size.Height, ioFactory);
		}

		///<summary>
		/// 生成缩略图，并自动按比例缩放
		///</summary>
		///<param name="img">图片</param>
		///<param name="fileName">要存的地址</param>
		///<param name="maxWidth">最大宽</param>
		///<param name="maxHeight">最大高</param>
		///<param name="ioFactory"></param>
        static public void CreateThumbnail(Image img, string fileName, int maxWidth, int maxHeight, IIOFactory ioFactory)
		{
		    var newSize = NewSize(maxWidth, maxHeight, img.Width, img.Height);

		    var i = img.GetThumbnailImage(newSize.Width, newSize.Height, null, IntPtr.Zero);
		    using (Stream stream = new MemoryStream())
		    {
		        i.Save(stream, img.RawFormat);
		        ioFactory.StoreFile.SaveImage(stream, fileName);
		    }
		    return;
		    //using (var g = Graphics.FromImage(outBmp))
		    //{
		    //    // 设置画布的描绘质量
		    //    g.CompositingQuality = CompositingQuality.HighQuality;
		    //    g.SmoothingMode = SmoothingMode.HighQuality;
		    //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
		    //    g.DrawImage(img, new Rectangle(0, 0, newSize.Width, newSize.Height), 0, 0, img.Width, img.Height,
		    //                GraphicsUnit.Pixel);
		    //}
		    //// 以下代码为保存图片时，设置压缩质量

		    //var quality = new long[] {90};
		    //var encoderParam = new EncoderParameter(Encoder.Quality, quality);
		    //var encoderParams = new EncoderParameters();
		    //encoderParams.Param[0] = encoderParam;
		    ////获得包含有关内置图像编码解码器的信息的ImageCodecInfo 对象。
		    ////   var arrayIci =;
		    //var jpegIci = ImageCodecInfo.GetImageEncoders().Where(c => c.FormatDescription.Equals("JPEG")).Single();
		    ////throw new Exception(fileName);
		    //using (Stream stream = new MemoryStream())
		    //{
		    //    if (jpegIci != null)
		    //        outBmp.Save(stream, jpegIci, encoderParams);
		    //    else
		    //        outBmp.Save(stream, img.RawFormat);
		    //    ioFactory.StoreFile.Save(stream, fileName);
		    //}

		}

	    static private Size NewSize(int maxWidth, int maxHeight, int width, int height) {
			double w;
			double h;
			var sw = Convert.ToDouble(width);
			var sh = Convert.ToDouble(height);
			var mw = Convert.ToDouble(maxWidth);
			var mh = Convert.ToDouble(maxHeight);
			if (sw < mw && sh < mh) {
				w = sw;
				h = sh;
			} else if ((sw / sh) > (mw / mh)) {
				w = maxWidth;
				h = (w * sh) / sw;
			} else {
				h = maxHeight;
				w = (h * sw) / sh;
			}
			return new Size(Convert.ToInt32(w), Convert.ToInt32(h));
		}
		/// <summary>
		/// 图片横纵比处理
		/// </summary>
		/// <returns></returns>
		static public double ImageWhb(Image img) {
			if (img.Height == 0)
				return 0;
			//System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(fn, true);
			return ((double)img.Width) / img.Height;

		}
	}
}
