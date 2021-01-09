using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvictusFC.Domain.Models
{
    public class ClientRequest : ClientModelBase 
    {
        [Required]
        public int BranchOfficeId { get; set; }
    }
    public class ClientResponse : ClientModelBase 
    {
        [Required]
        public Guid UserId { get; set; }
        public BranchOfficeResponse BranchOffice { get; set; }
        public AddressResponse Address { get; set; }
        public IdentificationResponse Identification { get; set; }
    }
    public abstract class ClientModelBase
    {
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
    }
}
