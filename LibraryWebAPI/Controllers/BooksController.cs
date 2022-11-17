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
    public class BooksController : ControllerBase
    {
        private readonly IBookService<Book> _bookService;
        private readonly LibraryDbContext _applicationDbContext;
        public BooksController(IBookService<Book> bookService,
            LibraryDbContext applicationDbContext)
        {
            _bookService = bookService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet(nameof(GetBookById))]
        public IActionResult GetBookById(int Id)
        {
            var obj = _bookService.Get(Id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet(nameof(GetAllBook))]
        public IActionResult GetAllBook()
        {
            var obj = _bookService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpPost(nameof(CreateBook))]
        public IActionResult CreateBook(Book book)
        {
            if (book != null)
            {
                _bookService.Insert(book);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }

        [HttpPost(nameof(UpdateBook))]
        public IActionResult UpdateBook(Book book)
        {
            if (book != null)
            {
                _bookService.Update(book);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete(nameof(DeleteBook))]
        public IActionResult DeleteBook(Book book)
        {
            if (book != null)
            {
                _bookService.Delete(book);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

    }
}
