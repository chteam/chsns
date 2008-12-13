using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Web;
using System.IO;

namespace CHSNS {
	/// <summary>
	/// �ַ�����ʽ������
	/// AU:�޽�
	/// </summary>
	public class Regular {

		#region �Ը��ı��༭�����ݽ��и�ʽ��
		/// <summary>
		/// ��ʽ��title
		/// </summary>
		/// <param name="str">Ҫ��ʽ�����ַ���</param>
		/// <returns></returns>
		public string FormatTitle(string str) {
			return str;
		}

		/// <summary>
		/// ���ı�����
		/// </summary>
		/// <param name="str">Դ�ı�</param>
		/// <returns>���˺���ı�</returns>
		static public String FormatRichEdit(String str) {
			const string f = "EditFormat";
			var dom = new XmlDocument();
			if (CHCache.IsNullorEmpty(f))
				if (!CHCache.SetCache(f))
					return "���������ļ��޷�����";
			dom.LoadXml(HttpContext.Current.Cache[f].ToString());
			XmlNodeList nl = dom.SelectNodes("/root/item");
			if (nl != null)
				foreach (XmlNode xn in nl) {
					str = Regex.Replace(str,
					                    xn.InnerText,
					                    @"", RegexOptions.IgnoreCase);
				}
			//str = str.Replace("\n", "<br>");
			return str;
		}
		#endregion
		#region ����ƥ��
		/// <summary>
		/// �ַ����Ƿ���Ϲ���
		/// </summary>
		/// <param name="s">Ҫ��ѯ���ַ���</param>
		/// <param name="right">������ʽ</param>
		/// <returns>�Ƿ�ƥ��</returns>
		static public Boolean Macth(String s, String right) {
			var Regex = new Regex(right, RegexOptions.IgnoreCase);
			return Regex.IsMatch(s);
		}

		static public string[] Trim(string[] val) {
			for (int i = 0; i < val.Length; i++) {
				val[i] = val[i].Trim();
			}
			return val;
		}

		#endregion


		#region ��Ȥ���ø�ʽ��
		/// <summary>
		/// ���ָ����淶��Ϊ','
		/// </summary>
		/// <param name="str">Ҫ�淶���ı�</param>
		/// <returns>�淶����ı�,��','����</returns>
		static public String FormatJoin(String str) {
			if (String.IsNullOrEmpty(str))
				return ",";
			var sbout = new StringBuilder(str);
			sbout.Replace("\n", ",");
			sbout.Replace(";", ",");
			sbout.Replace("��", ",");
			sbout.Replace("��", ",");
			if (!sbout.ToString().EndsWith(","))
				sbout.Append(",");
			return HttpContext.Current.Server.HtmlEncode(sbout.ToString().Trim());
		}
		/// <summary>
		/// ���ָ����淶��Ϊ',',�Դ��ݸ����ݿ�
		/// </summary>
		/// <param name="str">Ҫ�淶���ı�</param>
		/// <returns>�淶����ı�,��','����,������ַ���Ϊ��,�򷵻�System.DBNull.Value</returns>
		static public Object FormatLove(object str) {
			string ret = FormatJoin(str.ToString());
			if (ret == "," || string.IsNullOrEmpty(ret))
				return DBNull.Value;
			return ret;
		}
		#endregion

		#region ȥ��HTMLע��
		/// <summary>
		/// ȥ��HTMLע��
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		static internal String ClearRemarks(String str) {
			str = Regex.Replace(str,
								@"<!--(.|\n)+?-->",
								"", RegexOptions.IgnoreCase);
			return str;
		}
		#endregion

		#region ����ַ����е�ͨ���....
		/// <summary>
		/// ȥ���ı��е�ͨƥ��
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		static public string ClearWildcard(string str) {
			return str.Replace("%", "").Replace("*", "");
		}
		#endregion
		#region ��������ת����������
		static readonly string[] _HuaNum ={
			"һ","��","��","��","��","��","��","��","��"
		};
		static readonly string[] _Number ={
			"1","2","3","4","5","6","7","8","9"
		};
		/// <summary>
		/// ��������ת����������
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		static public string HuaNumtoNumber(string str) {
			var sbout = new StringBuilder(str);
			for (int i = 0; i < _HuaNum.Length; i++) {
				sbout.Replace(_HuaNum[i], _Number[i]);
			}
			return sbout.ToString();
		}
		#endregion
		/// <summary>
		/// �ַ���Ϊ''���ʱתΪSystem.DBNull.Value
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		static public object StringNull(string str)
		{
			if (string.IsNullOrEmpty(str))
				return DBNull.Value;
			return str.Trim();
		}

		#region UTF�뺺�ֱ���
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		static public string UnicodeToChinese(string str) {
			return ConvertTo(str, "unicode");
		}
		static string ConvertTo(string str, string encode) {
			var tmpStr = new StringBuilder();
			for (int i = 0; i < str.Length; i++) {
				if (str[i] == '\\' && str[i + 1] == 'u') {
					string s1 = str.Substring(i + 2, 2);
					string s2 = str.Substring(i + 4, 2);
					int t1 = Convert.ToInt32(s1, 16);
					int t2 = Convert.ToInt32(s2, 16);
					var array = new byte[2];
					array[0] = (byte)t2;
					array[1] = (byte)t1;
					string s = Encoding.GetEncoding(encode).GetString(array);
					tmpStr.Append(s);
					i = i + 5;
				} else { tmpStr.Append(str[i]); }
			}
			return tmpStr.ToString();
		}
		#endregion
	
		static public string SexName(object b) {
			bool _b;
			if (bool.TryParse(b.ToString(), out _b)) {
				return _b ? "����" : "Ů��";
			}
			return "δ����";
		}
		/// <summary>
		/// �ֽ����ļ���С�ַ����Ƚ�
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static string BytesToString(long bytes) {
			if (bytes < 1024L) {
				return (bytes + " B");
			}
			if (bytes < 1048576L) {
				return string.Format("{0:N2} KB", bytes / 1024f);
			}
			if (bytes < 1073741824L) {
				return string.Format("{0:N2} MB", bytes / 1048576f);
			}
			return string.Format("{0:N2} GB", bytes / 1.073742E+09f);
		}
		/// <summary>
		/// �ļ����ֽڴ�С
		/// </summary>
		/// <param name="dir"></param>
		/// <returns></returns>
		public static long DiskUsage(string dir) {
			string[] files = Directory.GetFiles(dir);
			string[] directories = Directory.GetDirectories(dir);
			long num = 0L;
			for (int i = 0; i < files.Length; i++) {
				var info = new FileInfo(files[i]);
				num += info.Length;
			}
			for (int j = 0; j < directories.Length; j++) {
				num += DiskUsage(directories[j]);
			}
			return num;
		}

	}
}
