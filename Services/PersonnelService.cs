using LibraryApi.Models.DTOs;
using LibraryApi.Models.Entities;
using LibraryApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public interface IPersonnelService
    {
        Task<IEnumerable<PersonnelDto>> GetAllPersonnel();
        Task<PersonnelDto> GetPersonnelById(int id);
        Task AddPersonnel(PersonnelDto personnelDto);
        Task UpdatePersonnel(int id, PersonnelDto personnelDto);
        Task DeletePersonnel(int id);
    }

    public class PersonnelService : IPersonnelService
    {
        private readonly IPersonnelRepository _personnelRepository;

        public PersonnelService(IPersonnelRepository personnelRepository)
        {
            _personnelRepository = personnelRepository;
        }

        public async Task<IEnumerable<PersonnelDto>> GetAllPersonnel()
        {
            var personnelList = await _personnelRepository.GetAll();
            return personnelList.Select(p => new PersonnelDto
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email,
                Role = p.Role,
                IsDeleted = p.IsDeleted,
                CreatedDate = p.CreatedDate,
                UpdatedDate = p.UpdatedDate
            }).ToList();
        }

        public async Task<PersonnelDto> GetPersonnelById(int id)
        {
            var personnel = await _personnelRepository.GetById(id);
            if (personnel == null) return null;

            return new PersonnelDto
            {
                Id = personnel.Id,
                Name = personnel.Name,
                Email = personnel.Email,
                Role = personnel.Role,
                IsDeleted = personnel.IsDeleted,
                CreatedDate = personnel.CreatedDate,
                UpdatedDate = personnel.UpdatedDate
            };
        }

        public async Task AddPersonnel(PersonnelDto personnelDto)
        {
            var personnel = new Personnel
            {
                Name = personnelDto.Name,
                Email = personnelDto.Email,
                Role = personnelDto.Role,
                CreatedDate = DateTime.UtcNow,
            };
            await _personnelRepository.Add(personnel);
        }

        public async Task UpdatePersonnel(int id, PersonnelDto personnelDto)
        {
            var existingPersonnel = await _personnelRepository.GetById(id);
            if (existingPersonnel != null)
            {
                existingPersonnel.Name = personnelDto.Name;
                existingPersonnel.Email = personnelDto.Email;
                existingPersonnel.Role = personnelDto.Role;
                existingPersonnel.IsDeleted = personnelDto.IsDeleted;
                existingPersonnel.UpdatedDate = DateTime.UtcNow;
                await _personnelRepository.Update(existingPersonnel);
            }
        }

        public async Task DeletePersonnel(int id)
        {
            var personnel = await _personnelRepository.GetById(id);
            if (personnel != null)
            {
                await _personnelRepository.Delete(personnel);
            }
        }
    }
}