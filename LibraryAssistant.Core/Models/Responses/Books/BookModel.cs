using LibraryAssistant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAssistant.Core.Models.Responses.Books
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublishYear { get; set; }
        public Decimal CoverPrice { get; set; }
        public bool Status { get; set; }
        public List<BookActivityModel> BooksActivity { get; set; }
    }


    public class BookActivityModel
    {
        public int Sn { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }

    }
}
