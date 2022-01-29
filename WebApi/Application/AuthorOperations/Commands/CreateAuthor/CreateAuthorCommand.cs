using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(BookStoreDbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _dbcontext = context;
        }
        public CreateAuthorModel Model { get; set; }
        public void Handle()
        {
            var author=_dbcontext.Authors.SingleOrDefault(author => author.FirstName == Model.FirstName && author.LastName == Model.LastName);
            if (author is not null)
            {
                throw new InvalidOperationException("Already exists");
            }
            author = _mapper.Map<Author>(Model);
            _dbcontext.Authors.Add(author);
            _dbcontext.SaveChanges();
        }
    }
}
