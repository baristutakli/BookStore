using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.Commands.CreateBook;
using static WebApi.Application.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using static WebApi.Application.BookOperations.Queries.GetBooks.GetBooksQuery;
using WebApi.Entities;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using static WebApi.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.UserOperations.Commands.CreateUser;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            /// Createbook objesi book objesine maplenebilir
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Gendre, opt => opt.MapFrom(src => src.Gendre.Name) );
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Gendre, opt => opt.MapFrom(src => src.Gendre.Name));

            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();

            CreateMap<Author, AuthorsViewModel>().ForMember(dest=>dest.BirthDate,opt =>opt.MapFrom(src=>src.BirthDate.Date.ToShortDateString()));
            CreateMap<Author, AuthorDetailViewModel>().ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date.ToShortDateString()));
            CreateMap<Author,CreateAuthorModel>();

            CreateMap<CreateUserModel, User>();
        }
    }
}
