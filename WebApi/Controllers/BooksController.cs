using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebApi.AddControllers{

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController:Controller{
        private static List<Book> BookList =new List<Book>(){
            new Book{Id=1,Title="Learn Startup",GendreId=1,PageCount=200,PublishDate=new DateTime(2000,10,10)},
            new Book{Id=2,Title="Herland",GendreId=2,PageCount=250,PublishDate=new DateTime(2010,5,20)},
            new Book{Id=3,Title="Dune",GendreId=2,PageCount=2540,PublishDate=new DateTime(2020,5,20)},
        };

        [HttpGet]
        public IActionResult Get(){
            var bookList =BookList.OrderBy(b=>b.Id);
            if(bookList is null)
                return BadRequest();
            return Ok(bookList);
        }
         [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var book =BookList.Where(b=>b.Id==id).SingleOrDefault();
            return Ok(book);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody]Book newBook){
            BookList.Add(newBook);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] Book updatedBook){
            var book=BookList.Where(b=>b.Id==id).SingleOrDefault();
            if(book is null)
                return BadRequest();
            book.Id=updatedBook.Id!=default?updatedBook.Id:book.Id;
            book.Title=updatedBook.Title!=default?updatedBook.Title:book.Title;
            book.GendreId=updatedBook.GendreId!=default?updatedBook.GendreId:book.GendreId;
            book.PageCount=updatedBook.PageCount!=default?updatedBook.PageCount:book.PageCount;
            book.PublishDate=updatedBook.PublishDate!=default?updatedBook.PublishDate:book.PublishDate;
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var result = BookList.SingleOrDefault(b=>b.Id==id);
            if(result is null)
                return NotFound();

            BookList.Remove(result);
            return Ok($"Deleted id:{id}");
        }
       
    }
}