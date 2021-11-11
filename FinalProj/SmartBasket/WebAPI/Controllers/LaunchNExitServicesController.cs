using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/smartbasket")]
    public class LaunchNExitServicesController : ApiController
    {
        //public Dictionary<string, Product> prodDict = new Dictionary<string, Product>();
        // GET: LaunchNExitServices
        //public Models.DictionaryContext DictionaryCont = new Models.DictionaryContext();
        //[HttpGet]
        //[Route("")]
        //public IHttpActionResult retrieveInventory()
        //{
        //    //product dictionary retrieval
        //    Dictionary<string, Product> prodDict = new Dictionary<string, Product>();
        //    prodDict = JsonConvert.DeserializeObject<Dictionary<string, Product>>(File.ReadAllText("inventory.json"));
        //    DictionaryCont.prodDict = prodDict;

        //    //Customer dictionary retrival
        //    Dictionary<string, Customer> cusDict = new Dictionary<string, Customer>();

        //    cusDict = JsonConvert.DeserializeObject<Dictionary<string, Customer>>(File.ReadAllText("customerdict.json"));
        //    DictionaryCont.cusDict = cusDict;

        //    //retriving category names for category Dictionary
        //    Dictionary<string, string> catdict = new Dictionary<string, string>();
           
        //    foreach (var prod in prodDict)
        //    {
        //        if (!catdict.ContainsKey(prod.Value.productCategory))
        //        {
        //            catdict.Add(prod.Value.productCategory, prod.Value.productCategory);
        //        }
        //    }
        //    DictionaryCont.catDict = catdict;
        //    return Ok("Retrieved all Dictionary info");

        //}
        //[HttpGet]
        //[Route("exit")]
        //public string writingToJson()
        //{
        //    //    FileStream fs1 = new FileStream($"customerdict.txt", FileMode.OpenOrCreate, FileAccess.Write);
        //    //    StreamWriter sw = new StreamWriter(fs1);

        //    //    foreach (var d in custDict)
        //    //    {
        //    //        sw.WriteLine($"{d.Value.customerID},{d.Value.customerName},{d.Value.customerEmail},{d.Value.customerPhoneNo},{d.Value.role}");
        //    //    }

        //    //    sw.Close();
        //    //    fs1.Close();

        //    string customerdict = JsonConvert.SerializeObject(DictionaryCont.cusDict);
        //    File.WriteAllText("customerdict.json", customerdict);
        //    string Productdic = JsonConvert.SerializeObject(DictionaryCont.prodDict);
        //    File.WriteAllText("inventory.json", Productdic);
        //    return "Completed writing to customerdict.txt";
        //}
       



    }
}