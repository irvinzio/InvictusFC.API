using InvictusFC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvictusFC.Data.Entities
{
    public class Lesson
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public Guid LessonId { get; set; }
       public LessonRoom Lessonroom { get; set; }
       public int OcupationLimit { get; set; } 
       public IEnumerable<LessonTime> LessonTime { get; set; }
       public IEnumerable<LessonUserRegistration> UsersRegistered { get; set; }
    }
}
