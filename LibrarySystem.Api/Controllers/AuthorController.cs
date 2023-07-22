using AutoMapper;
using LibrarySystem.Application.Common.Interfaces;
using LibrarySystem.Application.DTOs;
using LibrarySystem.Domain.AuthorAggregate;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CreateAuthorDto createAuthorDto)
    {
        try
        {
            Author newAuthor = Author.CreateAuthor(
                createAuthorDto.FirstName,
                createAuthorDto.LastName
            );
            await _authorRepository.CreateAsync(newAuthor);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }
}
