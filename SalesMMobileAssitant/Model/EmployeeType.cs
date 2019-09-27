using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model
{
    public class EmployeeType
    {
        public string CompID { get; set; }
        public string ETypeID { get; set; }
        public string ETypeDescription { get; set; }
        public bool Commissionable { get; set; }
    }
}
