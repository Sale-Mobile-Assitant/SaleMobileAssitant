using MaterialDesignThemes.Wpf;
using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model;
using SalesMMobileAssitant.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SalesMMobileAssitant.ViewModel
{
    public class NewRoutePlanViewModel : BaseViewModel
    {
        private ObservableCollection<RoutePlan> _RoutePlanResource;
        public ObservableCollection<RoutePlan> RoutePlanResource { get => _RoutePlanResource; set { _RoutePlanResource = value; OnPropertyChanged(); } }


        private int _OrderId;
        public int OrdeId { get => _OrderId; set { _OrderId = value; OnPropertyChanged(); } }

        private string _EmplID;
        public string EmplID { get => _EmplID; set { _EmplID = value; OnPropertyChanged(); } }

        private string _CustID;
        public string CustID { get => _CustID; set { _CustID = value; OnPropertyChanged(); } }

        private DateTime _DatePlan;
        public DateTime DatePlan { get => _DatePlan; set { _DatePlan = value; OnPropertyChanged(); } }

        private int _Prioritize;
        public int Prioritize { get => _Prioritize; set { _Prioritize = value; OnPropertyChanged(); } }

        private string _PlanStatus;
        public string PlanStatus { get => _PlanStatus; set { _PlanStatus = value; OnPropertyChanged(); } }

        private string _Note;
        public string Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }   

        private int _SelectedItemYear;
        public int SelectedItemYear { get => _SelectedItemYear; set { _SelectedItemYear = value; OnPropertyChanged(); } }

        private string _SelectedItemMonth;
        public string SelectedItemMonth { get => _SelectedItemMonth; set { _SelectedItemMonth = value; OnPropertyChanged(); } }

        private ObservableCollection<int> _ItemsYears;
        public ObservableCollection<int> ItemsYears { get => _ItemsYears; set { _ItemsYears = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _ItemsMonths;
        public ObservableCollection<string> ItemsMonths { get => _ItemsMonths; set { _ItemsMonths = value; OnPropertyChanged(); } }


        //private ListView _ListViewRoutePlan;
        //public ListView ListViewRoutePlan { get => _ListViewRoutePlan; set { _ListViewRoutePlan = value; OnPropertyChanged(); } }

        public ICommand CreateCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }

        public ICommand RemoveSubjectCommand { get; set; }
 
        public NewRoutePlanViewModel()
        {
            ShowList();
           

            AddYearOnCombobox();
            AddMonthOnCombobox();

            Event();
        }

        private void Event()
        {
            SelectionChangedCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                if (SelectedItemYear != DateTime.Now.Year)
                {
                    ItemsMonths.Clear();
                    ItemsMonths.Add("January");
                    ItemsMonths.Add("February");
                    ItemsMonths.Add("March");
                    ItemsMonths.Add("April");
                    ItemsMonths.Add("May");
                    ItemsMonths.Add("June");
                    ItemsMonths.Add("July");
                    ItemsMonths.Add("August");
                    ItemsMonths.Add("September");
                    ItemsMonths.Add("October");
                    ItemsMonths.Add("November");
                    ItemsMonths.Add("December");
                }
                else
                {
                    ItemsMonths.Clear();
                    AddMonthOnCombobox();
                }
            });

            CreateCommand = new RelayCommand<object>((p) => {
                if (!string.IsNullOrEmpty(SelectedItemMonth) && SelectedItemYear > 0)
                    return true;
                return false;
            }, (p) => {});

            RemoveSubjectCommand = new RelayCommand<RoutePlan>((p) => { return true; }, (OnRemoveSubject));

          

        }
        private void OnRemoveSubject(RoutePlan items) 
        {
            RoutePlanResource.Remove(items);
        }
    

        #region Method
        private void ShowList()
        {
            RoutePlanResource = new ObservableCollection<RoutePlan>();

            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });

            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });

            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });

            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });

            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });
            RoutePlanResource.Add(new RoutePlan() { EmplID = "NG", CustID = "NV", DatePlan = DateTime.Now.Date, Prioritize = 3, PlanStatus = "New", Note = "Ghi cai lol gi" });

        }

        private void AddYearOnCombobox()
        {
            ItemsYears = new ObservableCollection<int>();

            int yearNow = DateTime.Now.Year;

            for (int i = 0; i < 15; i++)
            {
                int year = yearNow + i;
                ItemsYears.Add(year);
            }
        }
        private void AddMonthOnCombobox()
        {
            ItemsMonths = new ObservableCollection<string>();

            int monthNow = DateTime.Now.Month;

            for (int i = 1; i < 13; i++)
            {
                if (i >= monthNow)
                {
                    switch (i)
                    {
                        case 1:
                            ItemsMonths.Add("January");
                            break;
                        case 2:
                            ItemsMonths.Add("February");
                            break;
                        case 3:
                            ItemsMonths.Add("March");
                            break;
                        case 4:
                            ItemsMonths.Add("April");
                            break;
                        case 5:
                            ItemsMonths.Add("May");
                            break;
                        case 6:
                            ItemsMonths.Add("June");
                            break;
                        case 7:
                            ItemsMonths.Add("July");
                            break;
                        case 8:
                            ItemsMonths.Add("August");
                            break;
                        case 9:
                            ItemsMonths.Add("September");
                            break;
                        case 10:
                            ItemsMonths.Add("October");
                            break;
                        case 11:
                            ItemsMonths.Add("November");
                            break;
                        case 12:
                            ItemsMonths.Add("December");
                            break;
                        default:
                            break;
                    }
                }
                
                
            }
        }


        #endregion
    }
  
}
