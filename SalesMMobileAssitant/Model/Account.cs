using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model
{
    public class Account
    {
        public string CompID { get; set; }
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Type { get; set; }
        public string EmplID { get; set; }
        public string Note { get; set; }
    }
}
