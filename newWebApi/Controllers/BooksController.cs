using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using newWebApi.Model;
using newWebApi.Repositories;

namespace newWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
      
        [HttpGet]
        public async Task<IActionResult> getAllBooks()
        {
            var books = await _bookRepository.getAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getBookById([FromRoute]int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if(book == null) 
            {
                return NotFound();  
            }
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> addBook(BookModel bookModel)
        {
            var id =await _bookRepository.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(getBookById),new {id=id, controller="books"},id);    
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookPut([FromBody]BookModel bookModel, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookAsync(id,bookModel);
            return Ok(bookModel);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument  bookModel, [FromRoute] int id)
        {
            await _bookRepository.updateBookPatchAsync (id, bookModel);
            return Ok(bookModel);
        }
        [HttpDelete("{id}")]
        public   async Task<IActionResult> DeleteBook(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok("deleted");

        }
    }

}
