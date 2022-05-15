using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi_Common.Models;
using WebApi_Server.Repositories;

namespace WebApi_Server.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var books = BookRepository.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var books = BookRepository.GetBooks();

            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody]Book book)
        {
            var books = BookRepository.GetBooks().ToList();

            book.Id = GetNewId(books);
            book.IsBorrowed = false;
            book.NameOfBorrower = string.Empty;
            book.DateOfBorrowing = System.DateTime.MinValue;
            book.DateOfReturn = System.DateTime.MinValue;
            books.Add(book);

            BookRepository.StoreBooks(books);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody]Book book)
        {
            var books = BookRepository.GetBooks().ToList();

            var bookToUpdate = books.FirstOrDefault(b => b.Id == book.Id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Author = book.Author;
                bookToUpdate.Title = book.Title;
                bookToUpdate.IsBorrowed = book.IsBorrowed;
                bookToUpdate.NameOfBorrower = book.NameOfBorrower;
                bookToUpdate.DateOfBorrowing = book.DateOfBorrowing;
                bookToUpdate.DateOfReturn = book.DateOfReturn;

                BookRepository.StoreBooks(books);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var books = BookRepository.GetBooks().ToList();

            var bookToDelete = books.FirstOrDefault(b => b.Id == id);
            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);

                BookRepository.StoreBooks(books);
                return Ok();
            }

            return NotFound();
        }

        private long GetNewId(IEnumerable<Book> books)
        {
            long newId = 0;
            foreach (var book in books)
            {
                if (book.Id > newId)
                {
                    newId = book.Id;
                }
            }

            return newId + 1;
        }
    }
}
