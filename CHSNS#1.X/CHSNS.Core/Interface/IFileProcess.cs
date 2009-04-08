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
        string ServerPath { get; set; }
        IEnumerable<String> FileExtList { get; set; }
        string Log { get; set; }
        void ExistsCreateDictionary(string path);
        bool Validate();
        string Save();
    }
}
