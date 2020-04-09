using InvictusFC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvictusFC.Data.Context
{
    public class InvictusContext : DbContext
    {
        public InvictusContext(DbContextOptions<InvictusContext> options)
        : base(options)
        {}
       

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<Identification> Identifications { get; set; }
    }
}
