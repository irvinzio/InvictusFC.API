using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvictusFC.Data.Entities
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PaymentId { get; set; }
        public DateTime date { get; set; }
        public double Total { get; set; }
        public User UserId { get; set; }
        public IEnumerable<Item> items { get; set; }
    }
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemId { get; set; }
        public string description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
    }
}
