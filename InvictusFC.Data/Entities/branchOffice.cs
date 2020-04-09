using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvictusFC.Data.Entities
{
    public class BranchOffice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchOfficeId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public ICollection<User> User { get; set; }
    }
}
