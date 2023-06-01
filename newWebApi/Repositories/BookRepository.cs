using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using newWebApi.Data;
using newWebApi.Model;

namespace newWebApi.Repositories
{
    public class BookRepository:IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context,IMapper  mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookModel>> getAllBooks()
        {
            //var record = await _context.Booka.Select(x=> new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description,
            //}).ToListAsync();
            //return record;
            var record = await _context.Booka.ToListAsync();
            return _mapper.Map<List<BookModel>>(record);
        }
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            //var record = await _context.Booka.Where(x=>x.Id == bookId).Select(x=>new BookModel()
            //{
            //    Id=x.Id,
            //    Title = x.Title,  
            //    Description = x.Description,
            //}).FirstOrDefaultAsync();

            //return record;
            var books = await _context.Booka.FindAsync(bookId);
            return _mapper.Map<BookModel>(books);
        }
        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description,
            };
            _context.Booka.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;

        }
        public async Task UpdateBookAsync(int book_id,BookModel bookModel)
        {
            //var book = await _context.Booka.FindAsync(book_id);
            //if(book != null)
            //{
            //    book.Title = bookModel.Title;
            //    book.Description = bookModel.Description;
            //    await _context.SaveChangesAsync();
            //}
            var book = new Books()
            {
                Id = book_id,
                Title = bookModel.Title,
                Description = bookModel.Description,

            };
            _context.Booka.Update(book);
            await _context.SaveChangesAsync();


        }

        public async Task updateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Booka.FindAsync(bookId);
            if(book !=null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();  
                
            }
        }
        public async Task DeleteBookAsync(int bookId)
        {
            var book = new Books() { Id = bookId };
            _context.Booka.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
