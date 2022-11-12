using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            { throw new InvalidOperationException("Güncellenecek kitap bulunamadı"); }

            book.GenreId = Model.GenreID != default ? Model.GenreID : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            _dbContext.SaveChanges();
        }
        public class UpdateBookModel
        {
            public string? Title { get; set; }
            public int GenreID { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }


    }
}