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
        //public string CompID { get; set; }
        //public string EmplID { get; set; }
        //public int CustID { get; set; }
        //public DateTime DatePlan { get; set; }

        //public int Prioritize { get; set; }

        private string _CompID;
        public string CompID
        {
            get { return _CompID; }
            set { _CompID = value; OnPropertyChanged("CompID"); }
        }
        private string _EmplID;
        public string EmplID
        {
            get { return _EmplID; }
            set { _EmplID = value; OnPropertyChanged("EmplID"); }
        }
        private int _CustID;
        public int CustID
        {
            get { return _CustID; }
            set { _CustID = value; OnPropertyChanged("CustID"); }
        }
        private DateTime _DatePlan;
        public DateTime DatePlan
        {
            get { return _DatePlan; }
            set { _DatePlan = value; OnPropertyChanged("DatePlan"); }
        }


        private int _Prioritize;
        public int Prioritize
        {
            get { return _Prioritize; }
            set { _Prioritize = value; OnPropertyChanged("Prioritize"); }
        }
        private bool _Visited;
        public bool Visited
        {
            get { return _Visited; }
            set { _Visited = value; OnPropertyChanged("Visited"); }
        }
        private string _Note;
        public string Note
        {
            get { return _Note; }
            set { _Note = value; OnPropertyChanged("Note"); }
        }
        //public bool Visited { get; set; }
        //public string Note { get; set; }
    }
}
