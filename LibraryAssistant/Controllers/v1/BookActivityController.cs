using LibraryAssistant.API.Filters;
using LibraryAssistant.Core.Interfaces.Managers;
using LibraryAssistant.Core.Models.Requests.BookActivity;
using LibraryAssistant.Core.Models.Responses;
using LibraryAssistant.Core.Models.Responses.BookActivity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAssistant.API.Controllers.v1
{
    
    [Route("api/bookactivity")]
    public class BookActivityController : Controller
    {
        private readonly IBookActivityManager _bookActivityManager;

        public BookActivityController(IBookActivityManager bookActivityManager)
        {
            _bookActivityManager = bookActivityManager;
        }
       
        [HttpPost("checkout")]
        public async Task<IActionResult> BookCheckOut(BookCheckOut vm)
        {
            await _bookActivityManager.BookCheckOut(vm, vm.bookIds);
            return Ok(new Response<BookCheckOut>{Succeeded = true,
                Message = "checkout for books is successfull",
                Data = vm});
        }


        [HttpGet("checkpage")]
        public async Task<IActionResult> CheckPage(int id)
        {
            //display last check out for the book
            BookCheckPage model = await _bookActivityManager.CheckPage(id);
           return Ok(model);
        }

        [HttpPost("checkin")]
        public async Task<IActionResult> BookCheckIn(BookCheckIn vm)
        {
            await _bookActivityManager.BookCheckIn(vm);
            return NoContent();
           
        }
    }
}
