using AutoMapper;
using LibrarySystem.Application.DTOs;
using LibrarySystem.Domain.AuthorAggregate;

namespace LibrarySystem.Api.Mapping;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        CreateMap<Author, CreateAuthorDto>().ReverseMap();
    }
}
