using BusinessLayer.Dtos.Admin;
using BusinessLayer.Services.InterFace;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace BigStore.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IAccount _account;
        public IndexModel(IAccount account)
        {
            _account = account;
      
        }

        public UserListViewModel  userListViewModel { get; set; }
        public void OnGet()
        {
        }
    }
}
