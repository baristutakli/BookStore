using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookDetail;
using static WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.DeleteBook;

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

            BookDetailViewModel result;
            
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
            return Ok(result);
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
        public IActionResult Update(int id,[FromBody] UpdateBookModel updatedBook){
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
       
    }
}