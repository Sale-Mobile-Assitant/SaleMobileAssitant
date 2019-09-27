using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model.EpicorModel
{
    public class EpicorProduct
    {
        public string Company { get; set; }
        public string ProdCode { get; set; }
        public string PartNum { get; set; }
        public string PartDescription { get; set; }
        public double UnitPrice { get; set; }
        public string IUM { get; set; }

    }
}
