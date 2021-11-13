using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    class BasketManagerHttp
    {
        private readonly HttpClient _httpClient;

        string baselink = "https://localhost:44306/api/smartbasket/basket";
        public BasketManagerHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Product>> displayprod()
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/viewproducts");



            responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Product>>(responseBody);

        }
        public async Task<string> calculatetotal(int id)
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/calculatetotal?id={id}");



            responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(responseBody);

        }
        //public async Task<List<string>> displayhotsellingprod()
        //{
        //    string responseBody;



        //    HttpResponseMessage response = await _httpClient.GetAsync(
        //        $"{baselink}/hotsellingitems");



        //    responseBody = await response.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<List<string>>(responseBody);

        //}
        public async Task<string> shopforprod(int prodid, int count, int customerid)
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/addtobasket?prodid={prodid}&count={count}&customerid={customerid}");



            responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(responseBody);

        }
        public async Task<string>removeproduct(int prodid, int customerid)
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/removefrombasket?prodid={prodid}&customerid={customerid}");



            responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(responseBody);

        }
        public async Task<string> checkingout( int customerid)
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/checkout?customerid={customerid}");



            responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(responseBody);

        }
        public async Task<List<string>> displaypurchaseHist(int customerid)
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/viewpurchasehistory?customerid={customerid}");



            responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<string>>(responseBody);

        }


    }
}
