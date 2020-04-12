using System.Collections.Generic;


namespace LibraryAssistant.Core.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string NIN { get; set; }
        public string PhoneNumber { get; set; }
        public List<BooksActivity> BooksActivity { get; set; }
    }
}
