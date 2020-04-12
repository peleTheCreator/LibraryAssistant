using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAssistant.Core.Entities;
using LibraryAssistant.Core.Exceptions;
using LibraryAssistant.Core.Interfaces.Managers;
using LibraryAssistant.Core.Interfaces.Reprository;
using LibraryAssistant.Core.Models.Requests.Books;
using LibraryAssistant.Core.Models.Responses.Books;
using Microsoft.Extensions.Logging;

namespace LibraryAssistant.API.Managers
{
    public class BooksManager : IBooksManager
    {
        private readonly IBooksReprository _booksReprository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookActivityManager> _logger;

        public BooksManager(IBooksReprository booksReprository, IMapper mapper, ILogger<BookActivityManager> logger)
        {
            _mapper = mapper;
            _booksReprository = booksReprository;
            _logger = logger;

        }

        public async Task<string> CreateBook(BookCreationModel vm)
        {
            var booksEntity = _mapper.Map<Books>(vm);
            booksEntity.Status = true;
             _booksReprository.CreateBook(booksEntity);
            if (! (await _booksReprository.SaveAsync()))
            {
                _logger.LogInformation("error  log message");

                throw new Exception("Creating an book failed on save.");
            }
            return booksEntity.Id.ToString();
        }

        public async Task<BookModel> GetABooks(string id)
        {
            var successfullyparsed = int.TryParse(id, out int ID);
            if(!successfullyparsed)
                throw new BaseException(HttpStatusCode.BadRequest, "id is not in the right format"); 

            if (!(await _booksReprository.BookExists(ID)))
            {
                _logger.LogInformation("error  log message");

                throw new BaseException(HttpStatusCode.BadRequest, "book does not exist");
            }
            var model = await _booksReprository.GetBook(ID);
           var bookmodel = _mapper.Map<BookModel>(model.Item1);
            bookmodel.BooksActivity = model.Item2;
            return bookmodel;
        }

        public async Task<IEnumerable<BooksModel>> GetAllBooks(BooksRequestParams vm)
        {
           var model = await _booksReprository.GetAllBooks(vm);
            return _mapper.Map<IEnumerable<BooksModel>>(model);  
        }
    }
}
