using LibraryAssistant.Core.Entities;
using LibraryAssistant.Core.Models.Requests.Books;
using LibraryAssistant.Core.Models.Responses.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAssistant.Core.Interfaces.Managers
{

    public interface IBooksManager
    {
        Task<IEnumerable<BooksModel>> GetAllBooks(BooksRequestParams vm);
        Task<BookModel> GetABooks(string id);
        Task<string> CreateBook(BookCreationModel vm);
    }
}
