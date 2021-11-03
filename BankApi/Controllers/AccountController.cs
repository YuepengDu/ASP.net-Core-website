using BankAPI.Models;
using BankAPI.Models.DataManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountManager _repo;

        public AccountController(AccountManager repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public void Post([FromBody] Account account)
        {
            _repo.Add(account);
        }

        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return _repo.All();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return _repo.Get(id);
        }

        [HttpPut]
        public void Put([FromBody] Account account)
        {
            _repo.Update(account.CustomerID, account);
        }
    }
}
