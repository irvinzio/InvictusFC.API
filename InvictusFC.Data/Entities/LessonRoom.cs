using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvictusFC.Data.Entities
{
    public class LessonRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LessonRoomId { get; set; }
        [Required]
        public string LessonRoomName { get; set; }
        public Guid BranchOfficeId { get; set; }
    }
}
