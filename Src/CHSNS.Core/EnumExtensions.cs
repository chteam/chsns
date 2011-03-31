using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel;

namespace CHSNS {
	public static class EnumExtensions {
	    /// <summary>
	    /// 转为Dictionary
	    /// </summary>
	    /// <typeparam name="T"></typeparam>
	    /// <returns></returns>
	    static public IDictionary<string, int> ToDictionary<T>() {
            return Enum.GetValues(typeof(T))
                .Cast<Int32>()
                .ToDictionary(currentItem => ToDescription((Enum)Enum.Parse(typeof(T), currentItem.ToString())));
		}

        static public string ToDescription(this Enum e)
        {
            Type type = e.GetType();
            MemberInfo[] memInfo = type.GetMember(e.ToString());
            if (memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return e.ToString();

        }

		
	}
}
