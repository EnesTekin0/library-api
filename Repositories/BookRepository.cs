using LibraryApi.Data;
using LibraryApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApi.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task Add(Book book);
        Task Update(Book book);
        Task Delete(Book book);

        Task<int?> GetAuthorIdByName(string authorName);
        Task<int?> GetCategoryIdByName(string categoryName);
    }

    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task Add(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        //Yazar adına göre yazar ID'sini bul
        public async Task<int?> GetAuthorIdByName(string authorName)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Name == authorName);
            return author?.Id;
        }

        //Kategori adına göre kategori ID'sini bul
        public async Task<int?> GetCategoryIdByName(string categoryName)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
            return category?.Id;
        }
    }
}