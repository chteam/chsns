using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS
{
	public static class DateTimeExtension
	{
		public static string Ago(this DateTime target)
		{
			var result = new StringBuilder();
			TimeSpan diff = (DateTime.Now - target.ToLocalTime());

			if (diff.Days > 0)
			{
				result.AppendFormat("{0} 天", diff.Days);
			}

			if (diff.Hours > 0)
			{
				if (result.Length > 0)
				{
					result.Append(", ");
				}

				result.AppendFormat("{0} 小时", diff.Hours);
			}

			if (diff.Minutes > 0)
			{
				if (result.Length > 0)
				{
					result.Append(", ");
				}

				result.AppendFormat("{0} 分钟", diff.Minutes);
			}

			if (result.Length == 0)
			{
				result.Append("刚刚");
			}
			else {
				result.Append("前");
			}

			return result.ToString();
		}
	}
}
