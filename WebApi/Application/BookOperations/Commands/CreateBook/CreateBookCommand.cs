using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;
namespace WebApi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model{ get; set; }
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(b => b.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Kitap zaten mevcut");

            
            book = _mapper.Map<Book>(Model);
            //book.Title = Model.Title;
            //book.PageCount = Model.PageCount;
            //book.PublishDate = Model.PublishDate;
            //book.GendreId = Model.GendreId;

            _dbcontext.Books.Add(book);
            _dbcontext.SaveChanges();
        }
    }
}
