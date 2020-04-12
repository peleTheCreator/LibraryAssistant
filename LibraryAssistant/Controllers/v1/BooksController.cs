using AutoMapper;
using LibraryAssistant.API.Filters;
using LibraryAssistant.Core.Entities;
using LibraryAssistant.Core.Interfaces.Managers;
using LibraryAssistant.Core.Interfaces.Reprository;
using LibraryAssistant.Core.Models.Requests.Books;
using LibraryAssistant.Core.Models.Responses;
using LibraryAssistant.Core.Models.Responses.Books;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace LibraryAssistant.API.Controllers.v1
{
    [Route("api/v1/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksManager _booksManager;

        public BooksController(IBooksManager booksManager)
        {
            _booksManager = booksManager;
        }
     
        [HttpGet()]
        public async Task<IActionResult> GetAllBooks(BooksRequestParams vm)
        {
           return Ok( await _booksManager.GetAllBooks(vm));
        }

        [HttpGet("id", Name = "GetBook")]
        public async Task<IActionResult> GetBooks(string id)
        {
            var model = await _booksManager.GetABooks(id);          
           return  Ok(model);
        }

        [AdminFilter]
        [HttpPost()]
        public async Task<IActionResult> CreateBook(BookCreationModel vm)
        {
            var bookId = await _booksManager.CreateBook(vm);

            return CreatedAtRoute("GetBook",
               new { id = bookId },
               vm);
        }
    }
}
