using BookShop.Domain.Entities;
using FluentValidation;
using System;

namespace BookShop.Service.Validator
{
    public class GenreValidator : AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Is necessary to inform the genre description")
                .NotNull().WithMessage("Is necessary to inform the genre description")
                .MaximumLength(80).WithMessage("Genre's description must be a maximum of 100 characters");
        }
    }
}
