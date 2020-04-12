
using FluentValidation;
using LibraryAssistant.Core.Models.Requests.BookActivity;

namespace LibraryAssistant.API.Validators
{
    public class BookCheckOutValidatorModel : AbstractValidator<BookCheckOut>
    {
        public BookCheckOutValidatorModel()
        {
            RuleFor(x => x.CheckOutDate)
             .NotEmpty();
            RuleFor(x => x.Email)
               .NotEmpty()
               .Matches(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                 + "@"
                  + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
           
            RuleFor(x => x.FullName)
              .NotEmpty();
            RuleFor(x => x.NIN)
             .NotEmpty();

            RuleFor(x => x.PhoneNumber)
           .NotEmpty();

          RuleFor(x => x.bookIds)
         .NotEmpty();

        }
    }
}
