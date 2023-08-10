
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Wallet
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }
        [DisplayName("توضیحات")]
        [MaxLength(500,ErrorMessage = "حداکثر مقدار برای {0} 500 کارکتر می باشد")]
        public string Description { get; set; }
        [Required]
        [DisplayName("مبلغ")]
        [MaxLength(500, ErrorMessage = "حداکثر مقدار برای {0} 500 کارکتر می باشد")]
        public double Amount { get; set; }
        public bool IsPay { get; set; }
        [DisplayName("تاریخ تراکنش")]
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public int WalletTypeId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }
        [ForeignKey("WalletTypeId")]
        public WalletType WalletType { get; set; }
    }
}
