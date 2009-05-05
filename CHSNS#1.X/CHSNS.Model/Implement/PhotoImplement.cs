using System;
using CHSNS.Abstractions;

namespace CHSNS.Model{
    public class PhotoImplement :IPhoto{
        #region Implementation of IPhoto

        public long Id { get; set; }
        public string Title { get; set; }
        public long? AlbumId { get; set; }
        public long UserId { get; set; }
        public DateTime AddTime { get; set; }
        public long Order { get; set; }
        public string Ext { get; set; }
        public int Status { get; set; }

        #endregion
    }
}