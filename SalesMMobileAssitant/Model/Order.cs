using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model
{
    public class Order
    {
        public string CompID { get; set; }
        public string MyOrderID { get; set; }
        public int OrdeID { get; set; }
        public string CustID { get; set; }
        public string EmplID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime NeedByDate { get; set; }
        public DateTime RequestDate { get; set; }
        public string OrderStatus { get; set; }

        public OrderDetail[] OrderDetail { get; set; }
    }
}
