using AutoMapper;
using BookService.DbContexts;
using BookService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.Services
{
    public class BookSvc :IBookSvc
    {
        private readonly BookDbContext _dbContext;
        private readonly IMapper _mapper;
      
        public BookSvc(BookDbContext booksDbContext, IMapper mapper)
        {
            _dbContext = booksDbContext;
            _mapper = mapper;
        }
        public IEnumerable<BookModel> GetBooks()
        {
            return _mapper.Map<IEnumerable<Models.BookModel>>(_dbContext.Books.Include(a => a.Authors));
        }
       
    }
}
