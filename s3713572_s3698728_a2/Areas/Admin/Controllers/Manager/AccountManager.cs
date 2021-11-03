using s3713572_s3698728_a2.UserCategory.Admin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace s3713572_s3698728_a2.UserCategory.Admin.Controllers.Manager
{
    public class AccountManager
    {
        private HttpClient _client;
        //API implemention
        public AccountManager()
        {
            _client = BankApi.InitializeClient();
        }
        //Get accounts
        public async Task<IEnumerable<Account>> GetAllAccounts(int? id)
        {
            var result = await _client.GetAsync("api/Account");
            if (!result.IsSuccessStatusCode) throw new Exception();

            var ConvertResult = result.Content.ReadAsStringAsync().Result;
            IEnumerable<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(ConvertResult).Where(x=>x.CustomerID == id);
            return accounts;
        }
        //Get account of a certain customer
        public async Task<Account> GetAccount(int? id)
        {
            if (id == null) return null;
            var result = await _client.GetAsync($"api/Account/{id}");
            if (!result.IsSuccessStatusCode) throw new Exception();

            var ConvertResult = result.Content.ReadAsStringAsync().Result;
            var account = JsonConvert.DeserializeObject<Account>(ConvertResult);
            
            return account;
        }
    }
}
