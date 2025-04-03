using LibraryApi.Models.DTOs;
using LibraryApi.Models.Entities;
using LibraryApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorSummaryDto>> GetAllAuthors();
        Task<AuthorDto> GetAuthorById(int id);
        Task AddAuthor(AuthorDto authorDto);
        Task UpdateAuthor(int id, AuthorDto authorDto);
        Task DeleteAuthor(int id);
    }

    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<AuthorSummaryDto>> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAll();
            return authors.Select(a => new AuthorSummaryDto
            {
                Id = a.Id,
                Name = a.Name,
                Biography = a.Biography,
                PhotoUrl = a.PhotoUrl,
            }).ToList();
        }

        public async Task<AuthorDto> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetById(id);
            if (author == null) return null;

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                Nationality = author.Nationality,
                PhotoUrl = author.PhotoUrl,
                BirthDate = author.BirthDate,
                DeathDate = author.DeathDate,
                IsDeleted = author.IsDeleted,
                CreatedDate = author.CreatedDate,
                UpdatedDate = author.UpdatedDate,
                Books = author.Books
            };
        }

        public async Task AddAuthor(AuthorDto authorDto)
        {
            var author = new Author
            {
                Name = authorDto.Name,
                Biography = authorDto.Biography,
                Nationality = authorDto.Nationality,
                PhotoUrl = authorDto.PhotoUrl,
                BirthDate = authorDto.BirthDate,
                DeathDate = authorDto.DeathDate,
                CreatedDate = DateTime.UtcNow,
                Books = authorDto.Books
            };
            await _authorRepository.Add(author);
        }

        public async Task UpdateAuthor(int id, AuthorDto authorDto)
        {
            var existingAuthor = await _authorRepository.GetById(id);
            if (existingAuthor != null)
            {
                existingAuthor.Name = authorDto.Name;
                existingAuthor.Biography = authorDto.Biography;
                existingAuthor.Nationality = authorDto.Nationality;
                existingAuthor.PhotoUrl = authorDto.PhotoUrl;
                existingAuthor.BirthDate = authorDto.BirthDate;
                existingAuthor.DeathDate = authorDto.DeathDate;
                existingAuthor.IsDeleted = authorDto.IsDeleted;
                existingAuthor.UpdatedDate = DateTime.UtcNow;
                existingAuthor.Books = authorDto.Books;
                await _authorRepository.Update(existingAuthor);
            }
        }

        public async Task DeleteAuthor(int id)
        {
            var author = await _authorRepository.GetById(id);
            if (author != null)
                await _authorRepository.Delete(author);
        }
    }
}