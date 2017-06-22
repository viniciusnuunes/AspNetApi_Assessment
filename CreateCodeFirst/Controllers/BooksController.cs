using CreateCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreateCodeFirst.Controllers
{
    public class BooksController : ApiController
    {
        private DataContext _dataContext;

        public BooksController()
        {
            _dataContext = new DataContext();
        }

        // GET
        public IEnumerable<Book> Get()
        {
            return _dataContext.Books;
        }

        // POST
        public void Post(Book book)
        {
            if (book != null)
            {
                _dataContext.Books.Add(book);
                _dataContext.SaveChanges();
            }
        }

        // PUT
        public void Put(Book book)
        {
            var bookToUpdate = _dataContext.Books.Where(b => b.BookId == book.BookId).SingleOrDefault();

            if (book != null)
            {                
                bookToUpdate.Isbn = book.Isbn;
                bookToUpdate.Title = book.Title;
                bookToUpdate.Ano = book.Ano;
                bookToUpdate.Authors = book.Authors;

                _dataContext.SaveChanges();
            }
        }

        // DELETE
        public void Delete(Book book)
        {
            if (book != null)
            {
                var bookToRemove = _dataContext.Books.Where(b => b.BookId == book.BookId).SingleOrDefault();
                if (bookToRemove != null)
                {
                    _dataContext.Books.Remove(bookToRemove);
                    _dataContext.SaveChanges();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _dataContext != null)
            {
                _dataContext.Dispose();
                _dataContext = null;
            }
            base.Dispose(disposing);
        }
    }
}
