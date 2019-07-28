using BookShop.Domain.Entities;
using FluentValidation;
using System;

namespace BookShop.Service.Validator
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Is necessary to inform the author's name")
                .NotNull().WithMessage("Is necessary to inform the author's name")
                .MaximumLength(80).WithMessage("Author's name must be a maximum of 100 characters");
        }
    }
}
