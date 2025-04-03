using LibraryApi.Data;
using LibraryApi.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repositories
{
    public interface IStockLogRepository
    {
        Task<IEnumerable<StockLog>> GetAll();
        Task<StockLog> GetById(int id);
        Task Add(StockLog stockLog);
        Task Update(StockLog stockLog);
        Task Delete(StockLog stockLog);
    }

    public class StockLogRepository : IStockLogRepository
    {
        private readonly LibraryContext _context;

        public StockLogRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StockLog>> GetAll()
        {
            return await _context.StockLogs.ToListAsync();
        }

        public async Task<StockLog> GetById(int id)
        {
            return await _context.StockLogs.FindAsync(id);
        }

        public async Task Add(StockLog stockLog)
        {
            await _context.StockLogs.AddAsync(stockLog);
            await _context.SaveChangesAsync();
        }

        public async Task Update(StockLog stockLog)
        {
            _context.StockLogs.Update(stockLog);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(StockLog stockLog)
        {
            _context.StockLogs.Remove(stockLog);
            await _context.SaveChangesAsync();
        }
    }
}