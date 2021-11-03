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
    public class LoginController : ControllerBase
    {
        private readonly LoginManager _repo;

        public LoginController(LoginManager repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public void Post([FromBody] Login login)
        {
            _repo.Add(login);
        }

        [HttpGet]
        public IEnumerable<Login> Get()
        {
            return _repo.All();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        [HttpGet("{id}")]
        public Login Get(int id)
        {
            return _repo.Get(id);
        }

        [HttpPut]
        public void Put([FromBody] Login login)
        {
            _repo.Update(login.CustomerID, login);
        }
    }
}
