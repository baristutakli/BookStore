﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public partial class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext context,IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbcontext.Books.OrderBy(b => b.Id).ToList<Book>();

            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);


            //foreach (var book in bookList)
            //{
            //    vm.Add(new BooksViewModel { Title = book.Title,Gendre=((GendreEnum)book.GendreId).ToString(), PageCount = book.PageCount, PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy") });
            //}
            return vm;
        }
    }
}
