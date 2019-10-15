using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model.EpicorModel
{
    public class OrderDetailLolModel
    {
        public int OrderNum { get; set; }
        public int OrderLine { get; set; }
    }

    public class OrderDetailLolModels
    {
        public OrderDetailLolModel[] value { get; set; }
    }
}
