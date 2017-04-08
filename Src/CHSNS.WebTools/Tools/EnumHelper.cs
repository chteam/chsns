using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CHSNS
{
    public static class EnumHelper
    {
        public static SelectList ToSelectList<T>() where T:struct
        {
            return new SelectList(EnumExtensions.ToDictionary<T>(), "Value", "Key");
        }
    }
}
