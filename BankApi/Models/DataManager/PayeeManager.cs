using BankAPI.Data;
using BankAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.DataManager
{
    public class PayeeManager : IDataRepository<Payee, int>
    {
        private readonly BankContext _context;
        public PayeeManager(BankContext context)
        {
            _context = context;
        }
        public int Add(Payee payee)
        {
            _context.Payee.Add(payee);
            _context.SaveChanges();
            return payee.PayeeID;
        }

        public IEnumerable<Payee> All()
        {
            return _context.Payee.ToList();
        }

        public int Delete(int id)
        {
            _context.Payee.Remove(_context.Payee.Find(id));
            return id;
        }

        public Payee Get(int id)
        {
            return _context.Payee.Find(id);
        }

        public int Update(int id, Payee payee)
        {
            _context.Payee.Update(payee);
            _context.SaveChanges();
            return id;
        }
    }
}
