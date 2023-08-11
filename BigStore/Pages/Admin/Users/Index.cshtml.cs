using BusinessLayer.Dtos.Admin;
using BusinessLayer.Services.InterFace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace BigStore.Pages.Users
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<UserListViewModel> userListViewModel { get; set; }
        private readonly IAdminUser _user;
        public IndexModel(IAdminUser user)
        {
            _user = user;
      
        }
  
     
        public void OnGet()
        {
            userListViewModel = _user.GetAllUser();

        }
    }
}
