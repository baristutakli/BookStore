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
using AutoMapper;
using FluentValidation.Results;
using FluentValidation;

namespace WebApi.AddControllers{

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController:Controller{
 
        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;

        public BooksController(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get(){
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
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
                GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
               
                query.BookId = id;
                validator.ValidateAndThrow(query);
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
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try
            {
                command.Model = bookModel;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();

                validator.ValidateAndThrow(command);
                //if (!result.IsValid)
                //{
                //    foreach (var item in result.Errors)
                //    {
                //        Console.WriteLine("Özellik:"+item.PropertyName+" Erros:"+item.ErrorMessage);
                //    }
                //}


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
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();

                command.BookId = id;
                command.Model = updatedBook;
                validator.ValidateAndThrow(command);
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
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
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