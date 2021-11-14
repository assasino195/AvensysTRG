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

        string baselink = "http://webapi.local/api/smartbasket/basket";
        public BasketManagerHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Product>> displayprod()
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/viewproducts");

            if (response.IsSuccessStatusCode)
            {


                responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Product>>(responseBody);
            }
            else
            {
                responseBody = await response.Content.ReadAsStringAsync();
                throw new Exception(responseBody);
            }

          
            

        }
        public async Task<List< string>> calculatetotal(int id)
        {
            string responseBody;


           
            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/calculatetotal?customerid={id}");


            if (response.IsSuccessStatusCode)
            {


                responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject< List<string>> (responseBody);
            }
            else
            {
                responseBody = await response.Content.ReadAsStringAsync();
                throw new Exception(responseBody);
            }

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

        public async Task<string>removeproduct(int prodid, int customerid)
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/removefrombasket?prodid={prodid}&customerid={customerid}");



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

        public async Task<List<string>> viewbasket( int customerid)
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/viewbasket?customerid={customerid}");


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

        public async Task<string> checkingout( int customerid)
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.PostAsync(
                $"{baselink}/checkout?customerid={customerid}",new StringContent(customerid.ToString(), Encoding.UTF8, "application/json"));



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
        public async Task<List<string>> displaypurchaseHist(int customerid)
        {
            string responseBody;



            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{baselink}/viewpurchasehistory?customerid={customerid}");


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

        


    }
}
