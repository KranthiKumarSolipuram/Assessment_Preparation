using Assessment_Preparation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assessment_Preparation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly BookstoreDbContext bookstoreDbContext;

        public BookController(BookstoreDbContext bookstoreDbContext)
        {
            this.bookstoreDbContext = bookstoreDbContext;
        }

        [HttpGet]
        public IActionResult Get() {
            var Book = bookstoreDbContext.Books.ToList();
            return Ok(Book);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var Book = bookstoreDbContext.Books.Find(id);
            if (Book == null) 
            { 
                return NotFound();
            }
            return Ok(Book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            bookstoreDbContext.Books.Add(book);
            bookstoreDbContext.SaveChanges();
            return Ok(book);
        }

        [HttpPut]
        public IActionResult Put(int id,[FromBody] Book book) { 
            bookstoreDbContext.Books.Update(book);
            return Ok(book);
        }

        [HttpDelete]
        public IActionResult DeleteById(int id) {
            var book = bookstoreDbContext.Books.Find(id);
            if(book == null)
            {
                return NotFound();
            }
            bookstoreDbContext.Remove(book);
            bookstoreDbContext.SaveChanges();
            return Ok(book);
        }
    }

}
