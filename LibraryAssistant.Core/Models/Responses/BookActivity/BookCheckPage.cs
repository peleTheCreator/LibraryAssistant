using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAssistant.Core.Models.Responses.BookActivity
{
    public class BookCheckPage
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string NIN { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime ExpectedCheckInDate { get; set; }
        public int bookId { get; set; }
        public Decimal PenaltyFee { get; set; }
        public int NumberOfDaysLate { get; set; }

    }
}
