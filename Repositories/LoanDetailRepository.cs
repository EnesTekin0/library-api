using LibraryApi.Data;
using LibraryApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApi.Repositories
{
    public interface ILendDetailRepository
    {
        Task<IEnumerable<LendDetail>> GetAll();
        Task<LendDetail> GetById(int id);
        Task Add(LendDetail lendDetail);
        Task Update(LendDetail lendDetail);
        Task Delete(LendDetail lendDetail);
    }

    public class LendDetailRepository : ILendDetailRepository
    {
        private readonly LibraryContext _context;

        public LendDetailRepository(LibraryContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<LendDetail>> GetAll()
        {
            return await _context.LendDetails.ToListAsync();
        }

        public async Task<LendDetail> GetById(int id)
        {
            return await _context.LendDetails.FindAsync(id);
        }

        public async Task Add(LendDetail lendDetail)
        {
            await _context.LendDetails.AddAsync(lendDetail);
            await _context.SaveChangesAsync();
        }

        public async Task Update(LendDetail lendDetail)
        {
            _context.LendDetails.Update(lendDetail);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(LendDetail lendDetail)
        {
            _context.LendDetails.Remove(lendDetail);
            await _context.SaveChangesAsync();
        }
    }
}