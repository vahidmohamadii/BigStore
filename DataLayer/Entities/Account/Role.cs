using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [DisplayName("نقش")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public string RoleName { get; set; }
        public virtual List<UserRole> UsersRoles { get; set; }
    }
}
