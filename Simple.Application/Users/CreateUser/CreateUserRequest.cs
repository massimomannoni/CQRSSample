using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Application.Users.CreateUser
{
    public class CreateUserRequest
    {
        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }
    }
}
