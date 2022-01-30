using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;
namespace WebApi.Application.BookOperations.Queries.GetBooks
{
    public partial class GetBooksQuery
    {
        private readonly IBookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetBooksQuery(IBookStoreDbContext context,IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbcontext.Books.Include(x => x.Gendre).OrderBy(b => b.Id).ToList<Book>();

            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);


            //foreach (var book in bookList)
            //{
            //    vm.Add(new BooksViewModel { Title = book.Title,Gendre=((GendreEnum)book.GendreId).ToString(), PageCount = book.PageCount, PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy") });
            //}
            return vm;
        }
    }
}
