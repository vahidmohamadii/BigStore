

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Course
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public int CourseGroupId { get; set; }
        public int? CourseSubGroupId { get; set; }
        public int TeacherId { get; set; }
        public int CourseStatusId { get; set; }
        public int CourseLevelId { get; set; }
        [Required]
        [DisplayName("نام ")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public string Title { get; set; }
        [Required]
        [DisplayName("توضیحات")]
        [MaxLength(500, ErrorMessage = "حداکثر مقدار برای {0} 500 کارکتر می باشد")]
        public string Description{ get; set; }
        [Required]
        [DisplayName("قیمت")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public decimal Price{ get; set; }
        [NotMapped]
        public List<string> Tags { get; set; }
        public string ImageName { get; set; }
        public string DemoFileName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [ForeignKey("CourseGroupId")]
        public Group group { get; set; }
        [ForeignKey("CourseSubGroupId")]
        public Group Subgroup { get; set; }
        [ForeignKey("TeacherId")]
        public User user { get; set; }
        [ForeignKey("CourseStatusId")]
        public CourseStatus courseStatus { get; set; }
        [ForeignKey("CourseLevelId")]
        public CourseLevel courseLevel { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
