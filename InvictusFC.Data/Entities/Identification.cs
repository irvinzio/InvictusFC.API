using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvictusFC.Data.Entities
{
    public class Identification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdentificationId { get; set; }
        [Required]
        public int IdentificationType { get; set; }
        [Required]
        [StringLength(100)]
        public string Number { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
