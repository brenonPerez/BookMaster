using AutoMapper;
using BookMaster.Communication.Requests;
using BookMaster.Communication.Responses;
using BookMaster.Domain.Entities;

namespace BookMaster.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestBookJson, Book>();
    }

    private void EntityToResponse()
    {
        CreateMap<Book, ResponseBookJson>();
    }
}
