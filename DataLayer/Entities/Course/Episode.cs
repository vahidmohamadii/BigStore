

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Course
{
    public class Episode
    {
        [Key]
        public int EpisodeId { get; set; }
        [Required]
        [DisplayName("نام ")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public string Title { get; set; }
        [Required]
        [DisplayName("زمان اپیزود")]
        [MaxLength(100, ErrorMessage = "حداکثر مقدار برای {0} 100 کارکتر می باشد")]
        public DateTime EpiodeTime { get; set; }
        [Required]
        public string EpisodeFileName { get; set; }
        [DisplayName("آیا رایکان است؟")]
        public bool IsFree { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}
