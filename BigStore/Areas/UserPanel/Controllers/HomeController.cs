using BusinessLayer.Dtos.Account;
using BusinessLayer.Services.InterFace;
using Microsoft.AspNetCore.Mvc;

namespace BigStore.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        private readonly IAccount _account;

        public HomeController(IAccount account)
        {
            _account = account;
        }

        [Route("Home/index")]
        public IActionResult Index()
        {
            var res = _account.GetUserInfoForUserPanel(User.Identity.Name);
            return View(res);
        }
        [Route("Home/EditUserPanel")]
        [HttpGet]
        public IActionResult EditUserPanel()
        {
            var res = _account.GetUserInfoForUserPanel(User.Identity.Name);
            return View(res);
        }
        [Route("Home/EditUserPanel")]
        [HttpPost]
        public IActionResult EditUserPanel(EditUserPanelData editUserPanel)
        {
           _account.EditUserInfoForUserPanel(User.Identity.Name, editUserPanel);
            return View();
        }
    }
}
