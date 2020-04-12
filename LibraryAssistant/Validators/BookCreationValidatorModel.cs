using FluentValidation;
using LibraryAssistant.Core.Models.Responses.Books;

namespace LibraryAssistant.API.Validators
{
    public class BookCreationValidatorModel : AbstractValidator<BookCreationModel>
    {
        public BookCreationValidatorModel()
        {
            RuleFor(x => x.CoverPrice)
               .NotEmpty();
            RuleFor(x => x.ISBN)
               .NotEmpty();
            RuleFor(x => x.Title)
               .NotEmpty();
            RuleFor(x => x.PublishYear)
              .NotEmpty();
        }
    }
    
}
