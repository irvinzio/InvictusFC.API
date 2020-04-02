using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvictusFC.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
        public Guid BranchOfficeId { get; set; }
        public virtual BranchOffice BranchOffice { get; set; }
        public virtual Address Address { get; set; }
        public virtual Identification Identification { get; set; }
    }
}
