using SalesMMobileAssitant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model
{
    public class RoutePlan : BaseViewModel
    {
        public string CompID { get; set; }
        public string EmplID { get; set; }
        public int CustID { get; set; }
        public DateTime DatePlan { get; set; }

        //public int Prioritize { get; set; }

        private int _Prioritize;
        public int Prioritize
        {
            get { return _Prioritize; }
            set { _Prioritize = value; OnPropertyChanged("Prioritize"); }
        }
        public bool Visited { get; set; }
        public string Note { get; set; }
    }
}
