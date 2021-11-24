using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmartBasket
{
    class accountmanagerHttp
    {
        private readonly HttpClient _httpClient;

        string baselink = "http://webapi.local/api/smartbasket";
        public accountmanagerHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CustomerDTO> Login(int Id)
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/login?id={Id}");
           
               

                responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CustomerDTO>(responseBody);
           
        }
        public async Task<string> addcustomer(CustomerDTO c)
        {
            string responseBody;



            
            var json = JsonConvert.SerializeObject(c);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

            var client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync($"{baselink}/addingcustomer", stringContent);


            if (response.IsSuccessStatusCode)
            {


                responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<string>(responseBody);
            }
            else
            {
                responseBody = await response.Content.ReadAsStringAsync();
                throw new Exception(responseBody);
            }

        }

    }
}
