using AutoMapper;
using LibraryAssistant.Core.Entities;
using LibraryAssistant.Core.Models.Responses.Books;
using System.Collections.Generic;

namespace LibraryAssistant.API.Mappers
{
    public class RequestToEntityMapper : Profile
    {
        public RequestToEntityMapper()
        {
            CreateMap<Books, BooksModel>();
            CreateMap<List<Books>, List<BooksModel>>();
            CreateMap<BookModel, Books>();
            CreateMap<BookCreationModel, Books>();

        }
    }
}
