using LibraryApi.Models.DTOs;
using LibraryApi.Models.Entities;
using LibraryApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategories();
        Task<CategoryDto> GetCategoryById(int id);
        Task AddCategory(CategoryDto categoryDto);
        Task UpdateCategory(int id, CategoryDto categoryDto);
        Task DeleteCategory(int id);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAll();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name 
            }).ToList();
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null) return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                BookId = category.Books.Select(b => b.Id).ToList(),
            };
        }

        public async Task AddCategory(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                CreatedDate = DateTime.UtcNow,
            };
            await _categoryRepository.Add(category);
        }

        public async Task UpdateCategory(int id, CategoryDto categoryDto)
        {
            var existingCategory = await _categoryRepository.GetById(id);
            if (existingCategory != null)
            {
                existingCategory.Name = categoryDto.Name;
                existingCategory.IsDeleted = categoryDto.IsDeleted;
                existingCategory.UpdatedDate = DateTime.UtcNow;
                await _categoryRepository.Update(existingCategory);
            }
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category != null)
            {
                await _categoryRepository.Delete(category);
            }
        }
    }
}