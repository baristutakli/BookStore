namespace WebApi.BookOperations.GetBookDetail
{
    public partial class GetBookDetailQuery
    {
        public class BookDetailViewModel
        {

            public string Title { get; set; }
            public string Gendre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }

        }
    }
}
