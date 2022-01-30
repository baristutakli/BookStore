using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IBookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateUserCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _dbcontext.Users.SingleOrDefault(u => u.Email == Model.Email);
            if (user is not null)
                throw new InvalidOperationException("Kullanıcı zaten mevcut");


            user = _mapper.Map<User>(Model);

            _dbcontext.Users.Add(user);
            _dbcontext.SaveChanges();
        }
    }
}
