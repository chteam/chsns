using System;
using System.Collections.Generic;
using System.IO;

namespace Chsword
{
	/// <summary>
	/// �ļ�����
	/// </summary>
	public class File
	{
		/// <summary>
		/// ��UTF-8�����ȡ�ı��ļ���������
		/// </summary>
		/// <param name="fileName">�ļ���</param>
		/// <returns>�ļ�����</returns>
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
