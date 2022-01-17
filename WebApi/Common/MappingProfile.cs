using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BookOperations.CreateBook;
using static WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;
using static WebApi.BookOperations.GetBooks.GetBooksQuery;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            /// Createbook objesi book objesine maplenebilir
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Gendre, opt => opt.MapFrom(src => ((GendreEnum)src.GendreId).ToString()) );
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Gendre, opt => opt.MapFrom(src => ((GendreEnum)src.GendreId).ToString()));
        }
    }
}
