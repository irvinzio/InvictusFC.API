using InvictusFC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvictusFC.Data.Entities
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AddressId { get; set; }
        [Required]
        [StringLength(100)]
        public string StreetName { get; set; }
        [Required]
        [StringLength(10)]
        public string InteriorNumber { get; set; }
        [StringLength(10)]
        public string ExteriorNumber { get; set; }
        [StringLength(50)]
        public string County { get; set; }
        [StringLength(50)]
        public string Town { get; set; }
        [Required]
        [StringLength(50)]
        public string Colony { get; set; }
        [Required]
        [StringLength(50)]
        public int Country { get; set; }
        [Required]
        public int State { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
