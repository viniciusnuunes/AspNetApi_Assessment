using CreateCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreateCodeFirst.Controllers
{
    public class AuthorsController : ApiController
    {
        private DataContext _dataContext;

        public AuthorsController()
        {
            _dataContext = new DataContext();
        }

        // GET
        public IEnumerable<Author> Get()
        {
            return _dataContext.Authors;
        }

        // POST
        public void Post(Author author)
        {
            if (author != null)
            {
                _dataContext.Authors.Add(author);
                _dataContext.SaveChanges();
            }
        }

        // PUT
        public void Put(Author author)
        {
            var authorToUpdate = _dataContext.Authors.Where(a => a.AuthorId == author.AuthorId).SingleOrDefault();

            if (author != null)
            {
                authorToUpdate.AuthorId = author.AuthorId;
                authorToUpdate.FirstName = author.FirstName;
                authorToUpdate.LastName = author.LastName;

                _dataContext.SaveChanges();
            }
        }

        // DELETE
        public void Delete (Author author)
        {
            if (author != null)
            {
                var authorToRemove = _dataContext.Authors.Where(a => a.AuthorId == author.AuthorId).SingleOrDefault();
                if (authorToRemove != null)
                {
                    _dataContext.Authors.Remove(authorToRemove);
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
