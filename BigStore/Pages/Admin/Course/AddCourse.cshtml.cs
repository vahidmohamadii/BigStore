using BusinessLayer.Dtos.Course;
using BusinessLayer.Services.InterFace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BigStore.Pages.Admin.Course
{
    public class AddCourseModel : PageModel
    {
        private readonly IAdminCourse _adminCourse;
        public AddCourseModel(IAdminCourse adminCourse)
        {
            _adminCourse = adminCourse;
    
        }

        [BindProperty]
        public AddCourseViewModel addCourseViewModel { get; set; }
        public void OnGet()
        {
            ViewData["Status"]= new SelectList(_adminCourse.GetStatus(), "Value", "Text") ;
            ViewData["Level"]= new SelectList(_adminCourse.GetLevel(), "Value", "Text") ;
            ViewData["Group"]= new SelectList(_adminCourse.GetGroup(), "Value", "Text") ;
            //ViewData["Status"]= new SelectList(_adminCourse.GetSubGroup(), "Value", "Text") ;
            ViewData["Teacher"] = new SelectList(_adminCourse.GetTeacher(), "Value", "Text") ;
 
        }

        public void OnPost()
        {
            _adminCourse.AddCourse(addCourseViewModel);
        }
    }
}
