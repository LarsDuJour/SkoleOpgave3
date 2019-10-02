using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book("Mein Trampf", "Pablo Flemmingway", 42, "1234567890120"),
            new Book("Den Bedste Bog", "Lars", 459, "1234567890121"),
            new Book("Den næstBEDSTE bog", "Ikke Lars", 999, "1234567890122"),
            new Book("Triologi-antologien: Den Bedste, Næstbedste bog, samt en blanding af mine bedste hits", "Lars", 420, "1234567890123")
        };
        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _books;
        }

        // GET: api/Book/5
        [HttpGet("{isbn}", Name = "Get")]
        public Book Get(string isbn)
        {
            return _books.Find(b => b.Isbn == isbn);
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            _books.Add(value);
        }

        // PUT: api/Book/5
        [HttpPut("{isbn}")]
        public void Put(string isbn, [FromBody] Book value)
        {
            Book b = _books.Find(boo => boo.Isbn == isbn);
            b.Isbn = value.Isbn;
            b.Author = value.Author;
            b.Pages = value.Pages;
            b.Title = value.Title;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn}")]
        public void Delete(string isbn)
        {
            _books.Remove(_books.Find(b => b.Isbn == isbn));
        }
    }
}
