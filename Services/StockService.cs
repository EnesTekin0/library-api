using LibraryApi.Models.DTOs;
using LibraryApi.Models.Entities;
using LibraryApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public interface IStockService
    {
        Task<IEnumerable<StockDto>> GetAllStock();
        Task<StockDto> GetStockById(int id);
        Task AddStock(StockDto stockDto);
        Task UpdateStock(int id, StockDto stockDto);
        Task DeleteStock(int id);
    }

    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<StockDto>> GetAllStock()
        {
            var stocks = await _stockRepository.GetAll();
            return stocks.Select(s => new StockDto
            {
                Id = s.Id,
                BookId = s.BookId,
                Quantity = s.Quantity,
                LastUpdated = s.LastUpdated,
                IsDeleted = s.IsDeleted,
            }).ToList();
        }

        public async Task<StockDto> GetStockById(int id)
        {
            var stock = await _stockRepository.GetById(id);
            if (stock == null) return null;

            return new StockDto
            {
                Id = stock.Id,
                BookId = stock.BookId,
                Quantity = stock.Quantity,
                LastUpdated = stock.LastUpdated,
                IsDeleted = stock.IsDeleted,
            };
        }

        public async Task AddStock(StockDto stockDto)
        {
            var stock = new Stock
            {
                BookId = stockDto.BookId,
                Quantity = stockDto.Quantity,
                LastUpdated = stockDto.LastUpdated
            };
            await _stockRepository.Add(stock);
        }

        public async Task UpdateStock(int id, StockDto stockDto)
        {
            var existingStock = await _stockRepository.GetById(id);
            if (existingStock != null)
            {
                existingStock.BookId = stockDto.BookId;
                existingStock.Quantity = stockDto.Quantity;
                existingStock.LastUpdated = stockDto.LastUpdated;
                existingStock.IsDeleted = stockDto.IsDeleted;
                await _stockRepository.Update(existingStock);
            }
        }

        public async Task DeleteStock(int id)
        {
            var stock = await _stockRepository.GetById(id);
            if (stock != null)
                await _stockRepository.Delete(stock);
        }
    }
}