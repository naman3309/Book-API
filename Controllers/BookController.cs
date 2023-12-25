using BookAPI.Models;
using BookAPI.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository=bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if(book == null) 
            { 
                return NotFound(); 
            }
            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBooktoDB([FromBody]BookModel bookmodel)
        {
            var id = await _bookRepository.AddBook(bookmodel);

            return CreatedAtAction(nameof(GetBookById), new { Id = id, controller = "book" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id, [FromBody]BookModel bookmodel)
        {
            await _bookRepository.UpdateBookAsync(id, bookmodel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookByPatch([FromRoute]int id, [FromBody]JsonPatchDocument bookmodel)
        {
            await _bookRepository.UpdateBookByPatchAsync(id, bookmodel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute]int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok();
        }
    
    
    
    }
}
