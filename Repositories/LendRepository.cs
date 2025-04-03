using LibraryApi.Data;
using LibraryApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApi.Repositories
{
    public interface ILendRepository
    {
        Task<IEnumerable<Lend>> GetAll();
        Task<Lend> GetById(int id);
        Task Add(Lend lend);
        Task Update(Lend lend);
        Task Delete(Lend lend);
    }

    public class LendRepository : ILendRepository
    {
        private readonly LibraryContext _context;

        public LendRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Lend>> GetAll()
        {
            return await _context.Lends.ToListAsync();
        }

        public async Task<Lend> GetById(int id)
        {
            return await _context.Lends.FindAsync(id);
        }

        public async Task Add(Lend lend)
        {
            await _context.Lends.AddAsync(lend);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Lend lend)
        {
            _context.Lends.Update(lend);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Lend lend)
        {
            _context.Lends.Remove(lend);
            await _context.SaveChangesAsync();
        }
    }
}