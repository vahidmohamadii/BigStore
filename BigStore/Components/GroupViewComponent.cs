using BusinessLayer.Services.InterFace;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigStore.Components
{
    public class GroupViewComponent:ViewComponent
    {
        private readonly IAdminGroup _adminGroup;
        public GroupViewComponent(IAdminGroup adminGroup)
        {
            _adminGroup = adminGroup;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var res= await Task.FromResult<IViewComponentResult>(View("/ViewComponents/_groupsView.cshtml", _adminGroup.GetAllGroups()));
            return res;
        }
    }
}
