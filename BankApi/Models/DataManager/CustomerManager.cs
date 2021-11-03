using BankAPI.Data;
using BankAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.DataManager
{
    public class CustomerManager : IDataRepository<Customer, int>
    {
        private readonly BankContext _context;
        public CustomerManager(BankContext context)
        {
            _context = context;
        }
        public int Add(Customer customer)
        {
            _context.Customer.Add(customer);
            return customer.CustomerID;
        }

        public IEnumerable<Customer> All()
        {
            return _context.Customer.ToList();
        }

        public int Delete(int id)
        {
            _context.Customer.Remove(_context.Customer.Find(id));
            _context.SaveChanges();
            return id;
        }

        public Customer Get(int id)
        {
            return _context.Customer.Find(id);
        }

        public int Update(int id, Customer customer)
        {
            _context.Customer.Update(customer);
            _context.SaveChanges();
            return id;
        }
    }
}
