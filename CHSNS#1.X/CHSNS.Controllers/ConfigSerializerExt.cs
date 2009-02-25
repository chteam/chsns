using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS {
    public static class ConfigSerializerExt {
        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        static public List<ListItem> GetConfig(this ConfigSerializer cs, string key) {
            return cs.Load<List<ListItem>>(key);
        }
    }
}
