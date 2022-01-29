using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            AuthorDetailViewModel result;


            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();

            query.AuthorId = id;
            validator.ValidateAndThrow(query);
            result = query.Handle();


            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateAuthorModel bookModel)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);

            command.Model = bookModel;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();

            validator.ValidateAndThrow(command);

            command.Handle();



            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateAuthorModel updatedAuthor)
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();

            command.AuthorId = id;
            command.Model = updatedAuthor;
            validator.ValidateAndThrow(command);
            command.Handle();



            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {


            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId= id;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

    }
}
