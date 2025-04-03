using LibraryApi.Models.DTOs;
using LibraryApi.Models.Entities;
using LibraryApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public interface ILendDetailService
    {
        Task<IEnumerable<LendDetailDto>> GetAllLendDetails();
        Task<LendDetailDto> GetLendDetailById(int id);
        Task AddLendDetail(LendDetailDto lendDetailDto);
        Task UpdateLendDetail(int id, LendDetailDto lendDetailDto);
        Task DeleteLendDetail(int id);
    }

    public class LendDetailService : ILendDetailService
    {
        private readonly ILendDetailRepository _lendDetailRepository;

        public LendDetailService(ILendDetailRepository lendDetailRepository)
        {
            _lendDetailRepository = lendDetailRepository;
        }

        public async Task<IEnumerable<LendDetailDto>> GetAllLendDetails()
        {
            var lendDetails = await _lendDetailRepository.GetAll();
            return  lendDetails.Select(ld => new LendDetailDto
            {
                Id = ld.Id,
                LendId = ld.LendId,
                BookId = ld.BookId,
                ReturnDate = ld.ReturnDate,
                IsLost = ld.IsLost,
                IsDeleted = ld.IsDeleted,
            }).ToList();
        }

        public async Task<LendDetailDto> GetLendDetailById(int id)
        {
            var lendDetail = await _lendDetailRepository.GetById(id);
            if (lendDetail == null) return null;

            return new LendDetailDto
            {
            Id = lendDetail.Id,
            LendId = lendDetail.LendId,
            BookId = lendDetail.BookId,
            ReturnDate = lendDetail.ReturnDate,
            IsLost = lendDetail.IsLost,
            IsDeleted = lendDetail.IsDeleted,
            };
        }

        public async Task AddLendDetail(LendDetailDto lendDetailDto)
        {
            var lendDetail = new LendDetail
            {
            LendId = lendDetailDto.LendId,
            BookId = lendDetailDto.BookId,
            ReturnDate = lendDetailDto.ReturnDate,
            IsLost = lendDetailDto.IsLost,
            };
            await _lendDetailRepository.Add(lendDetail);
        }

        public async Task UpdateLendDetail(int id, LendDetailDto lendDetailDto)
        {
            var existingLendDetail = await _lendDetailRepository.GetById(id);
            if (existingLendDetail != null)
            {
            existingLendDetail.LendId = lendDetailDto.LendId;
            existingLendDetail.BookId = lendDetailDto.BookId;
            existingLendDetail.ReturnDate = lendDetailDto.ReturnDate;
            existingLendDetail.IsLost = lendDetailDto.IsLost;
            existingLendDetail.IsDeleted = lendDetailDto.IsDeleted;
            await _lendDetailRepository.Update(existingLendDetail);
            }
        }

        public async Task DeleteLendDetail(int id)
        {
            var lendDetail = await _lendDetailRepository.GetById(id);
            if (lendDetail != null)
            {
            await _lendDetailRepository.Delete(lendDetail);
            }
        }
    }
}