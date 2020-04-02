using InvictusFC.Data.Entities;
using InvictusFC.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvictusFC.BL
{
    public interface IUserManager
    {
        List<User> GetAllUsers();
        User GetUserById(Guid id);
        List<User> GetAllEmployees();
        User SaveUser(User user);
        User UpdateUser();
    }
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepository;
        public UserManager(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll().ToList();
        }

        public User GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public User SaveUser(User user)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
