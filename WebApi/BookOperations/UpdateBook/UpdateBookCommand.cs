using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _context;
        public int BookId;
        public UpdateBookModel Model { get; set; }
        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.Where(b => b.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Güncellenecek kitap bulunamadı");

         
            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.GendreId = Model.GendreId != default ? Model.GendreId : book.GendreId;
      
            _context.SaveChanges();
            
        }



    }
}
