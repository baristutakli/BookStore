using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommandValidator:AbstractValidator<CreateBookCommand>
    {
        /// <summary>
        /// Validasyon yapıcı metod aracılığı ile çalışıyor
        /// </summary>
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GendreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}
