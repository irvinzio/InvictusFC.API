using AutoMapper;
using InvictusFC.Data.Entities;
using InvictusFC.Data.Repositories;
using InvictusFC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvictusFC.Service
{
    public interface IUserService
    {
        List<ClientResponse> GetAllUsers(int branchOffice);
        List<ClientResponse> GetAllClients(int branchOffice);
        List<ClientResponse> GetAllCoaches(int branchOffice);
        ClientResponse GetUserById(Guid id);
        ClientResponse SaveUser(ClientRequest user);
        ClientResponse UpdateUser(ClientRequest user, Guid id);
        void DeleteUser(Guid userId);
    }
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepository = userRepo;
            _mapper = mapper;
        }
        public List<ClientResponse> GetAllUsers(int branchOffice)
        {
            return _mapper.Map<List<ClientResponse>>(_userRepository.GetAllUsers(branchOffice).ToList());
        }
        public List<ClientResponse> GetAllCoaches(int branchOffice)
        {
            return _mapper.Map<List<ClientResponse>>(_userRepository.GetAllCoaches(branchOffice).ToList());
        }
        public List<ClientResponse> GetAllClients(int branchOffice)
        {
            return _mapper.Map<List<ClientResponse>>(_userRepository.GetAllClients(branchOffice).ToList());
        }
        public ClientResponse GetUserById(Guid id)
        {
            return _mapper.Map<ClientResponse>(_userRepository.GetUserById(id));
        }

        public ClientResponse SaveUser(ClientRequest user)
        {
            var userEntity = _mapper.Map<User>(user);
            return _mapper.Map<ClientResponse>(_userRepository.Add(userEntity));
        }

        public ClientResponse UpdateUser(ClientRequest user, Guid Id)
        {
            var userEntity = _mapper.Map<User>(user);
            return _mapper.Map<ClientResponse>(_userRepository.Update(userEntity));
        }

        public void DeleteUser(Guid id)
        {
            _userRepository.Delete(id);
        }
    }
}
