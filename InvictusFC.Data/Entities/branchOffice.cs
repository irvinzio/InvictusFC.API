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
        public Guid BranchOfficeId { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
    }
}
