using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Application.Users.CreateUser
{
    public class CreateUserCommand : CommandBase<UserDto>
    {
        public string Name { get; }

        public CreateUserCommand(string name)
        {
            Name = name;
        }
    }
}
