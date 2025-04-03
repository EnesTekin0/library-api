using LibraryApi.Models.DTOs;
using LibraryApi.Models.Entities;
using LibraryApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public interface ILendService
    {
        Task<IEnumerable<LendDto>> GetAllLends();
        Task<LendDto> GetLendById(int id);
        Task AddLend(LendDto lendDto);
        Task UpdateLend(int id, LendDto lendDto);
        Task DeleteLend(int id);
    }

    public class LendService : ILendService
    {
        private readonly ILendRepository _lendRepository;

        public LendService(ILendRepository lendRepository)
        {
            _lendRepository = lendRepository;
        }
        public async Task<IEnumerable<LendDto>> GetAllLends()
        {
            var lends = await _lendRepository.GetAll();
            return lends.Select(l => new LendDto
            {
            Id = l.Id,
            CustomerId = l.CustomerId,
            PersonnelId = l.PersonnelId,
            LendDate = l.LendDate,
            ReturnDate = l.ReturnDate,
            IsReturned = l.IsReturned,
            IsDeleted = l.IsDeleted,
            CreatedDate = l.CreatedDate,
            }).ToList();
        }

        public async Task<LendDto> GetLendById(int id)
        {
            var lend = await _lendRepository.GetById(id);
            if (lend == null) return null;

            return new LendDto
            {
            Id = lend.Id,
            CustomerId = lend.CustomerId,
            PersonnelId = lend.PersonnelId,
            LendDate = lend.LendDate,
            ReturnDate = lend.ReturnDate,
            IsReturned = lend.IsReturned,
            IsDeleted = lend.IsDeleted,
            CreatedDate = lend.CreatedDate,
            };
        }

        public async Task AddLend(LendDto lendDto)
        {
            var lend = new Lend
            {
            CustomerId = lendDto.CustomerId,    
            PersonnelId = lendDto.PersonnelId,
            LendDate = lendDto.LendDate,
            ReturnDate = lendDto.ReturnDate,
            IsReturned = lendDto.IsReturned,
            CreatedDate = DateTime.UtcNow,
            };
            await _lendRepository.Add(lend);
        }

        public async Task UpdateLend(int id, LendDto lendDto)
        {
            var existingLend = await _lendRepository.GetById(id);
            if (existingLend != null)
            {
            existingLend.CustomerId = lendDto.CustomerId;
            existingLend.PersonnelId = lendDto.PersonnelId;
            existingLend.LendDate = lendDto.LendDate;
            existingLend.ReturnDate = lendDto.ReturnDate;
            existingLend.IsReturned = lendDto.IsReturned;
            existingLend.IsDeleted = lendDto.IsDeleted;
            existingLend.UpdatedDate = DateTime.UtcNow;
            await _lendRepository.Update(existingLend);
            }
        }

        public async Task DeleteLend(int id)
        {
            var lend = await _lendRepository.GetById(id);
            if (lend != null)
            {
            await _lendRepository.Delete(lend);
            }
        }
    }
}