using System;
using System.Collections.Generic;
using System.IO;

namespace Chsword
{
	/// <summary>
	/// 文件操作
	/// </summary>
	public class File
	{
		/// <summary>
		/// 以UTF-8编码读取文本文件所有内容
		/// </summary>
		/// <param name="fileName">文件名</param>
		/// <returns>文件内容</returns>
		static public String ReadAllText(String fileName) {
			String text = "undefine";
			if(System.IO.File.Exists(fileName))
			using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.UTF8)) {
				text = sr.ReadToEnd();
			}
			return text;
		}
	}
}
