using BankAPI.Data;
using BankAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.DataManager
{
    public class TransactionManager : IDataRepository<Transaction, int>
    {
        private readonly BankContext _context;
        public TransactionManager(BankContext context)
        {
            _context = context;
        }
        public int Add(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            return transaction.AccountNumber;
        }

        public IEnumerable<Transaction> All()
        {
            return _context.Transaction.ToList();
        }

        public int Delete(int id)
        {
            _context.Transaction.Remove(_context.Transaction.Find(id));
            _context.SaveChanges();
            return id;
        }

        public Transaction Get(int id)
        {
            return _context.Transaction.Find(id);
        }

        public int Update(int id, Transaction transaction)
        {
            _context.Transaction.Update(transaction);
            _context.SaveChanges();
            return id;
        }
    }
}
