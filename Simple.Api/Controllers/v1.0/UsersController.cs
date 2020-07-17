using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simple.Api.Services;
using Simple.Application.Users;
using Simple.Application.Users.CreateUser;
using Simple.Application.Users.GetUsers;
using Simple.Domain.Users;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Simple.Api.Controllers
{
    [Route(ApiBase.Users)]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get users 
        /// </summary>
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(List<User>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _mediator.Send(new GetUsersQuery());

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="request"></param>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterCustomer([FromBody] CreateUserRequest request)
        {

            try
            {
                UserDto user = await _mediator.Send(new CreateUserCommand(request.first_name, request.last_name, request.email));

                return Created(string.Empty, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }
    }
}
