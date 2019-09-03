using Business;
using Data;
using DomainModels;
using LottoApp_Tests.FakeRepositories;
using Microsoft.Extensions.Options;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LottoApp_Tests
{
    public class UserServiceTest
    {
      
        private readonly IUserService _userService;

        public UserServiceTest()
        {
            var settings = new JwtSettings { Secret = "My secret code" };
            var jwtSettings = Options.Create(settings);
            IRepository<User> userRepository = new FakeUserRepository();

            _userService = new UserService( userRepository, jwtSettings);
        }


        [Fact]
        public void Test()
        {
            //ToDoo tests 
        }
    }
}
