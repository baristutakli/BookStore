using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {

        private readonly BookStoreDbContext _dbcontext;
       
        public UpdateAuthorModel Model { get; set; }
        public int AuthorId { get; set; }
        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _dbcontext = context;
        }

        public void Handle()
        {
            var author = _dbcontext.Authors.SingleOrDefault(aut => aut.Id == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Not found");
            }
            author.FirstName = Model.FirstName != default ? Model.FirstName : author.FirstName;
            author.LastName = Model.LastName != default ? Model.LastName : author.LastName;
            author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;
            _dbcontext.SaveChanges();
        }
    }
}
