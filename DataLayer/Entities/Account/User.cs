

using DataLayer.Entities.Course;
using DataLayer.Entities.Wallet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [DisplayName("نام کاربری")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("ایمیل")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نمی باشد")]
        public string Email { get; set; }

        [Required]
        [DisplayName("رمز عبور")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public string Password { get; set; }

        [DisplayName("کد فعالسازی")]
        [MaxLength(200, ErrorMessage = "حداکثر مقدار برای {0} 200 کارکتر می باشد")]
        public string ActiveCode { get; set; }

        public bool IsActive { get; set; }

        [DisplayName("تصویر فرد")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public string UserAvatar { get; set; }

        public DateTime RegisterDate { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<DataLayer.Entities.Wallet.Wallet> wallets { get; set; }
        public virtual List<DataLayer.Entities.Course.Course> Courses { get; set; }
    }
}
