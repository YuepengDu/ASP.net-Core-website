using s3713572_s3698728_a2.UserCategory.Admin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace s3713572_s3698728_a2.UserCategory.Admin.Controllers.Manager
{
    public class TransactionManager
    {
        private HttpClient _client;
        //API implemention
        public TransactionManager()
        {
            _client = BankApi.InitializeClient();
        }
        //Get transactions
        public async Task<IEnumerable<Transaction>> GetAllTransaction(int? id)
        {
            var result = await _client.GetAsync("api/Transaction");
            if (!result.IsSuccessStatusCode) throw new Exception();

            var ConvertResult = result.Content.ReadAsStringAsync().Result;
            IEnumerable<Transaction> transactions = JsonConvert.DeserializeObject<List<Transaction>>(ConvertResult).Where(x=>x.AccountNumber==id);
            return transactions;
        }
        //Get transactions of one customer
        public async Task<IEnumerable<Transaction>> GetTransaction(int? id)
        {
            var result = await _client.GetAsync($"api/Transaction");
            if (!result.IsSuccessStatusCode) throw new Exception();

            var ConvertResult = result.Content.ReadAsStringAsync().Result;
            Account account = JsonConvert.DeserializeObject<Account>(ConvertResult);
            IEnumerable<Transaction> transactions = account.Transactions.OrderBy(x => x.ModifyDate);

            return transactions;
        }
        //Get transactions. Filter out the specified time period by passing in the start time and end time
        public async Task<IEnumerable<Transaction>> FilterByDateAsync(int? id, DateTime startdate, DateTime enddate)
        {
            IEnumerable<Transaction> transactions = await GetAllTransaction(id);

            if (startdate == DateTime.MinValue || enddate == DateTime.MinValue)
            {
                return transactions;
            }
            else
            {
                transactions = (from x in await GetAllTransaction(id) where (x.ModifyDate <= enddate) && (x.ModifyDate >= startdate) select x).ToList();
                return transactions;
            }  
        }


    }
}
