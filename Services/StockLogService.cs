using LibraryApi.Models.DTOs;
using LibraryApi.Models.Entities;
using LibraryApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public interface IStockLogService
    {
        Task<IEnumerable<StockLogDto>> GetAllStockLogs();
        Task<StockLogDto> GetStockLogById(int id);
        Task AddStockLog(StockLogDto stockLogDto);
        Task UpdateStockLog(int id, StockLogDto stockLogDto);
        Task DeleteStockLog(int id);
    }

    public class StockLogService : IStockLogService
    {
        private readonly IStockLogRepository _stockLogRepository;

        public StockLogService(IStockLogRepository stockLogRepository)
        {
            _stockLogRepository = stockLogRepository;
        }

        public async Task<IEnumerable<StockLogDto>> GetAllStockLogs()
        {
            var stockLogs = await _stockLogRepository.GetAll();
            return stockLogs.Select(s => new StockLogDto
            {
                Id = s.Id,
                StockId = s.StockId,
                PersonnelId = s.PersonnelId,
                ChangeAmount = s.ChangeAmount,
                Date = s.Date,
                Action = s.Action
            }).ToList();
        }

        public async Task<StockLogDto> GetStockLogById(int id)
        {
            var stockLog = await _stockLogRepository.GetById(id);
            if (stockLog == null) return null;

            return new StockLogDto
            {
                Id = stockLog.Id,
                StockId = stockLog.StockId,
                PersonnelId = stockLog.PersonnelId,
                ChangeAmount = stockLog.ChangeAmount,
                Date = stockLog.Date,
                Action = stockLog.Action
            };
        }

        public async Task AddStockLog(StockLogDto stockLogDto)
        {
            var stockLog = new StockLog
            {
                StockId = stockLogDto.StockId,
                PersonnelId = stockLogDto.PersonnelId,
                ChangeAmount = stockLogDto.ChangeAmount,
                Date = stockLogDto.Date,
                Action = stockLogDto.Action
            };
            await _stockLogRepository.Add(stockLog);
        }

        public async Task UpdateStockLog(int id, StockLogDto stockLogDto)
        {
            var existingStockLog = await _stockLogRepository.GetById(id);
            if (existingStockLog != null)
            {
                existingStockLog.StockId = stockLogDto.StockId;
                existingStockLog.PersonnelId = stockLogDto.PersonnelId;
                existingStockLog.ChangeAmount = stockLogDto.ChangeAmount;
                existingStockLog.Date = stockLogDto.Date;
                existingStockLog.Action = stockLogDto.Action;
                await _stockLogRepository.Update(existingStockLog);
            }
        }

        public async Task DeleteStockLog(int id)
        {
            var stockLog = await _stockLogRepository.GetById(id);
            if (stockLog != null)
            {
                await _stockLogRepository.Delete(stockLog);
            }
        }
    }
}