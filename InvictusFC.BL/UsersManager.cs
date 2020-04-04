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
        List<User> GetAllClients();
        List<User> GetAllEmployees();
        User GetUserById(Guid id);
        User SaveUser(User user);
        User UpdateUser(User user);
        void DeleteUser(Guid userId);
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
            return _userRepository.Get().ToList();
        }
        public List<User> GetAllEmployees()
        {
            return _userRepository.Get().ToList();
        }
        public List<User> GetAllClients()
        {
            return _userRepository.Get().ToList();
        }
        public User GetUserById(Guid id)
        {
            return _userRepository.Get(id);
        }

        public User SaveUser(User user)
        {
            return _userRepository.Add(user);
        }

        public User UpdateUser(User user)
        {
            return _userRepository.Update(user);
        }

        public void DeleteUser(Guid id)
        {
            _userRepository.Delete(id);
        }
    }
}
