using System;
using System.Collections.Generic;
using System.Web;

namespace CHSNS {
    public interface IFileProcess {
        HttpPostedFileBase File { get; set; }

        /// <summary>
        /// 单位：M
        /// </summary>
        double Size { get; set; }
        IPathBuilder PathBuilder { get; set; }
        IEnumerable<String> FileExtList { get; set; }
        string Log { get; set; }
        void ExistsCreateDictionary();
        bool Validate();
        string Save();
    }
}
