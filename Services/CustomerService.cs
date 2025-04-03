using LibraryApi.Models.DTOs;
using LibraryApi.Models.Entities;
using LibraryApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomers();
        Task<CustomerDto> GetCustomerById(int id);
        Task AddCustomer(CustomerDto customerDto);
        Task UpdateCustomer(int id, CustomerDto customerDto);
        Task DeleteCustomer(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAll();
            return customers.Select(c => new CustomerDto
            {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            CreatedDate = c.CreatedDate
            }).ToList();
        }

        public async Task<CustomerDto> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetById(id);
            if (customer == null) return null;

            return new CustomerDto
            {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            CreatedDate = customer.CreatedDate
            };
        }

        public async Task AddCustomer(CustomerDto customerDto)
        {
            var customer = new Customer
            {
            Name = customerDto.Name,
            Email = customerDto.Email,
            CreatedDate = DateTime.UtcNow,
            };
            await _customerRepository.Add(customer);
        }

        public async Task UpdateCustomer(int id, CustomerDto customerDto)
        {
            var existingCustomer = await _customerRepository.GetById(id);
            if (existingCustomer != null)
            {
            existingCustomer.Name = customerDto.Name;
            existingCustomer.Email = customerDto.Email;
            existingCustomer.IsDeleted = customerDto.IsDeleted;
            existingCustomer.UpdatedDate = DateTime.UtcNow;
            await _customerRepository.Update(existingCustomer);
            }
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _customerRepository.GetById(id);
            if (customer != null)
            await _customerRepository.Delete(customer);
        }
    }
}