using Auction.Models;
using Auction.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Services
{
    public class UsersService : IUsersService
    {
        IUsersRepository _usersRepository;
        public IConfiguration Configuration { get; }
        public UsersService(IUsersRepository usersRepository, IConfiguration configuration)
        {
            _usersRepository = usersRepository;
            Configuration = configuration;
        }



        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _usersRepository.GetUsers();
        }

        public UserData Authenticate(string username, string password)
        {
            var sha256 = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            sha256 = SHA256.Create().ComputeHash(sha256);

            var hashedPassword = Convert.ToBase64String(sha256);

            var user = _usersRepository.Get(username, hashedPassword).Result;

            var checkUser = user != null ? _usersRepository.GetUser(user.UserID).Result : null;

            if (checkUser != null && !checkUser.Status)
                throw new Exception("Invalid user or password");

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Settings")["Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.ExpiresIn = DateTime.Now.AddHours(1);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = "";

            return user;
        }

        private object Sha256encrypt(string password)
        {
            throw new NotImplementedException();
        }
    }
}

