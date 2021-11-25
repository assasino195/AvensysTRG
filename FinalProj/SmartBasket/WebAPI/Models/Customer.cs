using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models;

namespace WebAPI
{
    public class Customer
    {
        public string customerName { get; set; }
        [Key]
        public int customerID { get; set; }
        public string role { get; set; }
        public string customerEmail { get; set; }
        public string customerPhoneNo { get; set; }
        public bool isCheckedOut { get; set; }
       
        public virtual ICollection<psuedoproduct> psueoproducts { get; set; }
        public Customer()
        {

        }
        public Customer(CustomerDTO c)
        {
            customerEmail = c.customerEmail;
            customerID = c.customerID;
            customerName = c.customerName;
            role = c.role;
            customerPhoneNo = c.customerPhoneNo;
            isCheckedOut = c.isCheckedOut;
            psueoproducts = c.psueoproducts;
        }
       
    }
}
