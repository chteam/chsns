using Microsoft.AspNetCore.Mvc.Rendering;

namespace CHSNS {
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    public static class ConfigSerializerExt {
        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="cs"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static public List<SelectListItem> GetConfig(this ConfigSerializer cs, string key) {
            return cs.Load<List<SelectListItem>>(key);
        }
    }
}
