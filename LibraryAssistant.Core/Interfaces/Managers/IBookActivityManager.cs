
using LibraryAssistant.Core.Models.Requests.BookActivity;
using LibraryAssistant.Core.Models.Responses.BookActivity;
using System.Threading.Tasks;

namespace LibraryAssistant.Core.Interfaces.Managers
{
    public interface IBookActivityManager
    {
        Task BookCheckOut(BookCheckOut vm, int[] bookIds);
        Task<BookCheckPage> CheckPage(int id);
        Task BookCheckIn(BookCheckIn vm);
    }
}
