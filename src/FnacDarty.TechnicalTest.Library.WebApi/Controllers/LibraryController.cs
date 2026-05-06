using FnacDarty.TechnicalTest.Library.Domain.Interfaces;
using FnacDarty.TechnicalTest.Library.Models;
using FnacDarty.TechnicalTest.Library.WebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FnacDarty.TechnicalTest.Library.Controllers
{
    [ApiController]
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _bookService;

        public LibraryController(ILibraryService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("getAllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();

            return Ok(books);
        }

        [HttpPost("addBook")]
        public IActionResult AddBook(AddBookRequest request)
        {
            _bookService.AddBook(request.Title, request.Author);

            return Ok();
        }

        [HttpPost("borrow")]
        public ActionResult<BorrowedBookResult> BorrowBooks(BorrowBooksRequest request)
        {
            var borrowBookResult = _bookService.BorrowBooks(request.CustomerId, request.BookIds);
            return Ok(borrowBookResult);
        }
    }
}