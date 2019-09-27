using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model
{
    public class RoutePlan
    {
        public string EmplID { get; set; }
        public string CustID { get; set; }
        public DateTime DatePlan { get; set; }
        public int Prioritize { get; set; }
        public string PlanStatus { get; set; }
        public string Note { get; set; }
    }
}
