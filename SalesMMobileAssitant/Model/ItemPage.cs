using SalesMMobileAssitant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Model
{
    public class ItemPage : BaseViewModel
    {
     
        private string _Uid;

        public string Uid
        {
            get { return _Uid; }
            set { _Uid = value; OnPropertyChanged("Name"); }
        }
        private string _Name;


        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged("Name"); }
        }
        private bool _IsActive;


        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; OnPropertyChanged("IsActive"); }
        }
    }
}
