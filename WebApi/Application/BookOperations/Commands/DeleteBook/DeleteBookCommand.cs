using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var result = _context.Books.SingleOrDefault(b => b.Id == BookId);
            if (result is null)
                throw new InvalidOperationException("Silinicek kitap bulunamadı");

            _context.Books.Remove(result);
            
            _context.SaveChanges();
           
        }
    }
}
