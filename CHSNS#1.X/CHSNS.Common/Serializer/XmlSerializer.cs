using System;
using System.IO;
using System.Web;
namespace CHSNS
{
	public class XmlSerializer
	{
		/// <summary>
		/// 序列化到配置文件　
		/// </summary>
		/// <typeparam name="T">序列化此类型</typeparam>
		/// <param name="obj">要序列化的对象</param>
		/// <param name="fn">键值</param>
		public static void Save<T>(T obj, string fn) where T : class
		{
			
				var mySerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
				var filepath = HttpContext.Current.Server.MapPath(fn);
				if (!System.IO.File.Exists(filepath))
					System.IO.File.Create(filepath);
				if ((System.IO.File.GetAttributes(filepath)
					& FileAttributes.ReadOnly) == FileAttributes.ReadOnly) {
					System.IO.File.SetAttributes(filepath, FileAttributes.Archive);
				}
				using (var myWriter = new StreamWriter(filepath)) {
					mySerializer.Serialize(myWriter, obj);
				}
			try {}
			catch(Exception e)
			{
				throw new Exception(string.Format("存储配置文件{0}时出错,编号:{1}->{2}"
					, fn, 10359,e.Message));
			}
		}

		/// <summary>
		/// 从配置文件反序列化
		/// </summary>
		/// <parameters name="T">反序列化的目标类型</typeparam>
		/// <param name="fn">键</param>
		/// <returns></returns>
		public static T Load<T>(string fn) where T : class
		{
			
                var filepath = HttpContext.Current.Server.MapPath(fn);
                if (!System.IO.File.Exists(filepath))
                    System.IO.File.Create(filepath);
                if ((System.IO.File.GetAttributes(filepath)
                    & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    System.IO.File.SetAttributes(filepath, FileAttributes.Archive);
                }
				var mySerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                using (var myFileStream = new StreamReader(HttpContext.Current.Server.MapPath(fn)).BaseStream)
				{
					return mySerializer.Deserialize(myFileStream) as T;
				}
			try
			{}
			catch
			{
				throw new Exception(string.Format("读取配置文件{0}时出错,编号:{1}", fn, 10358));
			}
		}
	}
}
