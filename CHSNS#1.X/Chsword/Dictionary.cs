namespace ChAlumna
{
	using System.Collections.Generic;
	using System;
	public class Dictionary : Dictionary<string,object>
	{
		public static Dictionary CreateFromArgs(params object[] args) {
			if (args.Length % 2 != 0)
				throw new Exception("不可以有奇数个传入数据");
			Dictionary dict = new Dictionary();
			for (int i = 0; i < args.Length; i += 2) {
				dict.Add(args[i].ToString(), args[i + 1]);
			}
			return dict;
		}
	}
}
