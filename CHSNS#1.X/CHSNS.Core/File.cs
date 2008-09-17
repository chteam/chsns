using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS
{
	public class File
	{
		public static string ReadAllText(string filename) {
			if (!filename.Contains(":"))
				filename = CHServer.MapPath(filename);
			if (Exists(filename))
				return System.IO.File.ReadAllText(filename);
			else
				return "Error:文件不存在";
		}

		public  static bool Exists(string filename)
		{
			return System.IO.File.Exists(filename);
		}
		public static void SaveAllText(string filename, string contents)
		{
			if (!filename.Contains(":"))
				filename = CHServer.MapPath(filename);
			System.IO.File.WriteAllText(filename, contents);
		}
	}
}
