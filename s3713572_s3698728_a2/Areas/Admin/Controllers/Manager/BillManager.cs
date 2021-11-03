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
    public class BillManager
    {
        private HttpClient _client;
        //API implemention
        public BillManager()
        {
            _client = BankApi.InitializeClient();
        }
        //Get bills
        public async Task<IEnumerable<BillPay>> GetAllBills(int? id)
        {
            var result = await _client.GetAsync("api/BillPay");
            if (!result.IsSuccessStatusCode) throw new Exception();

            var ConvertResult = result.Content.ReadAsStringAsync().Result;
            IEnumerable<BillPay> bills = JsonConvert.DeserializeObject<List<BillPay>>(ConvertResult).Where(x=>x.AccountNumber == id);
            return bills;
        }
        //Get bills with a certain ID
        public async Task<BillPay> GetBillPay(int? BillPayId)
        {
            if (BillPayId == null) return null;
            var result = await _client.GetAsync($"api/BillPay/{BillPayId}");
            if (!result.IsSuccessStatusCode) throw new Exception();

            var ConvertResult = result.Content.ReadAsStringAsync().Result;
            var bill = JsonConvert.DeserializeObject<BillPay>(ConvertResult);

            return bill;
        }
        //Block bills
        public bool Block(BillPay bill,bool status)
        {
            bill.Block = status;
            bill.ModifyDate = DateTime.Now;

            var content = new StringContent(JsonConvert.SerializeObject(bill), Encoding.UTF8, "application/json");
            var result = _client.PutAsync("api/BillPay", content).Result;
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
        //Unblock bills
        public bool UnBlock(BillPay bill, bool status)
        {
            bill.Block = status;
            bill.ModifyDate = DateTime.Now;

            var content = new StringContent(JsonConvert.SerializeObject(bill), Encoding.UTF8, "application/json");
            var result = _client.PutAsync("api/Billpay", content).Result;
            if (!result.IsSuccessStatusCode) return true;
            return false;

        }
    }
}
