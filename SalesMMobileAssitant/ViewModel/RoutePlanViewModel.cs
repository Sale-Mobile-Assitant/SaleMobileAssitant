using MaterialDesignThemes.Wpf;
using SalesMMobileAssitant.Controller;
using SalesMMobileAssitant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SalesMMobileAssitant.ViewModel
{
    public class RoutePlanViewModel : BaseViewModel
    {
        #region Poperties

        private ObservableCollection<RoutePlanView> _RoutePlanResources;
        public ObservableCollection<RoutePlanView> RoutePlanResources { get => _RoutePlanResources; set { _RoutePlanResources = value; OnPropertyChanged(); } }

   

        private string _EmployeesName;
        public string EmployeesName { get => _EmployeesName; set { _EmployeesName = value; OnPropertyChanged(); } }

        private string _CustomerName;
        public string CustomerName { get => _CustomerName; set { _CustomerName = value; OnPropertyChanged(); } }

        private string _DataPlan;
        public string DataPlan { get => _DataPlan; set { _DataPlan = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private string _PlanStatus;
        public string PlanStatus { get => _PlanStatus; set { _PlanStatus = value; OnPropertyChanged(); } }

        #endregion

        private string _SelectedItemPageSize;
        public string SelectedItemPageSize { get => _SelectedItemPageSize; set { _SelectedItemPageSize = value; OnPropertyChanged(); } }

        private string _SelectedPageNumber;
        public string SelectedPageNumber { get => _SelectedPageNumber; set { _SelectedPageNumber = value; OnPropertyChanged(); } }


  


        public IList<string> PageSizes { get; set; }
        public string SelectedPageSize { get; set; }
        

        private ObservableCollection<ItemPage> _ItemPageNumber;
        public ObservableCollection<ItemPage> ItemPageNumber { get => _ItemPageNumber; set { _ItemPageNumber = value; OnPropertyChanged(); } }


        private bool _IsDialogOpen;
        public bool IsDialogOpen { get => _IsDialogOpen; set { _IsDialogOpen = value; OnPropertyChanged(); } }

        private string _lol;
        public string lol { get => _lol; set { _lol = value; OnPropertyChanged(); } }

       

        public ICommand NewRoutePlancommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }

        public ICommand SelectionChangedPageNumberCommand { get; set; }

        public ICommand ChevronRightCommand { get; set; }
        public ICommand ChevronLeftCommand { get; set; }
        public ICommand ChevronDoubleRightCommand { get; set; }
        public ICommand ChevronDoubleLeftCommand { get; set; }

        public RoutePlanViewModel()
        {
            RoutePlanResources = new ObservableCollection<RoutePlanView>();


            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });


            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });


            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });


            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 1", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Success" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 2", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Pending" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng  3", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 4", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Done" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn  Gia 5", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Canceled" });
            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });

            RoutePlanResources.Add(new RoutePlanView() { EmployeesName = "Nguyễn Trưởng Gia 6", CustomerName = "Nguyễn Trưởng Gia", DataPlan = DateTime.Now.ToString("dd/MM/yyyy"), Address = "Đồng Nai", PlanStatus = "Delivered" });



            PageSizes = GetAllPageSize();
            SelectedPageSize = "10";

            PageNumber(Convert.ToInt32(SelectedPageSize), RoutePlanResources.Count);
            SelectionChangedCommand = new RelayCommand<object>((p)=> { return true; },(p)=> {
                PageNumber(Convert.ToInt32(SelectedPageSize),RoutePlanResources.Count); // số trang
                SelectedPageNumber = "0";
            });

           
            SelectionChangedPageNumberCommand = new RelayCommand<object>((p)=> { return true; },(p)=> {
                
                MessageBox.Show(SelectedPageNumber.ToString());
            });

            ChangePage();

           

            

            NewRoutePlancommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) => {
                WindowNewRoutePlan wd = new WindowNewRoutePlan();
                wd.ShowDialog();
            });


            EditCommand = new RelayCommand<RoutePlanView>((p)=> { return true; },(OnShowDialog));

        }

        private void ChangePage()
        {
            // phai3
            ChevronRightCommand = new RelayCommand<object>((p) => {
                if (Convert.ToInt32(SelectedPageNumber) == ItemPageNumber.Count - 1)
                    return false;
                return true;
            }, (p) => {
                ChevronRight();
            });
            // trai
            ChevronLeftCommand = new RelayCommand<object>((p) => {
                if (Convert.ToInt32(SelectedPageNumber) == 0)
                    return false;
                return true;
            }, (p) => {
                ChevronLeft();
            });
            // cuoi phai
            ChevronDoubleRightCommand = new RelayCommand<object>((p) => {
                if (Convert.ToInt32(SelectedPageNumber) == ItemPageNumber.Count - 1)
                    return false;
                return true;
            }, (p) => {
                ChevronDoubleRight();
            });
            // dau trai
            ChevronDoubleLeftCommand = new RelayCommand<object>((p) => {
                if (SelectedPageNumber == "0")
                    return false;
                return true;
            }, (p) => {
                ChevronDoubleLeft();
            });
            


        }
        private void ChevronDoubleLeft()
        {
            SelectedPageNumber = (Convert.ToInt32(ItemPageNumber[0].Name) - 1).ToString();
            for (int i = 0; i < ItemPageNumber.Count; i++)
            {
                if (ItemPageNumber.Count > 5)
                {
                    if (i < 5)
                        ItemPageNumber[i].IsActive = true;
                    else
                        ItemPageNumber[i].IsActive = false;
                }
                else
                {
                    ItemPageNumber[i].IsActive = true;
                }
            }
        }
        private void ChevronDoubleRight()
        {
            SelectedPageNumber = ItemPageNumber[ItemPageNumber.Count - 2].Name;
            for (int i = ItemPageNumber.Count - 1; i >= 0; i--)
            {
                if (i >= ItemPageNumber.Count - 5)
                {
                    ItemPageNumber[i].IsActive = true;
                }
                else
                    ItemPageNumber[i].IsActive = false;
            }
        }
        private void ChevronRight()
        {
            SelectedPageNumber = (Convert.ToInt32(SelectedPageNumber) + 1).ToString();
            for (int i = 0; i < ItemPageNumber.Count; i++)
            {
                if (ItemPageNumber[i].IsActive == true)
                {
                    if (ItemPageNumber.Count >= 5)
                    {
                        ItemPageNumber[i].IsActive = false;
                        int index = Convert.ToInt32(ItemPageNumber[i].Uid);
                        for (int j = index; j < ItemPageNumber.Count; j++)
                        {
                            if (j < index + 5)
                            {
                                ItemPageNumber[j].IsActive = true;
                            }
                            else
                                ItemPageNumber[j].IsActive = false;
                        }
                        break;
                    }
                }
            }
        }
        private void ChevronLeft()
        {
            SelectedPageNumber = (Convert.ToInt32(SelectedPageNumber) - 1).ToString();

            for (int i = 0; i < ItemPageNumber.Count; i++)
            {
                if (i + 1 == ItemPageNumber.Count)
                {
                    return;
                }
                if (ItemPageNumber[i].IsActive == false && ItemPageNumber[i + 1].IsActive == true)
                {
                    if (ItemPageNumber.Count >= 5)
                    {
                        ItemPageNumber[i].IsActive = true;
                        int index = Convert.ToInt32(ItemPageNumber[i].Uid);
                        for (int j = index; j < ItemPageNumber.Count; j++)
                        {
                            if (j < index + 4)
                                ItemPageNumber[j].IsActive = true;
                            else
                                ItemPageNumber[j].IsActive = false;
                        }
                        break;
                    }
                }
            }
        }

        private void PageNumber(double size,int recordCount)
        {
            ItemPageNumber = new ObservableCollection<ItemPage>();

            if (size >= recordCount)
                ItemPageNumber.Add(new ItemPage() { Name = "1",IsActive=true,Uid="1"});
            else
            {
                double resultDouble = (recordCount / size);
                int resultInt = Convert.ToInt32(recordCount / size);
                int pageNumber;
                if (resultDouble == resultInt)
                {
                    pageNumber = resultInt;
                }

                pageNumber = resultInt + 1;


                for (int i = 1; i <= pageNumber; i++)
                {
                    if (i > 5)
                    {
                        ItemPageNumber.Add(new ItemPage() { Name = i.ToString(), IsActive = false, Uid = i.ToString() });
                    }
                    else
                    {
                        ItemPageNumber.Add(new ItemPage() { Name = i.ToString(), IsActive = true, Uid = i.ToString() });
                    }
                }
            }
         


        }

        private IList<string> GetAllPageSize()
        {
            IList<string> names = new List<string>();
            names.Add("10");
            names.Add("20");
            names.Add("30");
            names.Add("50");
            names.Add("100");
            return names;
        }
        private void OnShowDialog(RoutePlanView routePlanView)
        {
            IsDialogOpen = true;
            CustomerName = routePlanView.CustomerName;
            Address = routePlanView.Address;
            EmployeesName = routePlanView.EmployeesName;

        }

    }
}
