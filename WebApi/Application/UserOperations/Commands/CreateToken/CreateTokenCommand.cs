using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {

        public CreateTokenModel Model { get; set; }
        private readonly IBookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenCommand(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _dbcontext = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbcontext.Users.SingleOrDefault(u => u.Email == Model.Email&& u.Password==Model.Password);
            if (user is not null)
            {
                //token yarat
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbcontext.SaveChanges();
                return token;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı ve şifre hatalı");
            }



           // user = _mapper.Map<Token>(Model);

            //_dbcontext.Users.Add(user);
           // _dbcontext.SaveChanges();
        }
    }
}
