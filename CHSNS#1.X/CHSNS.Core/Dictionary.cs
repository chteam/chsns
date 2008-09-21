using System;
using System.Collections.Generic;
using System.Text;

namespace CHSNS
{
	///<summary>�Զ�����ֵ�
	///</summary>
	public class Dictionary : Dictionary<string, object>
	{
		///<summary>����תΪ�ֵ�
		///</summary>
		///<param name="args"></param>
		///<returns></returns>
		///<exception cref="Exception"></exception>
		public static Dictionary CreateFromArgs(params object[] args)
		{
			if (args.Length%2 != 0)
				throw new Exception("����������������������");
			var dict = new Dictionary();
			for (int i = 0; i < args.Length; i += 2)
			{
				dict.Add(args[i].ToString(), args[i + 1]);
			}
			return dict;
		}
		public string ToJsonString() {
			StringBuilder sb = new StringBuilder("{");
			foreach(KeyValuePair<string,object> p in this ){
				sb.AppendFormat("{0}:'{1}',",p.Key, p.Value);
			}
			sb.Length--;
			sb.Append("}");
			return sb.ToString();
		}
	}
}