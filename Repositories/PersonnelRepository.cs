using LibraryApi.Data;
using LibraryApi.Models.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryApi.Repositories
{
    public interface IPersonnelRepository
    {
        Task<IEnumerable<Personnel>> GetAll();
        Task<Personnel> GetById(int id);
        Task Add(Personnel personnel);
        Task Update(Personnel personnel);
        Task Delete(Personnel personnel);
    }

    public class PersonnelRepository : IPersonnelRepository
    {
        private readonly LibraryContext _context;

        public PersonnelRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Personnel>> GetAll()
        {
            return await _context.Personnel.ToListAsync();
        }

        public async Task<Personnel> GetById(int id)
        {
            return await _context.Personnel.FindAsync(id);
        }

        public async Task Add(Personnel personnel)
        {
            await _context.Personnel.AddAsync(personnel);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Personnel personnel)
        {
            _context.Personnel.Update(personnel);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Personnel personnel)
        {
            _context.Personnel.Remove(personnel);
            await _context.SaveChangesAsync();
        }
    }
}