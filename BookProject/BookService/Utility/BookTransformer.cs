using BookService.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookService.Utility
{
    public class BookTransformer : IBookTransformer
    {
        private readonly ILogger<BookTransformer> _logger = new LoggerFactory().CreateLogger<BookTransformer>();


        public List<BookModel> GetBookNameSentenceCase(List<BookModel> books)
        {
            _logger.LogInformation("Convert the names of the books in sentence case ");
            foreach (var book in books)
            {
                book.Name = book.Name.ToSentenceCase();
            }
            return books;
        }
    }
}
