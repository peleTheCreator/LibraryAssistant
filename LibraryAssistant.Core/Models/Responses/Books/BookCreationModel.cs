using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAssistant.Core.Models.Responses.Books
{
    public class BookCreationModel
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublishYear { get; set; }
        public Decimal CoverPrice { get; set; }
    }
}
