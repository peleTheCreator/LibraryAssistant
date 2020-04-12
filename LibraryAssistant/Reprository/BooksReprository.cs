using LibraryAssistant.Core.Entities;
using LibraryAssistant.Core.Interfaces.Reprository;
using LibraryAssistant.Core.Models.Requests.Books;
using LibraryAssistant.Core.Models.Responses.Books;
using LibraryAssistant.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.API.Reprository
{
    public class BooksReprository : IBooksReprository
    {

        private readonly DataContext _dataContext;

        public BooksReprository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<(Books, List<BookActivityModel>)> GetBook(int id)
        {
            //get the book by id
            //use the id to get the activity from bookactivity
            var book = await _dataContext.Books.FirstAsync(b => b.Id == id);


            var query =  _dataContext.
                BooksActivities.AsQueryable();

            var RecentActivitybookId = await query
                .OrderBy(s => s.CheckOut)
                .ThenBy(s=>s.CheckIn)
                .Select(s=>s.BooksId)
                .FirstAsync();

            int i = 0;
            var bookactivity = await query
                .Where(s => s.BooksId == RecentActivitybookId)
                .Select(s => new BookActivityModel
                {
                    Sn = i+1,
                    CheckIn = s.CheckIn.ToString("dd-MM-yyy"),
                    CheckOut = s.CheckOut.ToString("dd-MM-yyy")
                }).ToListAsync();

            return (book, bookactivity);
        }

        public async Task<List<Books>> GetAllBooks(BooksRequestParams vm)
        {
            var query = _dataContext.Books.AsQueryable();

            if (!(string.IsNullOrWhiteSpace(vm.ISBN)))
               query = query.Where(x => EF.Functions.Like(x.ISBN, $"%{vm.ISBN}%"));
            if (!(string.IsNullOrWhiteSpace(vm.Title)))
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{vm.Title}%"));
            if(vm.Status != null)
                query = query.Where(x => x.Status == vm.Status);

            return await query.ToListAsync();
        }


        public async Task<bool> BookExists(int id)
        {
            return await _dataContext.Books.AnyAsync(a => a.Id == id);
        }

        public void CreateBook(Books booksEntity)
        {
            _dataContext.Add(booksEntity);
        }

        public  async Task<bool> SaveAsync()
        {
             return (await _dataContext.SaveChangesAsync()) >= 0;
            
        }

        public void UpdateBookStatus(int[] bookIds)
        {
            for (int i = 0; i < bookIds.Length; i++)
            {
                var query =  _dataContext.Books.First(s => s.Id == bookIds[i]);
                query.Status = false;
                 _dataContext.SaveChanges();

            }

        }
    }
}
