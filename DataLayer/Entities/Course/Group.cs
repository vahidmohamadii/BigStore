
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Course
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        [Required]
        [DisplayName("نام ")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public string Title { get; set; }
        public int? ParentId { get; set; }
        [InverseProperty("group")]
        public virtual List<Course> GroupCourses { get; set; }
        [InverseProperty("Subgroup")]
        public virtual List<Course> SubGroupCourses { get; set; }
    }
}
