using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CHSNS.Models
{
    [MetadataType(typeof(BasicInformationMeta))]
    public partial class BasicInformation
    {

        public sealed class BasicInformationMeta
        {
            [Display(Name="姓名",Description="222",GroupName="GroupName",ShortName="short name")]
            
            public string Name { get; set; }
            [Display(Name="电子邮箱")]
            public string Email { get; set; }
            [Display(Name="性别")]
            public bool? Sex { get; set; }
            [Display(Name="出生时间")]
            [DataType(DataType.DateTime)]
            [DisplayFormat(DataFormatString = "{0:d}")]
            public DateTime Birthday { get; set; }
            [Display(Name="省")]
            public int ProvinceId { get; set; }
            [Display(Name="市")]
            public long CityId { get; set; }
            [Display(Name="可见度")]
            public byte ShowLevel { get; set; }
        }
    }
}
