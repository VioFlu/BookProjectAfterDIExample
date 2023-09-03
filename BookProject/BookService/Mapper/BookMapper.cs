using AutoMapper;

namespace BookService.Mapper
{
    public class BookMapper :Profile
    {
        public BookMapper()
        {
            CreateMap<Entities.Book, Models.BookModel>().ForMember(d => d.Authors, opt => opt.MapFrom(src => src.Authors));
        }
    }
   
}
