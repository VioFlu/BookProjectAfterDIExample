namespace BookService.Entities

{
    public class Book 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearPublished { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
