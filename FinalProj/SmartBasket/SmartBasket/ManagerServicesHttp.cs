using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    class ManagerServicesHttp
    {
        private readonly HttpClient _httpClient;

        string baselink = "http://webapi.local/api/smartbasket/Manager";
        //string baselink = "https://localhost:44306/api/smartbasket/Manager";
        public ManagerServicesHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> addprod(Product p)
        {
            string responseBody;


            

            var json = JsonConvert.SerializeObject(p);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

            var client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync($"{baselink}/addingproduct", stringContent);


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
        public async Task<List< string>> salesreport()
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/salesreport");

            if (response.IsSuccessStatusCode)
            {


                responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<string>>(responseBody);
            }
            else
            {
                responseBody = await response.Content.ReadAsStringAsync();
                throw new Exception(responseBody);
            }



        }
        public async Task<string> removeprod(int prodid)
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.PostAsync(
                $"{baselink}/removeproduct?p={prodid}", new StringContent(prodid.ToString(), Encoding.UTF8, "application/json"));



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
        public async Task<List<Customer>> retrievecustomer()
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/viewallaccounts");

            if (response.IsSuccessStatusCode)
            {


                responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Customer>>(responseBody);
            }
            else
            {
                responseBody = await response.Content.ReadAsStringAsync();
                throw new Exception(responseBody);
            }



        }
    }
}
