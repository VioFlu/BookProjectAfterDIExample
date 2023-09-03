using BookService.Models;

namespace BookService.Utility
{
    public interface IBookTransformer
    {
        List<BookModel> GetBookNameSentenceCase(List<BookModel> books);
    }
}
