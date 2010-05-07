using System;
using System.Reflection;

namespace MvcHelper
{
    public static class Extensions
    {
        public static string GetDescription(this Enum enumeration)
        {
            Type type = enumeration.GetType();

            MemberInfo[] memInfo = type.GetMember(enumeration.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Text;
                }
            }

            return enumeration.ToString();
        }
    }
}
