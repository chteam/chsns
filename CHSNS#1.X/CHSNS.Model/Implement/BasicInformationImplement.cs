using System;
using CHSNS.Abstractions;

namespace CHSNS.Model
{
    public class BasicInformationImplement
    : IBasicInformation
    {
        public long UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsEmailTrue { get; set; }
        public bool? Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public int ProvinceID { get; set; }
        public long CityID { get; set; }
        public byte ShowLevel { get; set; }
    }
}