using LibraryApi.Data;
using LibraryApi.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAll();
        Task<Stock> GetById(int id);
        Task Add(Stock stock);
        Task Update(Stock stock);
        Task Delete(Stock stock);
    }

    public class StockRepository : IStockRepository
    {
        private readonly LibraryContext _context;

        public StockRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAll()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock> GetById(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task Add(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Stock stock)
        {
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Stock stock)
        {
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
        }
    }
}