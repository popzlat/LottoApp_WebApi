using Business;
using Business.Exceptions;
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
        public void Authenticate_UsernameExists_ExceptionThrow()
        {
            //Arrange

            var newUser = new UserModel
            {
                FirstName = "Test", LastName = "Test", Password = "Test", Username = "Test"
            };

            //Act
            Action action = () => _userService.Register(newUser);

            //Assert
            var exception = Assert.Throws<LotoExceptions>(action);
            Assert.Equal("The username is already in use.", exception.Message);


        }

        [Fact]
        public void Authenticate_WeakPassword_ExceptionThrow()
        {
            //Arrange
            var newUser = new UserModel
            {
                FirstName = "New",
                LastName = "User",
                Username = "new_user",
                Password = "Test",
                ConfirmPassword = "Test"
                
            };

            //Act
            Action action = () => _userService.Register(newUser);

            //Assert
            var exception = Assert.Throws<LotoExceptions>(action);
            Assert.Equal(exception.Message, "Please enter strong password.");
        }
    }
}
