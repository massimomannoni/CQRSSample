using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Domain.Users
{
    public interface IUserRepository
    {
        Task Create(User user);

        Task Change(Guid id, string name);

        Task Delete(Guid id);
    }
}
