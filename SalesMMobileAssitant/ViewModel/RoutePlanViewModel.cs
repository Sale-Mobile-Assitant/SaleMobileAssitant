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


        private bool _IsDialogOpen;
        public bool IsDialogOpen { get => _IsDialogOpen; set { _IsDialogOpen = value; OnPropertyChanged(); } }

        private string _lol;
        public string lol { get => _lol; set { _lol = value; OnPropertyChanged(); } }

        //private bool _IsDialogOpen;
        //public bool IsDialogOpen
        //{
        //    get => _IsDialogOpen;
        //    set => Set(ref _IsDialogOpen, value);
        //}

        public ICommand NewRoutePlancommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        

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


            NewRoutePlancommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) => {
                WindowNewRoutePlan wd = new WindowNewRoutePlan();
                wd.ShowDialog();
            });


            EditCommand = new RelayCommand<RoutePlanView>((p)=> { return true; },(OnShowDialog));

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
