using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SalesMMobileAssitant.ViewModel
{
    public class SaleOrderViewModel : BaseViewModel
    {
        private ObservableCollection<Order> _SalesOrdersResources;
        public ObservableCollection<Order> SalesOrdersResources { get => _SalesOrdersResources; set { _SalesOrdersResources = value; OnPropertyChanged(); } }

        private ObservableCollection<Order> _routePlans;
        public ObservableCollection<Order> routePlans { get => _routePlans; set { _routePlans = value; OnPropertyChanged(); } }

        private ObservableCollection<ItemPage> _ItemPageNumber;
        public ObservableCollection<ItemPage> ItemPageNumber { get => _ItemPageNumber; set { _ItemPageNumber = value; OnPropertyChanged(); } }

        private string _SelectedItemPageSize;
        public string SelectedItemPageSize { get => _SelectedItemPageSize; set { _SelectedItemPageSize = value; OnPropertyChanged(); } }

        private string _SelectedPageNumber;
        public string SelectedPageNumber { get => _SelectedPageNumber; set { _SelectedPageNumber = value; OnPropertyChanged(); } }

        private string _SelectedMonth;
        public string SelectedMonth { get => _SelectedMonth; set { _SelectedMonth = value; OnPropertyChanged(); } }



        private string _SelectedYear;
        public string SelectedYear { get => _SelectedYear; set { _SelectedYear = value; OnPropertyChanged(); } }
        public IList<string> ListYear { get; set; }
        public IList<string> PageSizes { get; set; }

        public IList<Month> ListMonth { get; set; }

        private int pageNumber;
        private int numberRecord;
        private int totalRecord;
        private int totalPage;

        public string SelectedPageSize { get; set; }

        public ICommand NextCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        public ICommand LastCommand { get; set; }
        public ICommand FirstCommand { get; set; }

        public ICommand SelectionChangedMonthCommand { get; set; }


        public ICommand SelectionChangedYearCommand { get; set; }
        public SaleOrderViewModel()
        {
            PageSizes = GetAllPageSize();
            ListMonth = AddMonth();
            ListYear = AddYear();
            SelectedPageSize = "10";
            SelectedMonth = DateTime.Now.Month.ToString();
            SelectedYear = DateTime.Now.Year.ToString();
            _ = LoadData();


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
        async private Task LoadData()
        {
            SalesOrdersResources = new ObservableCollection<Order>();

            var result = await GeneralMethods.Ins.GetDataFromDB<Order>("Order/orders");

            foreach (var item in result)
            {
                Order order = new Order()
                {
                    CompID = item.CompID,
                    MyOrderID = item.MyOrderID,
                    OrdeID = item.OrdeID,
                    CustID = item.CustID,
                    EmplID = item.EmplID,
                    OrderDate = item.OrderDate,
                    NeedByDate = item.NeedByDate,
                    RequestDate = item.RequestDate,
                    OrderDetail = item.OrderDetail,
                };

                switch (item.OrderStatus)
                {
                    case "1":
                        order.OrderStatus = "Pending";
                        break;
                    case "2":
                        order.OrderStatus = "Verifying";
                        break;
                    case "3":
                        order.OrderStatus = "Completed";
                        break;
                    default:
                        break;
                }
                SalesOrdersResources.Add(order);
            }
        }

        private List<Order> LoadRecord(int page, int recordNum)
        {
            List<Order> result = new List<Order>();
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
                SalesOrdersResources = new ObservableCollection<Order>(LoadRecord(pageNumber, numberRecord));
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
                SalesOrdersResources = new ObservableCollection<Order>(LoadRecord(pageNumber, numberRecord));
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
                SalesOrdersResources = new ObservableCollection<Order>(LoadRecord(pageNumber, numberRecord));
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
    }
}
