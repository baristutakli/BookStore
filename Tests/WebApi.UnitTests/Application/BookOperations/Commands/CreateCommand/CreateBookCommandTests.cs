using System;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Commands.CreateCommand{
    public class CreateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public void WhenAlreadExistBooktitleIsGiven_InvalidOperationException_ShouldBeReturn(){
            
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            var book= new Book { Title = "WhenAlreadExistBooktitleIsGiven_InvalidOperationException_ShouldBeReturn", GendreId = 1, PageCount = 200, PublishDate = new DateTime(2000, 10, 10) };
            _context.Books.Add(book);
            _context.SaveChanges();
            command.Model = new CreateBookModel{Title=book.Title};
           
            FluentActions.Invoking(()=>command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");
        

            command.Handle();
        }
    }
}