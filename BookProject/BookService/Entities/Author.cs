namespace BookService.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
        
    }
}
