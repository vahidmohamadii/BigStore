
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Dtos.Account
{
    public class RegisterViewModel
    {
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
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "تکرار رمز عبور اشتباه است")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
    public class LoginViewModel
    {
        [Required]
        [DisplayName("نام کاربری")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public string UserName { get; set; }

        public string Email { get; set; }
        [Required]
        [DisplayName("رمز عبور")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersistant { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [DisplayName("نام کاربری")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public string UserName { get; set; }


        [Required]
        [DisplayName("رمز عبور جدید")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("تکرار رمز عبور جدید")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        [DataType(DataType.Password)]
        public string ReNewPassword { get; set; }
    }

    public class ChangePassViewModel
    {

        [Required]
        [DisplayName("نام کاربری")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("رمز عبور قبلی")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required]
        [DisplayName("رمز عبور جدید")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("تکرار رمز عبور جدید")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        [DataType(DataType.Password)]
        public string ReNewPassword { get; set; }
    }
    public class ShowUserPanelData
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RegisterDate { get; set; }
        public Double Wallet { get; set; }
        public string ImageName { get; set; }
        public IFormFile ProfilePic { get; set; }
    }
    public class EditUserPanelData
    {
        public string Email { get; set; }
        public IFormFile  ProfilePic { get; set; }
        public string  ImageName { get; set; }
    }

}
