using BookService.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookService.DbContexts

{
    public class BookDbContext :DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        protected readonly IConfiguration _configuration;
        public BookDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(_configuration.GetConnectionString("BookSQLLiteDbConnection"));
            //options.UseSqlServer(_configuration.GetConnectionString("BookAzureSQLConnection"));
        }
    }
}
