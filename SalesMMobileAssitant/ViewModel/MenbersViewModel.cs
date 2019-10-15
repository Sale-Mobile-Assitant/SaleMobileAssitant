using SalesMMobileAssitant.Controller;
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
    public class MenbersViewModel : BaseViewModel
    {

        private ObservableCollection<Employee> _MembersResources;
        public ObservableCollection<Employee> MembersResources { get => _MembersResources; set { _MembersResources = value; OnPropertyChanged(); } }

        private ICollectionView _MenbersCollection;
        public ICollectionView MenbersCollection { get => _MenbersCollection; set { _MenbersCollection = value; OnPropertyChanged(); } }


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
                MenbersCollection.Filter += Filter;
            }
        }

        private MemberDetailViewModel DetailViewModel;
        public ICommand ViewDetailCommand { get; set; }
        public MenbersViewModel()
        {
            _ = Init();

            SelectedInx = "0";

            ViewDetailCommand = new RelayCommand<Employee>((p) => { return true; }, (ShowDetail));

        }
        private void ShowDetail(Employee items)
        {
            DetailViewModel = new MemberDetailViewModel(items);

            WindownMemberOrderDetail windown = new WindownMemberOrderDetail();

            windown.DataContext = DetailViewModel;

            windown.ShowDialog();
        }
        private bool Filter(object cus)
        {
            Employee customer = cus as Employee;
            if (!string.IsNullOrEmpty(FilterText) && SelectedInx == "0")
                return customer.EmplID.Contains(FilterText);
            else if (!string.IsNullOrEmpty(FilterText) && SelectedInx == "1")
                return customer.EmplName.Contains(FilterText);
            return true;
        }
        async private Task Init()
        {
            var employees = await GeneralMethods.Ins.GetDataFromDB<Employee>("/api/Employee/employees");
            MembersResources = new ObservableCollection<Employee>(employees);

            MenbersCollection = CollectionViewSource.GetDefaultView(MembersResources);
        }

    }
}
