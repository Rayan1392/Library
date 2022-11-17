using DomainLayer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using ServiceLayer.Contracts;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService<Author> _authorService;
        private readonly LibraryDbContext _libraryDbContext;
        public AuthorsController(IAuthorService<Author> authorService,
            LibraryDbContext applicationDbContext)
        {
            _authorService = authorService;
            _libraryDbContext = applicationDbContext;
        }

        [HttpGet(nameof(GetAuthorById))]
        public IActionResult GetAuthorById(int Id)
        {
            var obj = _authorService.Get(Id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet(nameof(GetAllAuthor))]
        public IActionResult GetAllAuthor()
        {
            var obj = _authorService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpPost(nameof(CreateAuthor))]
        public IActionResult CreateAuthor(Author author)
        {
            if (author != null)
            {
                _authorService.Insert(author);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }

        [HttpPost(nameof(UpdateAuthor))]
        public IActionResult UpdateAuthor(Author author)
        {
            if (author != null)
            {
                _authorService.Update(author);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete(nameof(DeleteAuthor))]
        public IActionResult DeleteAuthor(Author author)
        {
            if (author != null)
            {
                _authorService.Delete(author);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

    }
}
