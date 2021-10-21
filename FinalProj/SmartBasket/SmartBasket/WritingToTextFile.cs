using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    public class WritingToTextFile
    {
        public string writingToCustomerTxt(Dictionary<string,Customer> custDict)
        {
            FileStream fs1 = new FileStream($"customerdict.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);

            foreach (var d in custDict)
            {
                sw.WriteLine($"{d.Value.customerID},{d.Value.customerName},{d.Value.customerEmail},{d.Value.customerPhoneNo},{d.Value.role}");
            }

            sw.Close();
            fs1.Close();
            return "Completed writing to customerdict.txt";
        }
        public string writingToInventoryTxt(Dictionary<string,Product> prodDict)
        {
            FileStream fs2 = new FileStream($"inventory.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw2 = new StreamWriter(fs2);

            foreach (var d in prodDict)
            {
                sw2.WriteLine($"{d.Value.productID},{d.Value.productName},{d.Value.productCount},{d.Value.productPrice},{d.Value.productCategory}");
            }

            sw2.Close();
            fs2.Close();
            return "Completed writing to inventory.txt";
        }
        public string writingToSmartBasketTxt(Dictionary<string, Customer> custDict)
        {
            //File.Delete(@"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\FinalProj\SmartBasket\SmartBasket\bin\Debug\SmartBasket.txt");
            FileStream fs3 = new FileStream($"SmartBasket.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw3 = new StreamWriter(fs3);
            
            //if (!tempbask.isCheckedOut)
            //{
            //    foreach (var d in tempbask.Itembasket)
            //    
            //        sw3.WriteLine($"{idinput},{false},{d.productID},{d.productName},{d.productCount},{d.productPrice},{d.productCategory}");
            //    }
            //}

            foreach (var dic in custDict)
            {
                if (dic.Value.bas.Itembasket.Count > 0)
                {
                    if (!dic.Value.bas.isCheckedOut)
                    {
                        foreach (var prod in dic.Value.bas.Itembasket)
                        {
                            sw3.WriteLine($"{dic.Key},{false},{prod.productID},{prod.productName},{prod.productCount},{prod.productPrice},{prod.productCategory}");
                        }
                    }
                }
            }
            if(fs3.Length==0)
            {
                sw3.WriteLine(" ");
            }
            sw3.Close();
            fs3.Close();
            return "completed writing to smartbasket.txt";
        }
        public string WritingToPurchaseHistory(Dictionary<string,Customer> custDict)
        {
            FileStream fs4 = new FileStream($"purchasehistory.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw4 = new StreamWriter(fs4);
            //if (tempbask.isCheckedOut)
            //{
            //    if (custDict[idinput].PurchaseHistory.Count > 0)
            //    {
            //        foreach (Basket d in custDict[idinput].PurchaseHistory)
            //        {
            //            foreach (Product p in d.Itembasket)
            //            {
            //                sw4.WriteLine($"{idinput},{p.productID},{p.productName},{p.productCategory},{p.productCount},{p.productPrice}");
            //            }
            //        }
            //    }
            //}
            foreach (var dic in custDict)
            {
                if (dic.Value.PurchaseHistory.Count > 0)
                {


                    foreach (var prod in dic.Value.PurchaseHistory)
                    {
                        sw4.WriteLine($"{dic.Key},{prod.productID},{prod.productName},{prod.productCount},{prod.productPrice},{prod.productCategory},{prod.dtadded}");
                    }



                }
            }
            sw4.Close();
            fs4.Close();
            return "completed writing to purchasehistory.txt";
        }
    }
}
