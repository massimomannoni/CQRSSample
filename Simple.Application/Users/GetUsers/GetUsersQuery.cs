using MediatR;
using System.Collections.Generic;

namespace Simple.Application.Users.GetUsers
{
    public class GetUsersQuery : IRequest<List<UserDetailsDto>>
    {
        public GetUsersQuery() { }
    }
}
