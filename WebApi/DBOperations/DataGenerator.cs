using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.books.Any())
                return;

                context.books.AddRange(
                    new Book
                    {
                        //Id=1,
                        Title="Lean Startup",
                        GenreId=2,
                        PageCount=250,
                        PublishDate= new DateTime(2000,03,02)
                    },
                    new Book
                    {
                        //Id=2,
                        Title="Herland",
                        GenreId=2,
                        PageCount=200,
                        PublishDate= new DateTime(2010,05,21)
                    },
                    new Book
                    {
                        //Id=3,
                        Title="Dune",
                        GenreId=3,
                        PageCount=540,
                        PublishDate= new DateTime(2002,12,05)
                    }

                );
                context.SaveChanges();
            }
        }
    }
}