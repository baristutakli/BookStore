using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _dbcontext;
      
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _dbcontext = context;
          
        }
        public void Handle()
        {
            var author = _dbcontext.Authors.SingleOrDefault(aut => aut.Id == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Author does not exist in the curent context");
            }
            _dbcontext.Authors.Remove(author);
            _dbcontext.SaveChanges();
        }
    }
}
