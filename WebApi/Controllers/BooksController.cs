using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;

namespace WebApi.AddControllers{

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController:Controller{
 
        private readonly BookStoreDbContext _context;

        public BooksController(BookStoreDbContext context)
        {
            _context=context;
        }
        [HttpGet]
        public IActionResult Get(){
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            if(result is null)
                return BadRequest();
            return Ok(result);
        }
         [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var book = new GetBooksQuery(_context).HandleById(id);
            return Ok(book);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody]CreateBookModel bookModel){
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = bookModel;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] Book updatedBook){
            var book=_context.Books.Where(b=>b.Id==id).SingleOrDefault();
            if(book is null)
                return BadRequest();
            book.Id=updatedBook.Id!=default?updatedBook.Id:book.Id;
            book.Title=updatedBook.Title!=default?updatedBook.Title:book.Title;
            book.GendreId=updatedBook.GendreId!=default?updatedBook.GendreId:book.GendreId;
            book.PageCount=updatedBook.PageCount!=default?updatedBook.PageCount:book.PageCount;
            book.PublishDate=updatedBook.PublishDate!=default?updatedBook.PublishDate:book.PublishDate;
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var result = _context.Books.SingleOrDefault(b=>b.Id==id);
            if(result is null)
                return NotFound();

            _context.Books.Remove(result);
            _context.SaveChanges();
            return Ok($"Deleted id:{id}");
        }
       
    }
}