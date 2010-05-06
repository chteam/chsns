using System;
using System.Reflection;

namespace MvcHelper
{
    /// <summary>
    /// General extension methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns>Textual description of the Enum.</returns>
        public static string GetDescription(this Enum enumeration)
        {
            Type type = enumeration.GetType();

            MemberInfo[] memInfo = type.GetMember(enumeration.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute) attrs[0]).Text;
                }
            }

            return enumeration.ToString();
        }
    }
}
