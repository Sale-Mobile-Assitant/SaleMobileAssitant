using MaterialDesignThemes.Wpf;
using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace SalesMMobileAssitant.ViewModel
{
    public class CustomersViewModel :BaseViewModel
    {
        

        private ObservableCollection<Customer> _CustomersResources;
        public ObservableCollection<Customer> CustomersResources { get => _CustomersResources; set { _CustomersResources = value; OnPropertyChanged(); } }

        private ICollectionView _CustomerCollection;
        public ICollectionView CustomerCollection { get => _CustomerCollection; set { _CustomerCollection = value; OnPropertyChanged(); } }


        private string _UnitPrice;
        public string UnitPrice { get => _UnitPrice; set { _UnitPrice = value; OnPropertyChanged(); } }

        private string _SelectedInx;
        public string SelectedInx { get => _SelectedInx; set { _SelectedInx = value; OnPropertyChanged(); } }


        private string _FilterText = string.Empty;
        public string FilterText
        {
            get { return _FilterText; }
            set
            {
                _FilterText = value;
                OnPropertyChanged();
                CustomerCollection.Filter += Filter;
            }
        }
        public CustomersViewModel()
        {
            _ = Init();

            SelectedInx = "0";

        }

        private bool Filter(object cus)
        {
            Customer customer = cus as Customer;
            if (!string.IsNullOrEmpty(FilterText) && SelectedInx == "0")
                return customer.CustID.Contains(FilterText);
            else if (!string.IsNullOrEmpty(FilterText) && SelectedInx == "1")
                return customer.CustName.Contains(FilterText);
            else if (!string.IsNullOrEmpty(FilterText) && SelectedInx == "2")
                return customer.City.Contains(FilterText);
            else if (!string.IsNullOrEmpty(FilterText) && SelectedInx == "3")
                return customer.Country.Contains(FilterText);
            return true;
        }
        async private Task Init()
        {
            var customer = await GeneralMethods.Ins.GetDataFromDB<Customer>("/api/Customer/customers");
            CustomersResources = new ObservableCollection<Customer>(customer);

            CustomerCollection = CollectionViewSource.GetDefaultView(CustomersResources);
        }

        private async void OnShowDialogAdd(object lol)
        {
            var viewModel = new CustomerAddDialogViewModel();

            await DialogHost.Show(viewModel, (object sender, DialogOpenedEventArgs e) =>
            {
                void OnClose(object _, EventArgs args)
                {
                    viewModel.Close -= OnClose;
                    e.Session.Close();
                }
                viewModel.Close += OnClose;

            });
            _ = Init();
        }
    }
}
