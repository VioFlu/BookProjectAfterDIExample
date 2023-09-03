using AutoMapper;

namespace BookService.Mapper
{
    public class AuthorMapper :Profile
    {
        public AuthorMapper()
        {
            CreateMap<Entities.Author, Models.AuthorModel>().ForMember(
                a => a.BookId,
                o => o.MapFrom(t => t.Books.First().Id)
                );
        }
    }
}
