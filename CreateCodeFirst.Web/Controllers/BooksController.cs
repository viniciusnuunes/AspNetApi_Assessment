using CreateCodeFirst.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CreateCodeFirst.Web.Controllers
{
    public class BooksController : Controller
    {        
        private static HttpClient apiClient = new HttpClient();
        private DataContext dbContext = new DataContext();
        

        public BooksController()
        {
            apiClient = new HttpClient();                

            apiClient.BaseAddress = new Uri("http://localhost:64073/");
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // HTTP GET
        public async Task<ActionResult> Index()
        {
            List<Book> bookInstanciado = new List<Book>();

            HttpResponseMessage response = await apiClient.GetAsync("api/books");
            if (response.IsSuccessStatusCode)
            {
                var bookResponse = response.Content.ReadAsStringAsync().Result;
                bookInstanciado = JsonConvert.DeserializeObject<List<Book>>(bookResponse);

                return View(bookInstanciado);
            }
            return View("Error");
        }

        public ActionResult Create()
        {
            return View(new Book());
        }

        //The Post method
        [HttpPost]
        public async Task<ActionResult> Create(Book book)
        {
            HttpResponseMessage responseMessage = await apiClient.PostAsJsonAsync("api/books", book);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await apiClient.GetAsync("api/books" + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var bookResponse = responseMessage.Content.ReadAsStringAsync().Result;
                var bookInstanciado = JsonConvert.DeserializeObject<Book>(bookResponse);

                return View(bookInstanciado);
            }
            return View("Error");
        }

        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Book book)
        {
            HttpResponseMessage responseMessage = await apiClient.PutAsJsonAsync("api/books" + "/" + id, book);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing && apiClient != null)
            {
                apiClient.Dispose();
                apiClient = null;
            }
            base.Dispose(disposing);
        }
    }
}