using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model.EpicorModel
{
    public class EpicorCustomer
    {
        public string Company { get; set; }
        public string SalesRepCode { get; set; }
        public int CustNum { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNum { get; set; }
        public double DiscountPercent { get; set; }
    }
}
