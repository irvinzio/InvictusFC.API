using System;
using System.ComponentModel.DataAnnotations;

namespace InvictusFC.Domain.Models
{
    public class IdentificationRequest : IdentificationModel
    {
    }
    public class IdentificationResponse : IdentificationModel
    {
        public Guid IdentificationId { get; set; }
        public ClientResponse User { get; set; }
    }
    public abstract class IdentificationModel
    {
        [Required]
        public int IdentificationType { get; set; }
        [Required]
        [StringLength(100)]
        public string Number { get; set; }
        public Guid UserId { get; set; }
    }
}
