

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Wallet
{
    public class WalletType
    {
        [Key]
        public int WalletTypeId { get; set; }
        [Required]
        [DisplayName("نوع تراکنش")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public string WalletTypeName { get; set; }
        public virtual List<Wallet>  wallets { get; set; }
    }
}
