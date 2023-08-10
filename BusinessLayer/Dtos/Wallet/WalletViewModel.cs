
using System;

namespace BusinessLayer.Dtos.Wallet
{
    public class UserWalletListViewModel
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public int WalletTypeId { get; set; }
    }
    public class ChargeWalletViewModel
    {
        public double Amount { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
    }
}
