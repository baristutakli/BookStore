using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.FirstName).MinimumLength(2);
            RuleFor(command => command.Model.BirthDate.Year).GreaterThan(1920);
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}
