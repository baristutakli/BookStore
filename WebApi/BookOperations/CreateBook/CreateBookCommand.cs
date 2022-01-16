using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model{ get; set; }
        private readonly BookStoreDbContext _dbcontext;
        public CreateBookCommand(BookStoreDbContext context)
        {
            _dbcontext = context;
        }

        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(b => b.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Kitap zaten mevcut");

            book = new Book();
            book.Title = Model.Title;
            book.PageCount = Model.PageCount;
            book.PublishDate = Model.PublishDate;
            book.GendreId = Model.GendreId;

            _dbcontext.Books.Add(book);
            _dbcontext.SaveChanges();
        }
    }
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GendreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
