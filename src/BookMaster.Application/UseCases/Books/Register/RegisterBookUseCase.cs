﻿using AutoMapper;
using BookMaster.Communication.Requests;
using BookMaster.Communication.Responses;
using BookMaster.Domain.Entities;
using BookMaster.Domain.Repositories;
using BookMaster.Domain.Repositories.Books;
using BookMaster.Exception.ExceptionBase;

namespace BookMaster.Application.UseCases.Books.Register;
public class RegisterBookUseCase : IRegisterBookUseCase
{
    private readonly IBooksWriteOnlyRepository _booksOnlyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterBookUseCase(
        IBooksWriteOnlyRepository booksOnlyRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _booksOnlyRepository = booksOnlyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseBookJson> Execute(RequestBookJson request)
    {
        Validate(request);

        var bookEntity = _mapper.Map<Book>(request);

        await _booksOnlyRepository.Add(bookEntity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseBookJson>(bookEntity);
    }

    private void Validate(RequestBookJson request)
    {
        var validation = new BookValidator();

        var result = validation.Validate(request);

        if(result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(r => r.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
