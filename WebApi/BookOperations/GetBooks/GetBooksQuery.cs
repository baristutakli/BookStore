﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        public GetBooksQuery(BookStoreDbContext context)
        {
            _dbcontext = context;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbcontext.Books.OrderBy(b => b.Id).ToList<Book>();
            
            List<BooksViewModel> vm = new List<BooksViewModel>();

            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel { Title = book.Title,Gendre=((GendreEnum)book.GendreId).ToString(), PageCount = book.PageCount, PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy") });
            }
            return vm;
        }
        public BooksViewModel HandleById(int id)
        {
            var book = _dbcontext.Books.SingleOrDefault(b => b.Id == id);
            BooksViewModel vm = new BooksViewModel() { Title = book.Title, Gendre = ((GendreEnum)book.GendreId).ToString(), PageCount = book.PageCount, PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy") };
            return vm;
        }

        public class BooksViewModel {
          
            public string Title { get; set; }
            public string Gendre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }

        }
    }
}
