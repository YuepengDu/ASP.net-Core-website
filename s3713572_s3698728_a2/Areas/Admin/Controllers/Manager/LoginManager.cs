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
    public class LoginManager
    {
        private HttpClient _client;
        //API implemention
        public LoginManager()
        {
            _client = BankApi.InitializeClient();
        }
        //Get all login accounts in database
        public async Task<Login> GetLogin(int? id)
        {
            if (id == null) return null;
            var result = await _client.GetAsync($"api/Login/{id}");
            if (!result.IsSuccessStatusCode) throw new Exception();
            var convertResult = result.Content.ReadAsStringAsync().Result;
            var login = JsonConvert.DeserializeObject<Login>(convertResult);
            return login;
        }
        //Lock the user for 1 minute
        public bool Lock(Login login, bool status)
        {
            login.Lock = status;
            if (status == true)
                login.LockDate = DateTime.Now;

            var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = _client.PutAsync("api/Login", content).Result;
            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
    }
}
