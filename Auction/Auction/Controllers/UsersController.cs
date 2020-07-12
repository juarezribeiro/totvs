using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Auction.Data;
using Auction.Models;
using Auction.Services;
using Microsoft.AspNetCore.Authorization;

namespace Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: api/Users
        [HttpGet]
        [Authorize()]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _usersService.GetUsers();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] UserData user)
        {
            try
            {
                var userResult = _usersService.Authenticate(user.UserName, user.Password);

                if (userResult == null)
                    return BadRequest(new { message = "Invalid user or password" });

                return Ok(userResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
