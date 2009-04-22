using System;
using CHSNS.Models.Abstractions;

namespace CHSNS.Model{
    public class ProfileImplement : IProfile
    {
        public long UserID { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public long Score { get; set; }
        public long ShowScore { get; set; }
        public long DelScore { get; set; }
        public byte ShowLevel { get; set; }
        public string MagicBox { get; set; }
        public bool IsMagicBox { get; set; }
        public DateTime RegTime { get; set; }
        public DateTime LoginTime { get; set; }
        public long ViewCount { get; set; }
        public long FileSizeAll { get; set; }
        public long FileSizeCount { get; set; }
        public string Applications { get; set; }
        public string Applicationlist { get; set; }
        public string Ext { get; set; }
    }
}