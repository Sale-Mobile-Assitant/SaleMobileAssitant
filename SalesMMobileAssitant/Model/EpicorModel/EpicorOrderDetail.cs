using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model.EpicorModel
{
    public class EpicorOrderDetail
    {
        public string Company { get; set; }
        public string POLine { get; set; }
        public int OrderNum { get; set; }
        public int OrderLine { get; set; }
        public string LineType { get; set; }
        public string PartNum { get; set; }
        public string SellingQuantity { get; set; }
        public string DocDspUnitPrice { get; set; }

    }
}
