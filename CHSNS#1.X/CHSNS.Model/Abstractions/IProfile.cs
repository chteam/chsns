namespace CHSNS.Model
{
    public interface IProfile {
        long UserId { get; set; }

        string Name { get; set; }

        string Face { get; set; }

        int Status { get; set; }

        long Score { get; set; }

        long ShowScore { get; set; }

        long DelScore { get; set; }

        byte ShowLevel { get; set; }

        string MagicBox { get; set; }

        bool HasMagicBox { get; set; }

        System.DateTime RegTime { get; set; }

        System.DateTime LoginTime { get; set; }

        long ViewCount { get; set; }

        long FileSizeAll { get; set; }

        long FileSizeCount { get; set; }

        string Applications { get; set; }

        string Applicationlist { get; set; }

        //   string Ext { get; set; }
    }
}