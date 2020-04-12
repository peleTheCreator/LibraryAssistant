using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LibraryAssistant.Core.Entities
{
    public class BooksActivity
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int RetUrnDays { get; set; }
        public DateTime ExpectedCheckIn { get; set; }
        public decimal PenaltyFee { get; set; }
        public int LateDays { get; set; }
        public int BooksId { get; set; }
        public Books Books { get; set; }
        public Users Users { get; set; }
        public int UsersId { get; set; }
    }
}
