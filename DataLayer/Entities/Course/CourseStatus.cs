

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Course
{
    public class CourseStatus
    {
        [Key]
        public int CourseStatusId { get; set; }
        [Required]
        [DisplayName("نام ")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public string Title { get; set; }
        public virtual List<Course> Courses { get; set; }

    }
}
