using Data;
using DomainModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class UserService : IUserService
    {

        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _userRepository.GetAll().Select(x => new UserModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Username = x.Username,
                Role = 2,
                Balance = 1000

            });
        }

        public void Register(UserModel model)
        {
            if (string.IsNullOrEmpty(model.Username))
                throw new Exception("Username is required.");

            if (string.IsNullOrEmpty(model.FirstName))
                throw new Exception("FirstName is required.");

            if (string.IsNullOrEmpty(model.LastName))
                throw new Exception("LastName is required.");


            if (_userRepository
                .GetAll()
                .Any(x => x.Username == model.Username))
                throw new Exception("The username is already in use.");


            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Role = model.Role,
                Ballance = model.Balance
            };

            _userRepository.Add(user);
        }
    }
}
