using System;

namespace CHSNS.Abstractions {
    public interface IBasicInformation {
        long UserId { get; set; }

        string Name { get; set; }

        string Email { get; set; }

        bool IsEmailTrue { get; set; }

        bool? Sex { get; set; }

        DateTime? Birthday { get; set; }

        int ProvinceId { get; set; }

        long CityId { get; set; }

        byte ShowLevel { get; set; }
    }
}