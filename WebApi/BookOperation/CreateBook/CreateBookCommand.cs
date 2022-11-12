using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
            { throw new InvalidOperationException("kitap zaten mevcut"); }

            book = new Book();
            book.Title = Model.Title;
            book.PageCount = Model.PageCount;
            book.PublishDate = Model.PublishDate;
            book.GenreId = Model.GenreID;

            _dbContext.books.Add(book);
            _dbContext.SaveChanges();
        }
        public class CreateBookModel
        {
            public string? Title { get; set; }
            public int GenreID { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}