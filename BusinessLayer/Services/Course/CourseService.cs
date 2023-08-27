

using BusinessLayer.Dtos.Course;
using BusinessLayer.Services.InterFace;
using BusinessLayer.Utility;
using DataLayer.Context;
using DataLayer.Entities.Course;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLayer.Services.Course
{
    public class CourseService : IAdminCourse
    {
        private readonly BigStoreContext _context;
        public CourseService(BigStoreContext context)
        {
            _context = context;
        }

        public void AddCourse(AddCourseViewModel addCourseViewModel)
        {
            DataLayer.Entities.Course.Course course = new DataLayer.Entities.Course.Course();
            course.CourseGroupId = addCourseViewModel.CourseGroupId;
            course.CourseSubGroupId = addCourseViewModel.CourseSubGroupId;
            course.CourseLevelId = addCourseViewModel.CourseLevelId;
            course.CourseStatusId= addCourseViewModel.CourseStatusId;
            course.CreateDate = DateTime.Now;
            course.UpdateDate = DateTime.Now;
            //course.DemoFileName = addCourseViewModel.DemoFileName;
            course.Description = addCourseViewModel.Description;
            //course.ImageName=addCourseViewModel.ImageName;
            course.Title= addCourseViewModel.Title;
            course.Price= addCourseViewModel.Price;
            course.TeacherId = addCourseViewModel.TeacherId;
            course.Tags = addCourseViewModel.Tags;

            //Image
            if(addCourseViewModel.ImageFile != null)
            {
                addCourseViewModel.ImageName = GenerateActiveCode.GenerateActiveCodes() + Path.GetExtension(addCourseViewModel.ImageFile.FileName);
                var ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CourseImages", addCourseViewModel.ImageName);
                using(var file=new FileStream(ImagePath,FileMode.Create))
                {
                    addCourseViewModel.ImageFile.CopyTo(file);
                }
            }

            //Demo
            if (addCourseViewModel.DemoFile != null)
            {
                addCourseViewModel.DemoFileName = GenerateActiveCode.GenerateActiveCodes() + Path.GetExtension(addCourseViewModel.DemoFile.FileName);
                var DemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CourseImages", addCourseViewModel.DemoFileName);
                using (var file = new FileStream(DemoPath, FileMode.Create))
                {
                    addCourseViewModel.ImageFile.CopyTo(file);
                }
            }





            _context.Add(course);
            _context.SaveChanges();

        }

        public List<SelectListItem> GetGroup()
        {
            return _context.groups.Where(x=>x.ParentId==null).Select(g=>new SelectListItem() {
            Text=g.Title,
            Value=g.GroupId.ToString()
            
            }).ToList();
        }

        public List<SelectListItem> GetLevel()
        {
            return _context.courseLevels.Select(g => new SelectListItem()
            {
                Text = g.Title,
                Value = g.CourselevelId.ToString()

            }).ToList();
        }

        public List<SelectListItem> GetStatus()
        {
            return _context.courseStatuses.Select(g => new SelectListItem()
            {
                Text = g.Title,
                Value = g.CourseStatusId.ToString()

            }).ToList();
        }

        public List<SelectListItem> GetSubGroup(int groupId)
        {
            return _context.groups.Where(x=>x.ParentId==groupId).Select(g => new SelectListItem()
            {
                Text = g.Title,
                Value = g.GroupId.ToString()

            }).ToList();
        }

        public List<SelectListItem> GetTeacher()
        {
            return _context.userRoles.Include(x => x.User).Where(x => x.RoleId == 2).Select(x => new SelectListItem()

            {
                Text = x.User.UserName,
                Value = x.User.UserId.ToString()
            }
            ).ToList();
        }
    }
}
