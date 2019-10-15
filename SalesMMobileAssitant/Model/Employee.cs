using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model
{
    public class Employee
    {
        public string CompID { get; set; }
        public string ETypeID { get; set; }
        public string EmplID { get; set; }
        public string EmplName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PhoneNum { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }

        private string _Address;
        public string Address
        {
            get
            {
                return string.Format("{0} {1} {2}", this.Address1, this.Address2, this.Address3);
            }
            set { _Address = value; }
        }

        public Customer[] Customer { get; set; }
    }
}
