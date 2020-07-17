using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Application.Users.CreateUser
{
    public class CreateUserCommand : CommandBase<UserDto>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public CreateUserCommand(string first_name, string last_name, string email)
        {
            FirstName = first_name;
            LastName = last_name;
            Email = email;
        }
    }
}
