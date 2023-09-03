namespace BookService.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearPublished { get; set; }
        public IEnumerable<AuthorModel> Authors { get; set; } = new List<AuthorModel>();
    }
}
