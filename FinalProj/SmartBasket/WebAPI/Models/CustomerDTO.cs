using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models;

namespace WebAPI
{
    public class CustomerDTO
    {
        public CustomerDTO()
        {

        }
        public CustomerDTO(Customer c)
        {
            customerEmail = c.customerEmail;
            customerName = c.customerName;
            customerID = c.customerID;
            customerPhoneNo = c.customerPhoneNo;
            isCheckedOut = c.isCheckedOut;
            psueoproducts = c.psueoproducts;
            role = c.role;
        }
        public string customerName { get; set; }
        
        public int customerID { get; set; }
        public string role { get; set; }
        public string customerEmail { get; set; }
        public string customerPhoneNo { get; set; }
        public bool isCheckedOut { get; set; }
        public virtual ICollection<psuedoproduct> psueoproducts { get; set; }
       
    }
}
