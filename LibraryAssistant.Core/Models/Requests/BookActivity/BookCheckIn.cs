using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAssistant.Core.Models.Requests.BookActivity
{
    public class BookCheckIn
    {
        public int id { get; set; }
        public decimal PenaltyFee { get; set; }
        public int NumberOfDaysLate { get; set; }
    }
}
