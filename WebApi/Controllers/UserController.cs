using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.UserOperations.Commands.CreateToken;
using WebApi.Application.UserOperations.Commands.CreateUser;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;

        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(IBookStoreDbContext context, IMapper mapper,IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult AddUser([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = newUser;
            command.Handle();

            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context,_mapper,_configuration);
            command.Model = login;
            var token =command.Handle();
            return token;
        }
    }
}
