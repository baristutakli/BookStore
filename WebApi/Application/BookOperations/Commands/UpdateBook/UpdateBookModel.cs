using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GendreId { get; set; }
    }
}
