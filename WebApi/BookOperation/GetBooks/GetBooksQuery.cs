using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            //new List<BooksViewModel>();
            // foreach (var book in bookList)
            // {
            //     vm.Add(new BooksViewModel(){
            //         Title=book.Title,
            //         Genre=((GenreEnum)book.GenreId).ToString(),
            //         PageCount= book.PageCount,
            //         PublishDate=book.PublishDate.Date.ToString("dd/MM/yy")
            //     });
            //}
            return vm ;
        }
        public class BooksViewModel
        {
            public string? Title { get; set; }
            public string? Genre { get; set; }
            public int PageCount { get; set; }
            public string? PublishDate { get; set; }
        }
    }
}