﻿using Microsoft.AspNetCore.Mvc;
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
            var book = BookRepository.GetBook(id);
            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpGet("{borrower}")]
        public ActionResult<Book> Get(string borrower)
        {
            var books = BookRepository.GetBooksOfBorrower(borrower);
            if (books != null)
            {
                return Ok(books);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody]Book book)
        {
            book.IsBorrowed = false;
            book.NameOfBorrower = string.Empty;
            book.DateOfBorrowing = System.DateTime.MinValue;
            book.DateOfReturn = System.DateTime.MinValue;
           
            BookRepository.AddBook(book);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody]Book book, long id)
        {
            var bookToUpdate = BookRepository.GetBook(id);

            if (bookToUpdate != null)
            {  
                BookRepository.UpdateBook(bookToUpdate);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var bookToDelete = BookRepository.GetBook(id);

            if (bookToDelete != null)
            {
                BookRepository.AddBook(bookToDelete);
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
