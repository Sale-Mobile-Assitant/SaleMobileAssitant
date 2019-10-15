using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.ViewModel
{
    public class MemberDetailViewModel :BaseViewModel
    {
        private ObservableCollection<Customer> _CustomersResources;
        public ObservableCollection<Customer> CustomersResources { get => _CustomersResources; set { _CustomersResources = value; OnPropertyChanged(); } }

        private string _CompID;
        public string CompID { get => _CompID; set { _CompID = value; OnPropertyChanged(); } }

        private string _ETypeID;
        public string ETypeID { get => _ETypeID; set { _ETypeID = value; OnPropertyChanged(); } }

        private string _EmplID;
        public string EmplID { get => _EmplID; set { _EmplID = value; OnPropertyChanged(); } }

        private string _EmplName;
        public string EmplName { get => _EmplName; set { _EmplName = value; OnPropertyChanged(); } }

        private string _Address1;
        public string Address1 { get => _Address1; set { _Address1 = value; OnPropertyChanged(); } }

        private string _Address2;
        public string Address2 { get => _Address2; set { _Address2 = value; OnPropertyChanged(); } }

        private string _Address3;
        public string Address3 { get => _Address3; set { _Address3 = value; OnPropertyChanged(); } }

        private string _PhoneNum;
        public string PhoneNum { get => _PhoneNum; set { _PhoneNum = value; OnPropertyChanged(); } }

        private DateTime _DateIn;
        public DateTime DateIn { get => _DateIn; set { _DateIn = value; OnPropertyChanged(); } }

        private DateTime _DateOut;
        public DateTime DateOut { get => _DateOut; set { _DateOut = value; OnPropertyChanged(); } }

        public MemberDetailViewModel(Employee epmloyee)
        {
            CompID = epmloyee.CompID;
            ETypeID = epmloyee.ETypeID;
            EmplID = epmloyee.EmplID;
            EmplName = epmloyee.EmplName;
            Address1 = epmloyee.Address1;
            Address2 = epmloyee.Address2;
            Address3 = epmloyee.Address3;
            PhoneNum = epmloyee.PhoneNum;
            DateIn = epmloyee.DateIn;
            DateOut = epmloyee.DateOut;

            CustomersResources = new ObservableCollection<Customer>(epmloyee.Customer);
           
        }

    }

}
