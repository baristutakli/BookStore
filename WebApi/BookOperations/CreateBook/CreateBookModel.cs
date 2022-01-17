using System;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GendreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
