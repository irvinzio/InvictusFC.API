using InvictusFC.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvictusFC.Data.Entities
{
    public class LessonTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LessonTimeId { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        public WeekDays WeekDay { get; set; }
    }
}
