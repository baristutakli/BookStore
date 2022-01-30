using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Queries.GetBookDetail
{
    public partial class GetBookDetailQuery
    {

        private readonly IBookStoreDbContext _dbcontext;
        public int BookId { get; set; }
        private readonly IMapper _mapper;
        public GetBookDetailQuery(IBookStoreDbContext context,IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbcontext.Books.Include(x=>x.Gendre).Where(book => book.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Bulunamadı");
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);

            //vm.Title = book.Title;
            //vm.Gendre = ((GendreEnum)book.GendreId).ToString();
            //vm.PageCount = book.PageCount;
            //vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            return vm;
        }
    }
}
