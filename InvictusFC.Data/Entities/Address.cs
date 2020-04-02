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
        public string StreetName { get; set; }
        public string InteriorNumber { get; set; }
        public string ExteriorNumber { get; set; }
        public string County { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
