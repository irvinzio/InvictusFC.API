using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvictusFC.Data.Entities
{
    public class LessonUserRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LessonRegistrationId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool HasAttendLesson { get; set; }
    }
}
