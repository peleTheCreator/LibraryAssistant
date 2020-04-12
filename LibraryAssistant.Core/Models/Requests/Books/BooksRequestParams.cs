using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAssistant.Core.Models.Requests.Books
{
    public class BooksRequestParams
    {
        public string Title { get; set; }
        public bool? Status { get; set; } 
        public string ISBN { get; set; }
    }
}
