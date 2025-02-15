﻿using BookMaster.Communication.Requests;
using FluentValidation;

namespace BookMaster.Application.UseCases.Books;
public class BookValidator : AbstractValidator<RequestBookJson>
{
    public BookValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("O título é obrigatório.");

        RuleFor(x => x.Author)
            .NotEmpty()
            .WithMessage("O autor é obrigatório.");

        RuleFor(x => x.Publisher)
            .NotEmpty()
            .WithMessage("A editora é obrigatório.");

        RuleFor(x => x.Year)
            .InclusiveBetween(0, DateTime.Now.Year)
            .WithMessage("O ano não pode ser maior que o ano corrente.");
    }
}
