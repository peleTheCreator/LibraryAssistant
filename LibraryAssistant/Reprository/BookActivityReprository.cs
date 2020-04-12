using LibraryAssistant.Core.Interfaces.Reprository;
using LibraryAssistant.Core.Models.Requests.BookActivity;
using LibraryAssistant.Core.Models.Responses.BookActivity;
using LibraryAssistant.Data;
using LibraryAssistant.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.API.Reprository
{
    public class BookActivityReprository : IBookActivityReprository
    {
        private readonly DataContext _dataContext;

        public BookActivityReprository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

      
        public async Task<BookCheckPage> CheckPage(int id)
        {
            var vm = await _dataContext.
                 BooksActivities.Include(d=>d.Users).
                 Where(b => b.BooksId == id).OrderBy(s => s.CheckOut).LastAsync();

            var model = new BookCheckPage
            {
                bookId = id,
                CheckOutDate = vm.CheckOut,
                Email = vm.Users.Email,
                ExpectedCheckInDate = vm.ExpectedCheckIn,
                FullName = vm.Users.FullName,
                NIN = vm.Users.NIN,
                PhoneNumber = vm.Users.PhoneNumber,              
            };
            var NumberOfDaysLate = vm.ExpectedCheckIn.NumberOfDaysLate();
            model.NumberOfDaysLate = (int)NumberOfDaysLate;
            model.PenaltyFee = NumberOfDaysLate == 0 ? 0.0m : (decimal)(200 * NumberOfDaysLate);
     
            return model;
        }


        public async Task BookCheckIn(BookCheckIn vm)
        {
            var model = await _dataContext.
                BooksActivities.Include(d => d.Users).
                Where(b => b.BooksId == vm.id).OrderBy(s => s.CheckOut).LastAsync();
            model.Books.Status = true;
            model.PenaltyFee = vm.PenaltyFee;
            model.LateDays = vm.NumberOfDaysLate;
             await  _dataContext.SaveChangesAsync();
        }
    }
}
