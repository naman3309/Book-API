using AutoMapper;
using BookAPI.Data;
using BookAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Repository
{
    public class BookRespository:IBookRepository
    {
        private readonly BookStoreDB _context;
        private readonly IMapper _mapper;

        public BookRespository(BookStoreDB context,IMapper mapper)
        {
            _context=context;
            _mapper = mapper;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }
        
        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            var record = await _context.Books.FindAsync(id);
            return _mapper.Map<BookModel>(record);
        }


        public async Task<int> AddBook(BookModel bookmodel)
        {
            var book = new Books()
            {
                Title = bookmodel.Title,
                Description = bookmodel.Description,
                Author = bookmodel.Author
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task UpdateBookAsync(int id, BookModel bookmodel)
        {
            var book = new Books()
            {
                Id = id,
                Title = bookmodel.Title,
                Description = bookmodel.Description,
                Author = bookmodel.Author
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateBookByPatchAsync(int id , JsonPatchDocument bookmodel)
        {
            var book = await _context.Books.FindAsync(id);
            if(book != null) 
            {
                bookmodel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = new Books() { Id  = id };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

    }
}
