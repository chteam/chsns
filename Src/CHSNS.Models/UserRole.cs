using System.ComponentModel.DataAnnotations.Schema;using System.ComponentModel.DataAnnotations;

namespace CHSNS.Models
{
    using System.ComponentModel.DataAnnotations.Schema;using System.ComponentModel.DataAnnotations;

    public class UserRole
    {
        [Key, Column(Order = 0)]
        public virtual long UserId { get; set; }

        [Key, Column(Order = 1)]
        public virtual long RoleId { get; set; }
    }
}