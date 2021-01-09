using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvictusFC.Domain.Models
{
    public class BranchOfficeRequest : BranchOfficeModel
    {
    }
    public class BranchOfficeResponse : BranchOfficeModel
    {
        public int BranchOfficeId { get; set; }
        public ICollection<ClientResponse> User { get; set; }
    }
    public abstract class BranchOfficeModel
    {      
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
