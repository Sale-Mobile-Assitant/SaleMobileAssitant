using MaterialDesignThemes.Wpf;
using SalesMMobileAssitant.Controller;
using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model;
using SalesMMobileAssitant.Model.EpicorModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace SalesMMobileAssitant.ViewModel
{
    public class SaleOrderViewModel : BaseViewModel
    {
        #region Properties

        private ObservableCollection<ServiceOrder> _SalesOrdersResources;
        public ObservableCollection<ServiceOrder> SalesOrdersResources { get => _SalesOrdersResources; set { _SalesOrdersResources = value; OnPropertyChanged(); } }

        private ICollectionView _EmployeeCollection;
        public ICollectionView EmployeeCollection { get => _EmployeeCollection; set { _EmployeeCollection = value; OnPropertyChanged(); } }



        private string _FilterText = string.Empty;
        public string FilterText
        {
            get { return _FilterText; }
            set
            {
                _FilterText = value;
                OnPropertyChanged();
                EmployeeCollection.Filter += Filter;
            }
        }



        private string _MyOrderID;
        public string MyOrderID { get => _MyOrderID; set { _MyOrderID = value; OnPropertyChanged(); } }

        private int _OrdeID;
        public int OrdeID { get => _OrdeID; set { _OrdeID = value; OnPropertyChanged(); } }

        private string _CustID;
        public string CustID { get => _CustID; set { _CustID = value; OnPropertyChanged(); } }

        private string _EmplID;
        public string EmplID { get => _EmplID; set { _EmplID = value; OnPropertyChanged(); } }

        private string _OrderDate;
        public string OrderDate { get => _OrderDate; set { _OrderDate = value; OnPropertyChanged(); } }

        private string _NeedByDate;
        public string NeedByDate { get => _NeedByDate; set { _NeedByDate = value; OnPropertyChanged(); } }

        private string _RequestDate;
        public string RequestDate { get => _RequestDate; set { _RequestDate = value; OnPropertyChanged(); } }

        private string _OrderStatus;
        public string OrderStatus { get => _OrderStatus; set { _OrderStatus = value; OnPropertyChanged(); } }

        private ObservableCollection<ServiceOrder> _routePlans;
        public ObservableCollection<ServiceOrder> routePlans { get => _routePlans; set { _routePlans = value; OnPropertyChanged(); } }

        private ObservableCollection<ItemPage> _ItemPageNumber;
        public ObservableCollection<ItemPage> ItemPageNumber { get => _ItemPageNumber; set { _ItemPageNumber = value; OnPropertyChanged(); } }

        private string _SelectedItemPageSize;
        public string SelectedItemPageSize { get => _SelectedItemPageSize; set { _SelectedItemPageSize = value; OnPropertyChanged(); } }

        private string _SelectedPageNumber;
        public string SelectedPageNumber { get => _SelectedPageNumber; set { _SelectedPageNumber = value; OnPropertyChanged(); } }

        private string _Showing;
        public string Showing { get => _Showing; set { _Showing = value; OnPropertyChanged(); } }

        private string _SynctoEpicor;
        public string SynctoEpicor { get => _SynctoEpicor; set { _SynctoEpicor = value; OnPropertyChanged(); } }

        private OrderDetailViewModel orderDetailViewModel;

        private string _SelectedMonth;
        public string SelectedMonth { get => _SelectedMonth; set { _SelectedMonth = value; OnPropertyChanged(); } }


        private string _SelectedYear;
        public string SelectedYear { get => _SelectedYear; set { _SelectedYear = value; OnPropertyChanged(); } }

        private bool _IsSelected;
        public bool IsSelected { get => _IsSelected; set { _IsSelected = value; OnPropertyChanged(); } }


        private bool _IsSelectedAll;
        public bool IsSelectedAll { get => _IsSelectedAll; set { _IsSelectedAll = value; OnPropertyChanged(); } }

        private string _SelectedOrderStatus;
        public string SelectedOrderStatus { get => _SelectedOrderStatus; set { _SelectedOrderStatus = value; OnPropertyChanged(); } }

        private string _SelectedInx;
        public string SelectedInx { get => _SelectedInx; set { _SelectedInx = value; OnPropertyChanged(); } }
        public IList<string> ListYear { get; set; }
        public IList<string> PageSizes { get; set; }

        public IList<Month> ListMonth { get; set; }

        public IList<StatusType> ListOrderStatus { get; set; }

        private int pageNumber;
        private int numberRecord;
        private int totalRecord;
        private int totalPage;
        

        private int countChecked = 0;

        public string SelectedPageSize { get; set; }
        #endregion

        #region Command
        public ICommand NextCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        public ICommand LastCommand { get; set; }
        public ICommand FirstCommand { get; set; }

        public ICommand ViewDetailCommand { get; set; }

        public ICommand SelectionChangedMonthCommand { get; set; }

        public ICommand TextChangedSearchCommand { get; set; }
        public ICommand CheckedCommand { get; set; }

        public ICommand UnCheckedCommand { get; set; }
        public ICommand SyncCommand { get; set; }
        public ICommand SelectionChangedYearCommand { get; set; }

        public ICommand SelectionChangedCommand { get; set; }

        public ICommand IsCheckAddCommand { get; set; }
        public ICommand SelectionChangedPageNumberCommand { get; set; }

        public ICommand SelectionChangedOrderStatusCommand { get; set; }

        #endregion
        public SaleOrderViewModel()
        {
            #region Initialization

            PageSizes = GetAllPageSize();
            ListMonth = AddMonth();
            ListYear = AddYear();
            _ = AddOrderStauts();
            SelectedPageSize = "10";
            IsSelectedAll = false;
            SelectedInx = "0";
            SelectedMonth = DateTime.Now.Month.ToString();
            SelectedYear = DateTime.Now.Year.ToString();
            SynctoEpicor = "Sync to Epicor";
            SelectedOrderStatus = ListOrderStatus[ListOrderStatus.Count - 1].STypeID.ToString();
            numberRecord = Convert.ToInt32(SelectedPageSize);

            _ = LoadData(DateTime.Now.Month, DateTime.Now.Year, SelectedOrderStatus);

            SalesOrdersResources = new ObservableCollection<ServiceOrder>(LoadRecord(pageNumber, numberRecord));


            EmployeeCollection = CollectionViewSource.GetDefaultView(SalesOrdersResources);

            #endregion


            #region Event

            SelectionChangedMonthCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                IsSelectedAll = false;
                _ = LoadData(Convert.ToInt32(SelectedMonth), Convert.ToInt32(SelectedYear), SelectedOrderStatus);
                SalesOrdersResources = new ObservableCollection<ServiceOrder>(LoadRecord(pageNumber, numberRecord));
                EmployeeCollection = CollectionViewSource.GetDefaultView(SalesOrdersResources);
                TotalPages();
            });

            SelectionChangedOrderStatusCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                IsSelectedAll = false;
                _ = LoadData(Convert.ToInt32(SelectedMonth), Convert.ToInt32(SelectedYear), SelectedOrderStatus);
                SalesOrdersResources = new ObservableCollection<ServiceOrder>(LoadRecord(pageNumber, numberRecord));
                EmployeeCollection = CollectionViewSource.GetDefaultView(SalesOrdersResources);
                TotalPages();
            });

            SelectionChangedYearCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                IsSelectedAll = false;
                _ = LoadData(Convert.ToInt32(SelectedMonth), Convert.ToInt32(SelectedYear), SelectedOrderStatus);
                SalesOrdersResources = new ObservableCollection<ServiceOrder>(LoadRecord(pageNumber, numberRecord));
                EmployeeCollection = CollectionViewSource.GetDefaultView(SalesOrdersResources);
                TotalPages();
            });



            SelectionChangedCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                numberRecord = Convert.ToInt32(SelectedPageSize);
                SalesOrdersResources = new ObservableCollection<ServiceOrder>(LoadRecord(pageNumber, numberRecord));
                EmployeeCollection = CollectionViewSource.GetDefaultView(SalesOrdersResources);
                TotalPages();

            });

            IsCheckAddCommand = new RelayCommand<object>((p)=> { return true; },(p)=> {
                
                if (IsSelectedAll == false)
                {
                    foreach (var item in routePlans)
                    {
                        item.IsSelected = false;
                        countChecked = 0;
                    }
                }
                else
                {
                    countChecked = 0;
                    foreach (var item in routePlans)
                    {
                        item.IsSelected = true;
                        countChecked += 1;
                        SynctoEpicor = string.Format("Sync to Epicor ({0})", countChecked);
                    }
                }
              
            });

            SyncCommand = new RelayCommand<object>((p)=> {
                if (countChecked < 1)
                    return false;
                return true;
            },(OnShowDialog));

            SelectionChangedPageNumberCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                SalesOrdersResources = new ObservableCollection<ServiceOrder>(LoadRecord(Convert.ToInt32(SelectedPageNumber) + 1, numberRecord));
                EmployeeCollection = CollectionViewSource.GetDefaultView(SalesOrdersResources);
                pageNumber = Convert.ToInt32(SelectedPageNumber);
                Showing = string.Format("Showing {0} to {1} of {2} entries", pageNumber + 1, totalPage, totalRecord);

            });

            CheckedCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                if (IsSelectedAll == false)
                {
                    countChecked += 1;
                    SynctoEpicor = string.Format("Sync to Epicor ({0})", countChecked);
                }
            });
            UnCheckedCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                countChecked -= 1;
                if (countChecked > 0)
                    SynctoEpicor = string.Format("Sync to Epicor ({0})", countChecked);
                else
                    SynctoEpicor = string.Format("Sync to Epicor ");

            });


            ViewDetailCommand = new RelayCommand<ServiceOrder>((p) => { return true; }, (ShowOrderDetail));


            #endregion

            ChangePage();

        }
        #region Method
        private bool Filter(object emp)
        {
            ServiceOrder saleOrder = emp as ServiceOrder;
            if (!string.IsNullOrEmpty(FilterText) && SelectedInx == "1")
                return saleOrder.CustID.Contains(FilterText);
            else if (!string.IsNullOrEmpty(FilterText) && SelectedInx == "0")
                return saleOrder.MyOrderID.Contains(FilterText);
            return true;
        }

        private async void OnShowDialog(object lol)
        {
            if (MaterialMessageBox.ShowWithCancel("Are you sync to epicor ?", "Sync to epicor") == MessageBoxResult.OK)
            {
                var viewModel = new SynsToEpicorOrderViewModel(routePlans);
                //object dialogResult = await DialogHost.Show(viewModel, DialogIdentifier);

                await DialogHost.Show(viewModel, (object sender, DialogOpenedEventArgs e) =>
                {
                    void OnClose(object _, EventArgs args)
                    {
                        viewModel.Close -= OnClose;
                        e.Session.Close();
                    }
                    viewModel.Close += OnClose;
                });

                _ = LoadData(Convert.ToInt32(SelectedMonth), Convert.ToInt32(SelectedYear), SelectedOrderStatus);
                SalesOrdersResources = new ObservableCollection<ServiceOrder>(LoadRecord(pageNumber, numberRecord));
                EmployeeCollection = CollectionViewSource.GetDefaultView(SalesOrdersResources);
                SynctoEpicor = "Sync to Epicor";
                countChecked = 0;
            }

        }

       
        private void ShowOrderDetail(Order items)
        {
            orderDetailViewModel = new OrderDetailViewModel(items);

            WindownOrderDetail windown = new WindownOrderDetail();

            windown.DataContext = orderDetailViewModel;

            //orderDetailViewModel.Orders = items; // cũng hay như xàm lol

            windown.ShowDialog();
        }
        private IList<Month> AddMonth()
        {
            IList<Month> listMonth = new List<Month>();
            listMonth.Add(new Month() { NumberMonth = 1, TextMonth = "January" });
            listMonth.Add(new Month() { NumberMonth = 2, TextMonth = "February" });
            listMonth.Add(new Month() { NumberMonth = 3, TextMonth = "March" });
            listMonth.Add(new Month() { NumberMonth = 4, TextMonth = "April" });
            listMonth.Add(new Month() { NumberMonth = 5, TextMonth = "May" });
            listMonth.Add(new Month() { NumberMonth = 6, TextMonth = "June" });
            listMonth.Add(new Month() { NumberMonth = 7, TextMonth = "July" });
            listMonth.Add(new Month() { NumberMonth = 8, TextMonth = "August" });
            listMonth.Add(new Month() { NumberMonth = 9, TextMonth = "September" });
            listMonth.Add(new Month() { NumberMonth = 10, TextMonth = "October" });
            listMonth.Add(new Month() { NumberMonth = 11, TextMonth = "November" });
            listMonth.Add(new Month() { NumberMonth = 12, TextMonth = "December" });
            return listMonth;
        }
        private IList<string> AddYear()
        {
            IList<string> listYear = new List<string>();
            for (int i = 2010; i < 2023; i++)
            {
                listYear.Add(i.ToString());
            }

            return listYear;
        }

      

        async private Task AddOrderStauts()
        {
            var result = await GeneralMethods.Ins.GetDataFromDB<StatusType>("/api/StatusType/statusType");
            ListOrderStatus = new ObservableCollection<StatusType>(result);
            ListOrderStatus.Add(new StatusType() { STypeID = 0,STypeName = "All"});
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


        async private Task LoadData(int month, int year,string orderStauts)
        {
            var result = await GeneralMethods.Ins.GetDataFromDB<ServiceOrder>("/api/Order/orders");
             
            if (orderStauts != ListOrderStatus.LastOrDefault().STypeID.ToString())
            {
                var resultByMonth = result.Where(p => p.OrderDate.Value.Month.CompareTo(month) == 0 & p.OrderDate.Value.Year.CompareTo(year) == 0 && p.OrderStatus == orderStauts);
                routePlans = new ObservableCollection<ServiceOrder>(resultByMonth);

            }
            else
            {
                var resultByMonth = result.Where(p => p.OrderDate.Value.Month.CompareTo(month) == 0 & p.OrderDate.Value.Year.CompareTo(year) == 0);
                routePlans = new ObservableCollection<ServiceOrder>(resultByMonth);

            }
            totalRecord = routePlans.Count;
        }

        private List<ServiceOrder> LoadRecord(int page, int recordNum)
        {
            List<ServiceOrder> result = new List<ServiceOrder>();
            result = routePlans.Skip((page - 1) * recordNum).Take(recordNum).ToList();

            return result;
        }

        private void TotalPages()
        {
            ItemPageNumber = new ObservableCollection<ItemPage>();
            var Result = decimal.Divide(totalRecord, numberRecord);
            totalPage = Convert.ToInt32(Math.Ceiling(Result));
            SelectedPageNumber = "0";
            for (int i = 1; i <= totalPage; i++)
            {
                if (i <= 5)
                    ItemPageNumber.Add(new ItemPage() { Name = i.ToString(), IsActive = true, Uid = i.ToString() });
                else
                    ItemPageNumber.Add(new ItemPage() { Name = i.ToString(), IsActive = false, Uid = i.ToString() });
            }
            if (ItemPageNumber.Count == 0)
                ItemPageNumber.Add(new ItemPage() { Name = "1", IsActive = true, Uid = "1" });
        }

        private void ChangePage()
        {
            // ở đây có lỗi rất nạng. không fix đc 
            if (SelectedPageNumber == null)
            {
                return;
            }
            // phai3
            NextCommand = new RelayCommand<object>((p) => {
                if (Convert.ToInt32(SelectedPageNumber) == ItemPageNumber.Count - 1)
                    return false;
                return true;
            }, (p) => {
                NextPage();
            });
            // trai
            PreviousCommand = new RelayCommand<object>((p) => {
                if (Convert.ToInt32(SelectedPageNumber) == 0)
                    return false;
                return true;
            }, (p) => {
                PreviousPage();
            });
            // cuoi phai
            LastCommand = new RelayCommand<object>((p) => {
                if (Convert.ToInt32(SelectedPageNumber) == ItemPageNumber.Count - 1)
                    return false;
                return true;
            }, (p) => {
                LastPage();
            });
            // dau trai
            FirstCommand = new RelayCommand<object>((p) => {
                if (SelectedPageNumber == "0")
                    return false;
                return true;
            }, (p) => {
                FirstPage();
            });



        }
        private void FirstPage()
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
        private void LastPage()
        {
            if (pageNumber - 1 > 0)
            {
                pageNumber--;
                SalesOrdersResources = new ObservableCollection<ServiceOrder>(LoadRecord(pageNumber, numberRecord));
            }

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
        private void NextPage()
        {
            if (pageNumber - 1 < totalRecord / numberRecord)
            {
                pageNumber++;
                SalesOrdersResources = new ObservableCollection<ServiceOrder>(LoadRecord(pageNumber, numberRecord));
            }
            int page = Convert.ToInt32(SelectedPageNumber);
            if (page - 1 < totalPage)
            {
                SelectedPageNumber = (Convert.ToInt32(SelectedPageNumber) + 1).ToString();
                if (Convert.ToInt32(SelectedPageNumber) + 5 >= totalPage)
                {
                    //ItemPageNumber[Convert.ToInt32(SelectedPageNumber) - 1].IsActive = false;
                    for (int i = 0; i < totalPage; i++)
                    {
                        if (i > totalPage - 6)
                            ItemPageNumber[i].IsActive = true;
                        else
                            ItemPageNumber[i].IsActive = false;
                    }
                }
                else
                {
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

            }


        }
        private void PreviousPage()
        {
            if (pageNumber - 1 > 0)
            {
                pageNumber--;
                SalesOrdersResources = new ObservableCollection<ServiceOrder>(LoadRecord(pageNumber, numberRecord));
            }
            int page = Convert.ToInt32(SelectedPageNumber);
            if (page - 1 >= 0)
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


        }

        #endregion
    }
}
