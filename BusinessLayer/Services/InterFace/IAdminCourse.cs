using BusinessLayer.Dtos.Course;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BusinessLayer.Services.InterFace
{
    public interface IAdminCourse
    {
        void AddCourse(AddCourseViewModel addCourseViewModel);
        List<SelectListItem> GetGroup();
        List<SelectListItem> GetSubGroup(int groupId);
        List<SelectListItem> GetTeacher();
        List<SelectListItem> GetStatus();
        List<SelectListItem> GetLevel();
    }
}
