using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup{
    public static class Books{

        public static void AddBooks(this BookStoreDbContext context){
            context.Books.AddRange(
        new Book { Title = "Learn Startup", GendreId = 1, PageCount = 200, PublishDate = new DateTime(2000, 10, 10) },
        new Book { Title = "Herland", GendreId = 2, PageCount = 250, PublishDate = new DateTime(2010, 5, 20) },
        new Book { Title = "Dune", GendreId = 2, PageCount = 2540, PublishDate = new DateTime(2020, 5, 20) });
        
    }
    }
}