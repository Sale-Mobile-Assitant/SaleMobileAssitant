using LiveCharts;
using LiveCharts.Wpf;
using SalesMMobileAssitant.Controller;
using SalesMMobileAssitant.EndPoint;
using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SalesMMobileAssitant.ViewModel
{
    public class DashBoardViewModel : BaseViewModel
    {
        private ObservableCollection<Order> _SalesOrdersResources;
        public ObservableCollection<Order> SalesOrdersResources { get => _SalesOrdersResources; set { _SalesOrdersResources = value; OnPropertyChanged(); } }

        private List<EpicorOrder> _ListOrders;
        public List<EpicorOrder> ListOrders { get => _ListOrders; set { _ListOrders = value; OnPropertyChanged(); } }

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

        private string _OrderReceived;
        public string OrderReceived { get => _OrderReceived; set { _OrderReceived = value; OnPropertyChanged(); } }

        private string _TotalRevenue;
        public string TotalRevenue { get => _TotalRevenue; set { _TotalRevenue = value; OnPropertyChanged(); } }


        private string _TotalRevenueTag;
        public string TotalRevenueTag { get => _TotalRevenueTag; set { _TotalRevenueTag = value; OnPropertyChanged(); } }

        private string _OrderReceiedTag;
        public string OrderReceiedTag { get => _OrderReceiedTag; set { _OrderReceiedTag = value; OnPropertyChanged(); } }

        private double _OrderReceiedPercent;
        public double OrderReceiedPercent { get => _OrderReceiedPercent; set { _OrderReceiedPercent = value; OnPropertyChanged(); } }

        private double _TotalRevenuePercent;
        public double TotalRevenuePercent { get => _TotalRevenuePercent; set { _TotalRevenuePercent = value; OnPropertyChanged(); } }

        public SeriesCollection SalesValueCollection { get; set; }
        public string[] LabelMonth { get; set; }
        public Func<int, string> SalesY { get; set; }

        public ICommand ViewDetailCommand { get; set; }

        private OrderDetailViewModel orderDetailViewModel;

        public DashBoardViewModel()
        {
            ListOrders = new List<EpicorOrder>();

            APIHelper.InitializeClient();

            _ = LoadData();

            _ = HandleOrderReceived();

            _ = HandleTotalRevenue();

            AddAnalysic();

            ViewDetailCommand = new RelayCommand<Order>((p) => { return true; }, (OnRemoveSubject));

           

        }
        async private Task HandleOrderReceived()
        {
            var result = await DashBroadEndPoint.Ins.GetListOrder();

            ListOrders = result;

            int currentMonth = 2; //DateTime.Now.Month;
            int currentYear = 2018;//DateTime.Now.Year;
            int lastMonth = 1;//DateTime.Now.AddMonths(-1).Month;

            int indexCurrentMonth = (from a in result
                                     where Convert.ToDateTime(a.OrderDate).Month == currentMonth && Convert.ToDateTime(a.OrderDate).Year == currentYear
                                    select a).Count();

            int indexLastMonth = (from a in result
                                  where Convert.ToDateTime(a.OrderDate).Month == lastMonth && Convert.ToDateTime(a.OrderDate).Year == currentYear
                                    select a).Count();

            if (indexCurrentMonth >= indexLastMonth)
            {
                OrderReceiedTag = "Bigger";
                OrderReceived = indexCurrentMonth.ToString();
                OrderReceiedPercent = PercentageLikenLastMonth(indexCurrentMonth, indexLastMonth);

            }
            else
            {
                OrderReceiedTag = "Small";
                OrderReceived = indexCurrentMonth.ToString();
                OrderReceiedPercent = PercentageLikenLastMonth(indexCurrentMonth, indexLastMonth);
            }
            
           
            
        }

        async private Task HandleTotalRevenue()
        {
            TotalRevenue = "35,000";
            double totalRevenueCurrent = 10;
            double totalRevenueLastMonth = 5;
            if (totalRevenueCurrent >= totalRevenueLastMonth)
            {
                TotalRevenueTag = "Bigger";
                TotalRevenuePercent = PercentageLikenLastMonth(totalRevenueCurrent, totalRevenueLastMonth);
            }
            else
            {
                TotalRevenueTag = "Small";
                TotalRevenuePercent = PercentageLikenLastMonth(totalRevenueCurrent, totalRevenueLastMonth);
            }

        }

        private double PercentageLikenLastMonth(double indexCurrent, double indexLast)
        {
            double persen = (indexCurrent * 100) / indexLast;
            if (persen > 100)
                return persen;
            return 100 - persen;
            
        }
        private void AddAnalysic()
        {

            SalesValueCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "2018",
                    Values = new ChartValues<double> { 4, 56, 5, 2 ,90}
                },
                new LineSeries
                {
                    Title = "2019",
                    Values = new ChartValues<double> { 1, 7, 30, 40 }
                }
            };

            LabelMonth = TakeMonth(2,5);
            
            SalesY = value => value.ToString("D");

            SalesValueCollection.Add(new LineSeries
            {
                Title = "2020",
                Values = new ChartValues<double> { 5, 3, 2, 4,150},
                LineSmoothness = 0 
            });

            SalesValueCollection[1].Values.Add(5d);
        }

        private string[] TakeMonth(int value,int index)
        {
            // value = 9 = > 9 8 7 6 5 4
            string[] month = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "SEP", "Oct", "Nov", "Dec" };
            string[] temp = new string[index];

            for (int i = index; i > 0; i--)
            {
                if (value == 0)
                    value = 12;
                temp[i - 1] = month[--value];
            }
            return temp;
            
        }
        private void OnRemoveSubject(Order items)
        {
            orderDetailViewModel = new OrderDetailViewModel(items);

            WindownOrderDetail windown = new WindownOrderDetail();

            windown.DataContext = orderDetailViewModel;

            //orderDetailViewModel.Orders = items; // cũng hay như xàm lol

            windown.ShowDialog();

           


        }

        async private Task LoadData()
        {
            SalesOrdersResources = new ObservableCollection<Order>();

            var result = await DashBroadEndPoint.Ins.LoadOrders();
            
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
    }
}
