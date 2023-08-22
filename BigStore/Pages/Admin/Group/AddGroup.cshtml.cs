using BusinessLayer.Dtos.Group;
using BusinessLayer.Services.InterFace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BigStore.Pages.Admin.Group
{
    public class AddGroupModel : PageModel
    {
        [BindProperty]
        public AddGroupViewModel addGroupViewModel { get; set; }
        private readonly IAdminGroup _adminGroup;
        public AddGroupModel(IAdminGroup adminGroup)
        {
            _adminGroup= adminGroup;
        }
        public void OnGet()
        {
            ViewData["GetAllGroup"] = new SelectList(_adminGroup.GroupList(), "Value", "Text"); 
        }
        public void OnPost()
        {
            _adminGroup.AddGroup(addGroupViewModel);
        }
    }
}
