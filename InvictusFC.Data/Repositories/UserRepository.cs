using InvictusFC.Data.Context;
using InvictusFC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvictusFC.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(InvictusContext context) : base(context)
        {

        }
    }
}
