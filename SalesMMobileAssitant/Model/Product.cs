using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model
{
    public class Product
    {
        public string CompID { get; set; }
        public string PGroupID { get; set; }
        public string ProdID { get; set; }
        public string ProdName { get; set; }
        public double UnitPrice { get; set; }
        public string UOM { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
