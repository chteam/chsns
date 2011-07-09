using System.Web.Mvc;

namespace CHSNS
{
    public static class EnumHelper
    {
        static public SelectList ToSelectList<T>() where T:struct
        {
            return new SelectList(EnumExtensions.ToDictionary<T>(), "Value", "Key");
        }
    }
}
