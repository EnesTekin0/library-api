using LibraryApi.Data;
using LibraryApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Repositories
{
        public interface ICustomerRepository
        {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task Add(Customer customer);
        Task Update(Customer customer);
        Task Delete(Customer customer);
        }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LibraryContext _context;

        public CustomerRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}