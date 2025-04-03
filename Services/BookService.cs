using LibraryApi.Models.DTOs;
using LibraryApi.Models.Entities;
using LibraryApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookSummaryDto>> GetAllBooks();
        Task<BookDto> GetBookById(int id);
        Task AddBook(BookDto bookDto);
        Task UpdateBook(int id, BookDto bookDto);
        Task DeleteBook(int id);
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookSummaryDto>> GetAllBooks()
        {
            var books = await _bookRepository.GetAll();
            return books.Select(b => new BookSummaryDto
            {
                Id = b.Id,
                Title = b.Title,
                PhotoUrl = b.PhotoUrl,
                PublisherName = b.PublisherName,
                PageCount = b.PageCount
            }).ToList();
        }

        public async Task<BookDto> GetBookById(int id)
        {
            // Kitabı veritabanından al
            var book = await _bookRepository.GetById(id);
            if (book == null) return null;

            // Yazar ve kategori bilgilerini navigasyon özelliklerinden al
            var authorName = book.Author?.Name;
            var categoryName = book.Category?.Name;

            // DTO'yu oluştur ve bilgileri ata
            return new BookDto
            {
                Id = book.Id,
                ISBN = book.ISBN,
                Title = book.Title,
                AuthorName = authorName,
                CategoryName = categoryName,
                PhotoUrl = book.PhotoUrl,
                Summary = book.Summary,
                PageCount = book.PageCount,
                PublisherName = book.PublisherName,
                IsDeleted = book.IsDeleted,
                CreatedDate = book.CreatedDate,
                UpdatedDate = book.UpdatedDate
            };
        }

        public async Task AddBook(BookDto bookDto)
        {
            // Yazar adını kullanarak yazar ID'sini bul
            var authorId = await _bookRepository.GetAuthorIdByName(bookDto.AuthorName);
            if (authorId == null)
            {
                throw new Exception("Belirtilen yazar bulunamadı.");
            }

            // Kategori adını kullanarak kategori ID'sini bul
            var categoryId = await _bookRepository.GetCategoryIdByName(bookDto.CategoryName);
            if (categoryId == null)
            {
                throw new Exception("Belirtilen kategori bulunamadı.");
            }

            // Kitap nesnesini oluştur ve ID'leri ata
            var book = new Book
            {
                Title = bookDto.Title,
                AuthorId = authorId.Value,
                CategoryId = categoryId.Value,
                PhotoUrl = bookDto.PhotoUrl,
                Summary = bookDto.Summary,
                PublisherName = bookDto.PublisherName,
                ISBN = bookDto.ISBN,
                PageCount = bookDto.PageCount,
                CreatedDate = DateTime.Now
            };

            await _bookRepository.Add(book);
        }

        public async Task UpdateBook(int id, BookDto bookDto)
        {
            var existingBook = await _bookRepository.GetById(id);
            if (existingBook != null)
            {
                existingBook.Title = bookDto.Title;
                existingBook.PhotoUrl = bookDto.PhotoUrl;
                existingBook.PublisherName = bookDto.PublisherName;
                existingBook.ISBN = bookDto.ISBN;
                existingBook.PageCount = bookDto.PageCount;
                existingBook.IsDeleted = bookDto.IsDeleted;
                existingBook.UpdatedDate = DateTime.UtcNow;

                await _bookRepository.Update(existingBook);
            }
        }

        public async Task DeleteBook(int id)
        {
            var book = await _bookRepository.GetById(id);
            if (book != null)
                await _bookRepository.Delete(book);
        }
    }
}