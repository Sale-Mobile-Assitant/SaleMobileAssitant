using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model
{
    public class EpicorOrder
    {
        public string Company { get; set; }
        public string PONum { get; set; }
        public int OrderNum { get; set; }
        public string CustNum { get; set; }
        public string SalesRepCode1 { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime NeedByDate { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
