using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail
{
    public partial class GetBookDetailQuery
    {

        private readonly BookStoreDbContext _dbcontext;
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext context)
        {
            _dbcontext = context;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbcontext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Bulunamadı");
            BookDetailViewModel vm = new BookDetailViewModel() {  };
            vm.Title = book.Title;
            vm.Gendre = ((GendreEnum)book.GendreId).ToString();
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            return vm;
        }
    }
}
