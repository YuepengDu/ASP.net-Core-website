using s3713572_s3698728_a2.UserCategory.Admin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace s3713572_s3698728_a2.UserCategory.Admin.Controllers.Manager
{
    public class CustomerManager
    {
        private HttpClient _client;
        //API implemention
        public CustomerManager()
        {
            _client = BankApi.InitializeClient();
        }
        //Get Customers
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var result = await _client.GetAsync("api/Customer");
            if (!result.IsSuccessStatusCode) throw new Exception();
            var ConvertResult = result.Content.ReadAsStringAsync().Result;
            IEnumerable<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(ConvertResult);
            return customers;
        }
        //Get certain customer
        public async Task<Customer> GetCustomer(int? id)
        {
            if (id == null)
                return null;

            var result = await _client.GetAsync($"api/Customer/{id}");

            if (!result.IsSuccessStatusCode)
                throw new Exception();// No customer found

            var ConvertResult = result.Content.ReadAsStringAsync().Result;
            var customer = JsonConvert.DeserializeObject<Customer>(ConvertResult);
            return customer;
        }
            
    }
}
