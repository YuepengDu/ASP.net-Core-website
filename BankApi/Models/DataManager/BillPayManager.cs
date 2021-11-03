using BankAPI.Data;
using BankAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.DataManager
{
    public class BillPayManager : IDataRepository<BillPay, int>
    {
        private readonly BankContext _context;
        public BillPayManager(BankContext context)
        {
            _context = context;
        }
        public int Add(BillPay billPay)
        {
            _context.BillPay.Add(billPay);
            _context.SaveChanges();
            return billPay.AccountNumber;
        }

        public IEnumerable<BillPay> All()
        {
            return _context.BillPay.ToList();
        }

        public int Delete(int id)
        {
            _context.BillPay.Remove(_context.BillPay.Find(id));
            return id;
        }

        public BillPay Get(int id)
        {
            return _context.BillPay.Find(id);
        }

        public int Update(int id, BillPay billPay)
        {
            _context.Update(billPay);
            _context.SaveChanges();
            return id;
        }
    }
}
