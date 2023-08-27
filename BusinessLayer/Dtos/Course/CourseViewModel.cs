
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Dtos.Course
{
    public class AddCourseViewModel
    {
        public int CourseGroupId { get; set; }
        public int? CourseSubGroupId { get; set; }
        public int TeacherId { get; set; }
        public int CourseStatusId { get; set; }
        public int CourseLevelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> Tags { get; set; }
        public string ImageName { get; set; }
        public IFormFile ImageFile { get; set; }
        public string DemoFileName { get; set; }
        public IFormFile DemoFile { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
