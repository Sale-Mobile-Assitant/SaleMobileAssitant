﻿using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SalesMMobileAssitant.ViewModel
{
    public class RoutePlanDialogViewModel : BaseViewModel
    {
        public event EventHandler Close;

        private string _CompID;
        public string CompID { get => _CompID; set { _CompID = value; OnPropertyChanged(); } }

        private DateTime _DatePlan;
        public DateTime DatePlan { get => _DatePlan; set { _DatePlan = value; OnPropertyChanged(); } }

        private string _Prioritize;
        public string Prioritize { get => _Prioritize; set { _Prioritize = value; OnPropertyChanged(); } }

        private string _EmplID;
        public string EmplID { get => _EmplID; set { _EmplID = value; OnPropertyChanged(); } }

        private int _CustNum;
        public int CustNum { get => _CustNum; set { _CustNum = value; OnPropertyChanged(); } }

        private string _Note;
        public string Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }

        private string _SelectedEmplID;
        public string SelectedEmplID { get => _SelectedEmplID; set { _SelectedEmplID = value; OnPropertyChanged(); } }

        private string _SelectedCustID;
        public string SelectedCustID { get => _SelectedCustID; set { _SelectedCustID = value; OnPropertyChanged(); } }

        private ObservableCollection<Employee> _ListEmployee;
        public ObservableCollection<Employee> ListEmployee { get => _ListEmployee; set { _ListEmployee = value; OnPropertyChanged(); } }

        private ObservableCollection<Customer> _ListCustomer;
        public ObservableCollection<Customer> ListCustomer { get => _ListCustomer; set { _ListCustomer = value; OnPropertyChanged(); } }


        private bool _IsValidating;
        public bool IsValidating { get => _IsValidating; set { _IsValidating = value; OnPropertyChanged(); } }

        public ICommand SaveCommand { get; set; }

        public ICommand SelectionChangedEmployeeCommand { get; set; }
        public RoutePlanDialogViewModel()
        {
            CompID = "EPIC06";
            DatePlan = DateTime.Today;

            _ = GetListEmployees();
            
            SelectionChangedEmployeeCommand = new RelayCommand<object>((p)=> { return true; },(p)=> {
                _  = GetListCustomerByEmplID(SelectedEmplID);
            });

            SaveCommand = new RelayCommand<object>((p)=> {
                if (string.IsNullOrEmpty(CompID) || string.IsNullOrWhiteSpace(Prioritize) || string.IsNullOrEmpty(SelectedEmplID) || string.IsNullOrEmpty(SelectedCustID))
                    return false;
                if (int.TryParse(Prioritize,out int result) == false)
                    return false;
                return true;
            },(p)=> {
                RoutePlan routePlan = new RoutePlan()
                {
                    CompID = CompID,
                    CustID = Convert.ToInt32(SelectedCustID),
                    EmplID = SelectedEmplID,
                    Prioritize = Convert.ToInt32(Prioritize),
                    Visited = false,
                    DatePlan = DatePlan,
                    Note = Note
                };
                _ = AddRoutePlan(routePlan);
               
            });
        }
        async private Task AddRoutePlan(RoutePlan routePlan)
        {
            if (await GeneralMethods.Ins.PostDataToDB<RoutePlan>("/api/RoutePlan", routePlan) == true)
            {
                IsValidating = true;
                await Task.Delay(TimeSpan.FromSeconds(2));

                MaterialMessageBox.Show("Success");
                Close?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("An error occurred. Please check again");
            }
            
        }
        async private Task GetListEmployees()
        {
            var result = await GeneralMethods.Ins.GetDataFromDB<Employee>("/api/Employee/employees");
            ListEmployee = new ObservableCollection<Employee>(result);
        }
        async private Task GetListCustomerByEmplID(string EmplID)
        {
            var result = await GeneralMethods.Ins.GetDataFromEpicor<Customer>("/api/Customer/customers");
            List<Customer> customers = result.Where(p => p.EmplID.CompareTo(EmplID) == 0).ToList();
            ListCustomer = new ObservableCollection<Customer>(customers);
        }

    }
}
