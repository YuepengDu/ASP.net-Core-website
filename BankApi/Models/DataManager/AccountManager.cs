using BankAPI.Data;
using BankAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAPI.Models.DataManager
{
    public class AccountManager : IDataRepository<Account, int>
    {
        private readonly BankContext _context;

        public AccountManager(BankContext context)
        {
            _context = context;
        }
        public int Add(Account account)
        {
            _context.Add(account);
            _context.SaveChanges();
            return account.AccountNumber;
        }

        public IEnumerable<Account> All()
        {
            return _context.Account.ToList();
        }

        public int Delete(int id)
        {
            _context.Account.Remove(_context.Account.Find(id));
            _context.SaveChanges();
            return id;
        }

        public Account Get(int id)
        {
            return _context.Account.Find(id);
        }

        public int Update(int id, Account account)
        {
            _context.Update(account);
            _context.SaveChanges();
            return id;
        }
    }
}
