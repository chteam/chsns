using System;

namespace CHSNS.Models.Abstractions {
    public interface IBasicInformation {
        long UserID { get; set; }

        string Name { get; set; }

        string Email { get; set; }

        bool IsEmailTrue { get; set; }

        bool? Sex { get; set; }

        DateTime? Birthday { get; set; }

        int ProvinceID { get; set; }

        long CityID { get; set; }

        byte ShowLevel { get; set; }
    }
}