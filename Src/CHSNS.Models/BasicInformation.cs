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

        [Display(Name = "����", Description = "222", GroupName = "GroupName", ShortName = "short name")]
        public string Name { get; set; }

        [Display(Name = "��������")]
        public string Email { get; set; }

        [Display(Name = "�Ա�")]
        public bool? Sex { get; set; }

        [Display(Name = "����ʱ��")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [UIHint("DateTime")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "ʡ")]
        public int ProvinceId { get; set; }

        [Display(Name = "��")]
        public long CityId { get; set; }

        [Display(Name = "�ɼ���")]
        public byte ShowLevel { get; set; }

        public virtual bool IsEmailTrue { get; set; }
    }
}