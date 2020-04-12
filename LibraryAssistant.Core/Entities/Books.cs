using System;
using System.Collections.Generic;


namespace LibraryAssistant.Core.Entities
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublishYear { get; set; }
        public Decimal CoverPrice { get; set; }
        public bool Status { get; set; }
        public List<BooksActivity> BooksActivity { get; set; }
    }
}
