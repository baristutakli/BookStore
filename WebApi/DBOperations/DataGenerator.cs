
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations{
public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {
            // Look for any book.
            if (context.Books.Any())
            {
                return;   // Data was already seeded
            }

            context.Books.AddRange(
                new Book{Title="Learn Startup",GendreId=1,PageCount=200,PublishDate=new DateTime(2000,10,10)},
            new Book{Title="Herland",GendreId=2,PageCount=250,PublishDate=new DateTime(2010,5,20)},
            new Book{Title="Dune",GendreId=2,PageCount=2540,PublishDate=new DateTime(2020,5,20)});

            context.SaveChanges();
        }
    }
}
}