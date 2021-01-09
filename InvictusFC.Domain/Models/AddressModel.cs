
using System;
using System.ComponentModel.DataAnnotations;

namespace InvictusFC.Domain.Models
{
    public class AddressRequest : AddressModelBase
    {
        public Guid UserId { get; set; }
    }
    public class AddressResponse : AddressModelBase
    {
        public Guid AddressId { get; set; }
        public ClientResponse User { get; set; }
    }
    public abstract class AddressModelBase
    {
        
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
    }
}
