using AutoMapper;
using LibraryAssistant.Core.Entities;
using LibraryAssistant.Core.Models.Responses.Books;
using System.Collections.Generic;

namespace LibraryAssistant.API.Mappers
{
    public class EntityToResponseMapper : Profile
    {
        public EntityToResponseMapper()
        {
            CreateMap<BooksModel, Books>();
            CreateMap<BooksModel, Books>();
            CreateMap<List<BooksModel>, List<Books>>();
            CreateMap<Books,BookModel>();
            CreateMap<BookCreationModel, Books>();
        }
    }
}
