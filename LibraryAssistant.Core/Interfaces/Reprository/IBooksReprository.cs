using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryAssistant.Core.Entities;
using LibraryAssistant.Core.Models.Requests.Books;
using LibraryAssistant.Core.Models.Responses.Books;

namespace LibraryAssistant.Core.Interfaces.Reprository
{
    public interface IBooksReprository
    {
        Task<List<Books>> GetAllBooks(BooksRequestParams vm);
        Task<(Books, List<BookActivityModel>)> GetBook(int id);
         Task<bool> BookExists(int id);
        void CreateBook(Books booksEntity);
        Task<bool> SaveAsync();
        void UpdateBookStatus(int[] bookIds);
    }
}
