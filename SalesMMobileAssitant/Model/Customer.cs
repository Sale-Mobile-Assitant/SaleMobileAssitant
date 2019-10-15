using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model
{
    public class Customer
    {
        public string CompID { get; set; }
        public string EmplID { get; set; }
        public string CustID { get; set; }
        public string CustName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNum { get; set; }
        public double Discount { get; set; }

        private string _Address;
        public string Address
        {
            get
            {
                return string.Format("{0} {1} {2}", this.Address1, this.Address2,this.Address3);
            }
            set{ _Address = value; }
        }

    }
    public class ServiceCustomer : Customer
    {
        public Order[] Order { get; set; }
    }
}
