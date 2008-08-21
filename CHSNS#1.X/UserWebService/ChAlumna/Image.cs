/*
 * Created by 邹健
 * Date: 2007-12-2
 * Time: 9:24
 * 
 * 
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace CHSNS
{
	/// <summary>
	/// Description of Image.
	/// </summary>
	public class Image
	{
		static public void CreateThumbnail(System.Drawing.Image img, string newFile, int maxWidth, int maxHeight){
			//System.Drawing.Image img = bigimg;
	 		//System.Drawing.Imaging.ImageFormat thisFormat = ;
			Size newSize = NewSize(maxWidth, maxHeight, img.Width, img.Height);
			Bitmap outBmp = new Bitmap(newSize.Width, newSize.Height);
			Graphics g = Graphics.FromImage(outBmp);
			// 设置画布的描绘质量
			g.CompositingQuality = CompositingQuality.HighQuality;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.DrawImage(img, new Rectangle(0, 0, newSize.Width, newSize.Height),
			            0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
			g.Dispose();
			// 以下代码为保存图片时，设置压缩质量
			EncoderParameters encoderParams = new EncoderParameters();
			long[] quality = new long[1];
			quality[0] = 90;
			EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
			encoderParams.Param[0] = encoderParam;

			//获得包含有关内置图像编码解码器的信息的ImageCodecInfo 对象。
			ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
			ImageCodecInfo jpegICI = null;
			for (int x = 0; x < arrayICI.Length; x++)   {
				if (arrayICI[x].FormatDescription.Equals("JPEG")){
					jpegICI = arrayICI[x];//设置JPEG编码
					break;
				}
			}
			if (jpegICI != null)   {
					outBmp.Save(newFile, jpegICI, encoderParams);
			}else  {
				outBmp.Save(newFile, img.RawFormat);
			}
			//img.Dispose();
			outBmp.Dispose();
		}
		static private Size NewSize(int maxWidth, int maxHeight, int width, int height){
			double w = 0.0;
			double h = 0.0;
			double sw = Convert.ToDouble(width);
			double sh = Convert.ToDouble(height);
			double mw = Convert.ToDouble(maxWidth);
			double mh = Convert.ToDouble(maxHeight);
			if(sw<mw && sh<mh){
				w = sw;
				h = sh;
			}else if ( (sw/sh) > (mw/mh) ){
				w = maxWidth;
				h = (w * sh)/sw;
			}else{
				h = maxHeight;
				w = (h * sw)/sh;
			}
			return new Size(Convert.ToInt32(w), Convert.ToInt32(h));
		}
	}
}
