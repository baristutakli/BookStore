using System;

namespace WebApi.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}