using System;
using System.Collections.Generic;
using System.Text;
using Simple.Domain.SeedWork;

namespace Simple.Domain.Users
{
    public class UserID : TypedIdValueBase
    {
        public UserID(Guid value) : base(value)
        {

        }
    }
}
