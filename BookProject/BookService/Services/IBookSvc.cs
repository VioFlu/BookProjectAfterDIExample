namespace BookService.Services
{
    public interface IBookSvc
    {
        IEnumerable<Models.BookModel> GetBooks();
    }
}
