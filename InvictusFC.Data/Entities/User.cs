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
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string SurName { get; set; }
        [Required]
        [StringLength(20)]
        public string Cellphone { get; set; }
        [Required]
        [StringLength(500)]
        [EmailAddressAttribute]
        public string Email { get; set; }
        [Required]
        public int UserType { get; set; }
        [Required]
        public int BranchOfficeId { get; set; }
        public Address Address { get; set; }
        public Identification Identification { get; set; }
    }
}
