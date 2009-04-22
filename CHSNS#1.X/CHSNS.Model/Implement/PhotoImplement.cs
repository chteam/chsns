using System;
using CHSNS.Abstractions;

namespace CHSNS.Model{
    public class PhotoImplement :IPhoto{
        #region Implementation of IPhoto

        public long ID { get; set; }
        public string Name { get; set; }
        public long? AlbumID { get; set; }
        public long UserID { get; set; }
        public DateTime AddTime { get; set; }
        public long Order { get; set; }
        public string Ext { get; set; }
        public int Status { get; set; }

        #endregion
    }
}