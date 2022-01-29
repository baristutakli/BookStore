namespace WebApi.Application.BookOperations.Queries.GetBooks
{
    public partial class GetBooksQuery
    {
        public class BooksViewModel {
          
            public string Title { get; set; }
            public string Gendre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }

        }
    }
}
