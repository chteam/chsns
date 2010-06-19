using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CHSNS.Models
{
    [MetadataType(typeof(BasicInformationMeta))]
    public partial class BasicInformation
    {

        sealed class BasicInformationMeta
        {
            [DisplayName("姓名")]
            public string Name { get; set; }
            [DisplayName("电子邮箱")]
            public string Email { get; set; }
            [DisplayName("性别")]
            public bool? Sex { get; set; }
            [DisplayName("出生时间")]
            public DateTime? Birthday { get; set; }
            [DisplayName("省")]
            public int ProvinceId { get; set; }
            [DisplayName("市")]
            public long CityId { get; set; }
            [DisplayName("可见度")]
            public byte ShowLevel { get; set; }
        }
    }
}
