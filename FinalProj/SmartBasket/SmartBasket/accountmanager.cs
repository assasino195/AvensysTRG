using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmartBasket
{
    class accountmanager
    {
        private readonly HttpClient _httpClient;

        string baselink = "https://localhost:44306/api/smartbasket";
        public accountmanager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Customer> Login(string Id)
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/login");
           
               

                responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(responseBody);
           
        }
    }
}
