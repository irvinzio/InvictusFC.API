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
        List<User> GetAllUsers(int branchOffice);
        List<User> GetAllClients(int branchOffice);
        List<User> GetAllCoaches(int branchOffice);
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
        public List<User> GetAllUsers(int branchOffice)
        {
            return _userRepository.GetAllUsers(branchOffice).ToList();
        }
        public List<User> GetAllCoaches(int branchOffice)
        {
            return _userRepository.GetAllCoaches(branchOffice).ToList();
        }
        public List<User> GetAllClients(int branchOffice)
        {
            return _userRepository.GetAllClients(branchOffice).ToList();
        }
        public User GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            return user;
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
