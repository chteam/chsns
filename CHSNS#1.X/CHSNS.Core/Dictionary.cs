using System;
using System.Collections.Generic;

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
	}
}