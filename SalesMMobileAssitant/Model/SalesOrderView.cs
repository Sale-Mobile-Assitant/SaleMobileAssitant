using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model
{
    public class SalesOrderView
    {
        public int OrdeId { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public string OrderDate { get; set; }
        public string OrderState { get; set; }
        public int Quatity { get; set; }
        public double Price { get; set; }
        public string Employee { get; set; }
    }
}
