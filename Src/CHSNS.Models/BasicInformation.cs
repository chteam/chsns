using System.ComponentModel.DataAnnotations.Schema;using System.ComponentModel.DataAnnotations;

namespace CHSNS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;using System.ComponentModel.DataAnnotations;

    public partial class BasicInformation
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.None)]
        public virtual long UserId { get; set; }

        [Display(Name = "姓名", Description = "222", GroupName = "GroupName", ShortName = "short name")]
        public string Name { get; set; }

        [Display(Name = "电子邮箱")]
        public string Email { get; set; }

        [Display(Name = "性别")]
        public bool? Sex { get; set; }

        [Display(Name = "出生时间")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [UIHint("DateTime")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "省")]
        public int ProvinceId { get; set; }

        [Display(Name = "市")]
        public long CityId { get; set; }

        [Display(Name = "可见度")]
        public byte ShowLevel { get; set; }

        public virtual bool IsEmailTrue { get; set; }
    }
}