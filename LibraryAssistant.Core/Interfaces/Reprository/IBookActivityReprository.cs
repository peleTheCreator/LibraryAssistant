using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryAssistant.Core.Models.Requests.BookActivity;
using LibraryAssistant.Core.Models.Responses.BookActivity;

namespace LibraryAssistant.Core.Interfaces.Reprository
{
    public interface IBookActivityReprository
    {
        Task<BookCheckPage> CheckPage(int id);
        Task BookCheckIn(BookCheckIn vm);
    }
}
