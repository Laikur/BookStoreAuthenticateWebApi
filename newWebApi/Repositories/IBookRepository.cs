using Microsoft.AspNetCore.JsonPatch;
using newWebApi.Model;

namespace newWebApi.Repositories
{
    public interface IBookRepository
    {
        Task<List<BookModel>> getAllBooks();
        Task<BookModel> GetBookByIdAsync(int bookId);
        Task<int> AddBookAsync(BookModel bookModel);
        Task UpdateBookAsync(int book_id, BookModel bookModel);
        Task updateBookPatchAsync(int bookId, JsonPatchDocument bookModel);
        Task DeleteBookAsync(int bookId);
    }
}
