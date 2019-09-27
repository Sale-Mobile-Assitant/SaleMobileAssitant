using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model
{
    public class OrderDetail
    {
        public string CompID { get; set; }
        public string SiteID { get; set; }
        public string MyOrderID { get; set; }
        public string ProdID { get; set; }
        public string SellingQuantity { get; set; }
        public string UnitPrice { get; set; }
        public int OrderNum { get; set; }
        public int OrderLine { get; set; }
        public string LineType { get; set; }
    }
}
