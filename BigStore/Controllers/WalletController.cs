using BusinessLayer.Dtos.Wallet;
using BusinessLayer.Services.InterFace;
using Microsoft.AspNetCore.Mvc;

namespace BigStore.Controllers
{
    public class WalletController : Controller
    {
        private readonly IAccount _account;

        public WalletController(IAccount account)
        {
            _account = account;
        }

        public IActionResult Index()
        {
            var res = _account.GetUserWalletList(User.Identity.Name);
            return View(res);
        }

        [HttpGet]
        public IActionResult ChargeWallet()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult ChargeWallet(ChargeWalletViewModel charge) 
        {
            if(ModelState.IsValid) 
            {
                charge.UserName = User.Identity.Name;
                var res = _account.ShargeWallet(charge);
                return RedirectToPage("https://localhost:44363/Wallet", res);
            }
            return View();
        }
    }
}
