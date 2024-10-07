using BookAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace BookAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int id);

        Task<int> AddBook(BookModel bookmodel);
        Task UpdateBookAsync(int id, BookModel bookmodel);

        Task UpdateBookByPatchAsync(int id, JsonPatchDocument bookmodel);
        Task DeleteBookAsync(int id);
    }
}