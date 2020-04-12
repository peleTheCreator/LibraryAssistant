using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAssistant.Core.Models.Requests.BookActivity
{
    public class BookCheckOut
    {      
        public string FullName { get; set; }
        public string Email { get; set; }
        public string NIN { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int ExpectedReturnDay { get; set; } = 10;
        public int[] bookIds  { get; set; }
    }
}
