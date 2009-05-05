using System;
using CHSNS.Abstractions;

namespace CHSNS.Model
{
    public class BasicInformationImplement
    : IBasicInformation
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsEmailTrue { get; set; }
        public bool? Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public int ProvinceId { get; set; }
        public long CityId { get; set; }
        public byte ShowLevel { get; set; }
    }
}