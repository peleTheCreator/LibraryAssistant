

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LibraryAssistant.Core.Entities;
using LibraryAssistant.Core.Exceptions;
using LibraryAssistant.Core.Interfaces.Managers;
using LibraryAssistant.Core.Interfaces.Reprository;
using LibraryAssistant.Core.Models.Requests.BookActivity;
using LibraryAssistant.Core.Models.Responses.BookActivity;
using LibraryAssistant.Extensions;
using Microsoft.Extensions.Logging;

namespace LibraryAssistant.API.Managers
{
    public class BookActivityManager : IBookActivityManager
    {
        private readonly IBookActivityReprository _bookActivityReprository;
        private readonly IBooksReprository _booksReprository;
        private readonly IUserReprository _IUserReprository;
        private readonly ILogger<BookActivityManager> _logger;

        public BookActivityManager(IBookActivityReprository bookActivityReprository,
            IBooksReprository booksReprository, IUserReprository userReprository, ILogger<BookActivityManager> logger)
        {
            _bookActivityReprository = bookActivityReprository;
            _booksReprository = booksReprository;
            _IUserReprository = userReprository;
            _logger = logger;
        }

        public async Task BookCheckIn(BookCheckIn vm)
        {
            if (!(await _booksReprository.BookExists(vm.id)))
            {
                _logger.LogInformation("error  log message");

                throw new BaseException(HttpStatusCode.BadRequest, $"you cant checkout the book with Id : {vm.id}");
            }
             await _bookActivityReprository.BookCheckIn(vm);
        }

        public async Task BookCheckOut(BookCheckOut vm, int[] bookIds)
        { 
            if (bookIds == null)
            {
                _logger.LogInformation("error  log message");

                throw new BaseException(HttpStatusCode.BadRequest, "bookIds can not be null or empty");
            }


            for (int i = 0;  i < bookIds.Length -1; i++)
            {
                if (!(await _booksReprository.BookExists(bookIds[i])))
                {
                    _logger.LogInformation("error  log message");
                    throw new BaseException(HttpStatusCode.BadRequest, $"you cant checkout the book with Id : {bookIds}");
                };
            }

            var BooksActivity = bookIds.AsEnumerable().Select(s => new BooksActivity {
                BooksId = s,
                CheckOut = vm.CheckOutDate,
                RetUrnDays = vm.ExpectedReturnDay,
                ExpectedCheckIn = vm.CheckOutDate.AddBusinessDays(vm.ExpectedReturnDay),  
            }).ToList();

             var user = new Users { Email = vm.Email, FullName = vm.FullName,
                 NIN = vm.NIN, PhoneNumber = vm.PhoneNumber, BooksActivity = BooksActivity
             };



            _IUserReprository.AddUser(user);

            _booksReprository.UpdateBookStatus(bookIds);

            if (!(await _IUserReprository.SaveAsync()))
            {
                throw new BaseException(HttpStatusCode.InternalServerError, $"an error occure while saving data");
            }


        }

        public async Task<BookCheckPage> CheckPage(int id)
        {
            if (!(await _booksReprository.BookExists(id)))
            {
                throw new BaseException(HttpStatusCode.BadRequest, $"you cant checkout the book with Id : {id}");
            };
            return await _bookActivityReprository.CheckPage(id);
        }
    }
}
