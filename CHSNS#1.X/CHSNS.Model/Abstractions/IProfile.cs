namespace CHSNS.Abstractions {
    public interface IProfile {
        long UserID { get; set; }

        string Name { get; set; }

        int Status { get; set; }

        long Score { get; set; }

        long ShowScore { get; set; }

        long DelScore { get; set; }

        byte ShowLevel { get; set; }

        string MagicBox { get; set; }

        bool IsMagicBox { get; set; }

        System.DateTime RegTime { get; set; }

        System.DateTime LoginTime { get; set; }

        long ViewCount { get; set; }

        long FileSizeAll { get; set; }

        long FileSizeCount { get; set; }

        string Applications { get; set; }

        string Applicationlist { get; set; }

        string Ext { get; set; }
    }
}