using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Application.Users
{
    public class UserDetailsDto
    {
        public Guid Id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }
    }
}
