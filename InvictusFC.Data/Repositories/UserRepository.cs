using InvictusFC.Data.Context;
using InvictusFC.Data.Entities;
using InvictusFC.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvictusFC.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAllUsers(int branchOffice);
        IEnumerable<User> GetAllCoaches(int branchOffice);
        IEnumerable<User> GetAllClients(int branchOffice);
        User GetUserById(Guid id);
    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        private InvictusContext _context;
        public UserRepository(InvictusContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllClients(int branchOffice)
        {
            return _context.Users.AsQueryable()
                .Where(u => u.UserType == (int) UserTypeEnum.Client)
                .Where(u => u.BranchOfficeId == branchOffice)
                .Include(u => u.Address)
                .Include(u => u.Identification);
        }

        public IEnumerable<User> GetAllUsers(int branchOffice)
        {
            return  _context.Users
                .Where(u => u.BranchOfficeId == branchOffice)
                .Include(u => u.Address)
                .Include(u => u.Identification);
        }

        public IEnumerable<User> GetAllCoaches(int branchOffice)
        {
            return _context.Users.AsQueryable()
                .Where(u => u.UserType == (int)UserTypeEnum.Client)
                .Where(u => u.BranchOfficeId == branchOffice)
                .Include(u => u.Address)
                .Include(u => u.Identification);
        }
        public User GetUserById(Guid id)
        {
            return _context.Users.AsQueryable()
                .Where(u => u.UserId == id)
                .Include(u => u.Address)
                .Include(u => u.Identification)
                .FirstOrDefault();
        }
    }
}
