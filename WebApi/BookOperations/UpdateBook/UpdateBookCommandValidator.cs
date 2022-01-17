using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator:AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(commnd => commnd.BookId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.GendreId).GreaterThan(0).NotNull();
            RuleFor(command => command.Model.Title).MinimumLength(3).NotEmpty();
            
        }
    }
}
