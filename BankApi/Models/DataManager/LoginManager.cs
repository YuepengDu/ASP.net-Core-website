using BankAPI.Data;
using BankAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.DataManager
{
    public class LoginManager : IDataRepository<Login, int>
    {
        private readonly BankContext _context;
        public LoginManager(BankContext context)
        {
            _context = context;
        }
        public int Add(Login login)
        {
            _context.Login.Add(login);
            _context.SaveChanges();
            return login.CustomerID;
        }

        public IEnumerable<Login> All()
        {
            return _context.Login.ToList();
        }

        public int Delete(int id)
        {
            _context.Login.Remove(_context.Login.Find(id));
            return id;
        }

        public Login Get(int id)
        {
            return _context.Login.Where(x => x.CustomerID == id).FirstOrDefault();
        }

        public int Update(int id, Login entity)
        {
            _context.Update(entity);
            _context.SaveChanges();

            return id;
        }
    }
}
