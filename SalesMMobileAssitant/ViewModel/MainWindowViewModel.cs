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
    public class MainWindowViewModel : BaseViewModel
    {
       
        private int _SelectedItem;
        public int SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
            }
        }

        private int _SelectedItemDB;
        public int SelectedItemDB
        {
            get => _SelectedItemDB;
            set
            {
                _SelectedItemDB = value;
                OnPropertyChanged();
            }
        }

       

        private object _CurrentViewModel;
        public object CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set
            {
                if (_CurrentViewModel != value)
                {
                    _CurrentViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SelectionChangedCommand { get; set; }

        public ICommand SelectionChangedChildrenCommand { get; set; }
        public MainWindowViewModel()
        {
            CurrentViewModel = new DashBoardViewModel();

            SelectedItem = -1;
            SelectionChangedCommand = new RelayCommand<ListView>((p)=> { return true; },(p) => {
                int index = SelectedItem;
                SelectedItemDB = -1;
                
                OnNavigate(index);
            });
            
            SelectionChangedChildrenCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                int index = SelectedItemDB;
                SelectedItem = -1;
               
                OnNavigateChildren(index);
            });

        }
        private void OnNavigateChildren(int index)
        {
            switch (index)
            {
                case 0:
                    CurrentViewModel = new DashBoardViewModel();
                    break;
                case 1:
                    CurrentViewModel = new AnalysisViewModel();
                    break;
                default:
                    break;
            }
        }
        private void OnNavigate(int index)
        {
            switch (index)
            {
                case 0:
                    CurrentViewModel = new RoutePlanViewModel();
                    break;
                case 1:
                    CurrentViewModel = new SaleOrderViewModel();
                    break;
                case 2:
                    CurrentViewModel = new CustomersViewModel();
                    break;
                case 3:
                    CurrentViewModel = new MenbersViewModel();
                    break;
                case 4:
                    CurrentViewModel = new SettingViewModel();
                    break;
                case 5:
                    CurrentViewModel = new SettingViewModel();
                    break;
                case 6:
                    CurrentViewModel = new SettingViewModel();
                    break;
                case 7:
                    CurrentViewModel = new SettingViewModel();
                    break;
                default:
                    break;
            }
        }
    }
}
