using BookShop.Domain.Entities;
using FluentValidation;
using System;

namespace BookShop.Service.Validator
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Is necessary to inform the book's title")
                .NotNull().WithMessage("Is necessary to inform the book's title")
                .MaximumLength(80).WithMessage("Book's title must be a maximum of 80 characters");

            RuleFor(c => c.Stock)
                .NotNull().WithMessage("Is required to inform the book's stock quantity");

            RuleFor(c => c.Isbn10)
                .MaximumLength(10).WithMessage("ISBN10 must be a maxium of 10 characters");

            RuleFor(c => c.Isbn13)
                .MaximumLength(13).WithMessage("ISBN13 must be a maxium of 13 characters");
        }
    }
}
