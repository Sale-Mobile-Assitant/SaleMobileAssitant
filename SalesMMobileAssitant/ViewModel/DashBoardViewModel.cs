using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Newtonsoft.Json;
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
using System.Windows.Media;

namespace SalesMMobileAssitant.ViewModel
{
    public class DashBoardViewModel : BaseViewModel
    {
      
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

        private string _ProductSold;
        public string ProductSold { get => _ProductSold; set { _ProductSold = value; OnPropertyChanged(); } }

        private string _ProductSoldTag;
        public string ProductSoldTag { get => _ProductSoldTag; set { _ProductSoldTag = value; OnPropertyChanged(); } }

        private double _ProductSoldPercent;
        public double ProductSoldPercent { get => _ProductSoldPercent; set { _ProductSoldPercent = value; OnPropertyChanged(); } }


        private string _CustomerName1;
        public string CustomerName1 { get => _CustomerName1; set { _CustomerName1 = value; OnPropertyChanged(); } }


        private string _CustomerName2;
        public string CustomerName2 { get => _CustomerName2; set { _CustomerName2 = value; OnPropertyChanged(); } }

        private string _CustomerName3;
        public string CustomerName3 { get => _CustomerName3; set { _CustomerName3 = value; OnPropertyChanged(); } }


        private string _CustomerName4;
        public string CustomerName4 { get => _CustomerName4; set { _CustomerName4 = value; OnPropertyChanged(); } }


        private string _CustomerName5;
        public string CustomerName5 { get => _CustomerName5; set { _CustomerName5 = value; OnPropertyChanged(); } }



        private string _Currency1;
        public string Currency1 { get => _Currency1; set { _Currency1 = value; OnPropertyChanged(); } }


        private string _Currency2;
        public string Currency2 { get => _Currency2; set { _Currency2 = value; OnPropertyChanged(); } }

        private string _Currency3;
        public string Currency3 { get => _Currency3; set { _Currency3 = value; OnPropertyChanged(); } }


        private string _Currency4;
        public string Currency4 { get => _Currency4; set { _Currency4 = value; OnPropertyChanged(); } }


        private string _Currency5;
        public string Currency5 { get => _Currency5; set { _Currency5 = value; OnPropertyChanged(); } }



        public List<Order> orderLastMonths { get; set; }

        public List<Order> orderCurrents { get; set; }
        public List<OrderDetail> orderDetails { get; set; }

        public List<ServiceCustomer> listCustomer { get; set; }

        public List<Order> listOrder { get; set; }
        public SeriesCollection SeriesCollection { get; set; }

        public SeriesCollection SalesValueCollection { get; set; }

        public SeriesCollection TopSaleManSeries { get; set; }
        public string[] LabelMonth { get; set; }
        public Func<int, string> SalesY { get; set; }

        public ICommand ViewDetailCommand { get; set; }
        public Func<ChartPoint, string> PointLabel { get; set; }
        public DashBoardViewModel()
        {
            APIHelper.InitializeClient();

            _ = Init();

            HandleOrderReceived();
        
            HandleTotalRevenue();

            HandleProductSold();

            _ = TopSaleMan();

            _ = TopProduct();

            TotleOrderReceived();

            TopCustomer();

        }
        async private Task Init()
        {
            listOrder = new List<Order>();
            listCustomer = new List<ServiceCustomer>();
            listOrder  = await GeneralMethods.Ins.GetDataFromDB<Order>("/api/Order/orders");

            
            listCustomer = await GeneralMethods.Ins.GetDataFromDB<ServiceCustomer>("/api/Customer/customers");

            orderCurrents = listOrder.Where(p => p.OrderDate.Value.Month.CompareTo(DateTime.Now.Month) == 0 && p.OrderDate.Value.Year.CompareTo(DateTime.Now.Year) == 0).ToList();
            orderLastMonths = listOrder.Where(p => p.OrderDate.Value.Month.CompareTo(DateTime.Now.AddMonths(-1).Month) == 0 && p.OrderDate.Value.Year.CompareTo(DateTime.Now.Year) == 0).ToList();
            orderDetails = listOrder.SelectMany(x => x.OrderDetail).ToList();

        }
        private void TopCustomer()
        {
            List<CustomerService> list = new List<CustomerService>();
            
            foreach (var item in listCustomer)
            {
                double total = 0;
                foreach (var item1 in item.Order)
                {
                    foreach (var item2 in item1.OrderDetail)
                    {
                        total += Convert.ToDouble(item2.UnitPrice) * Convert.ToDouble(item2.SellingQuantity);
                    }
                }
                CustomerService customerService = new CustomerService()
                {
                    ID = item.CustID,
                    Name = item.CustName,
                    Value = total
                };
                list.Add(customerService);
            }
            var listTopCustomer = list.OrderByDescending(p => p.Value).Take(5).ToList();
            for (int i = 0; i < listTopCustomer.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        CustomerName1 = listTopCustomer[i].Name;
                        Currency1 = listTopCustomer[i].Value.ToString();
                        break;
                    case 1:
                        CustomerName2 = listTopCustomer[i].Name;
                        Currency2 = listTopCustomer[i].Value.ToString();
                        break;
                    case 2:
                        CustomerName3 = listTopCustomer[i].Name;
                        Currency3 = listTopCustomer[i].Value.ToString();
                        break;
                    case 3:
                        CustomerName4 = listTopCustomer[i].Name;
                        Currency4 = listTopCustomer[i].Value.ToString();
                        break;
                    case 4:
                        CustomerName5 = listTopCustomer[i].Name;
                        Currency5 = listTopCustomer[i].Value.ToString();
                        break;
                    default:
                        break;
                }
            }

        }
        async private Task TopProduct()
        {
            var result = await GeneralMethods.Ins.GetDataFromDB<Product>("/api/Product/products");

            List<TopProduct> listProduct = new List<TopProduct>();
            foreach (var item in result)
            {
                TopProduct saleMan = new TopProduct()
                {
                    ID = item.ProdID,
                    Name = item.ProdName,
                    value = 0
                };
                listProduct.Add(saleMan);
            }

            foreach (var item in orderCurrents)
            {
                foreach (var item1 in listProduct)
                {
                    foreach (var item2 in item.OrderDetail)
                    {
                        if (item2.ProdID == item1.ID)
                        {
                            item1.value += 1;
                            break;
                        }
                    }
                }
            }
            var listTopProduct = listProduct.OrderByDescending(p => p.value).Take(5).ToList();
            SeriesCollection = new SeriesCollection();
           
            foreach (var item in listTopProduct)
            {
                if (item.value == 0)
                    continue;
                PieSeries pieSeries = new PieSeries()
                {
                    Title = item.Name,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(item.value) },
                    DataLabels = true
                };
                SeriesCollection.Add(pieSeries);
            }

        }

        async private Task TopSaleMan()
        {
            var result = await GeneralMethods.Ins.GetDataFromDB<Employee>("/api/Employee/employees");

            var listTopSaleMan = (from c in orderCurrents
                       join p in result
                       on c.EmplID equals p.EmplID
                       group new { c, p } by new { c.EmplID, p.EmplName }
                       into grp
                       select new { grp.Key.EmplName, Count = grp.Count() }).Take(5).ToList();

            TopSaleManSeries = new SeriesCollection();


            foreach (var item in listTopSaleMan)
            {
                if (item.Count == 0)
                    continue;
                PieSeries pieSeries = new PieSeries()
                {
                    Title = item.EmplName,
                    Values = new ChartValues<int> { item.Count },
                    LabelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation),
                    DataLabels = true
                };
                TopSaleManSeries.Add(pieSeries);
            }
            
        }
        private void HandleProductSold()
        {
            int countProductSoldLastMonth = 0;
            int countProductSoldCurrent = 0;
            if (orderCurrents != null && orderLastMonths != null)
            {
                foreach (var item in orderLastMonths)
                {
                    foreach (var item1 in item.OrderDetail)
                    {
                        countProductSoldLastMonth += 1;
                    }
                }
                foreach (var item in orderCurrents)
                {
                    foreach (var item1 in item.OrderDetail)
                    {
                        countProductSoldCurrent += 1;
                    }
                }
                ShowResult(countProductSoldCurrent, countProductSoldLastMonth, "ProductSold");
            }

        }
        private void HandleOrderReceived()
        {
            if (orderCurrents.Count > 0 && orderLastMonths.Count > 0)
                ShowResult(orderCurrents.Count, orderLastMonths.Count, "OrderReceived");

        }

        private void ShowResult(double current, double lastMonth,string key)
        {
            switch (key)
            {
                case "OrderReceived":
                    if (current >= lastMonth)
                    {
                        OrderReceiedTag = "Bigger";
                        OrderReceived = current.ToString();
                        OrderReceiedPercent = PercentageLikenLastMonth(current, lastMonth);

                    }
                    else
                    {
                        OrderReceiedTag = "Small";
                        OrderReceived = current.ToString();
                        OrderReceiedPercent = PercentageLikenLastMonth(current, lastMonth);
                    }
                    break;
                case "TotalRevenue":
                    if (current >= lastMonth)
                    {
                        TotalRevenueTag = "Bigger";
                        TotalRevenue = current.ToString();
                        TotalRevenuePercent = PercentageLikenLastMonth(current, lastMonth);

                    }
                    else
                    {
                        TotalRevenueTag = "Small";
                        TotalRevenue = current.ToString();
                        TotalRevenuePercent = PercentageLikenLastMonth(current, lastMonth);
                    }
                    break;
                case "ProductSold":
                    if (current >= lastMonth)
                    {
                        ProductSoldTag = "Bigger";
                        ProductSold = current.ToString();
                        ProductSoldPercent = PercentageLikenLastMonth(current, lastMonth);

                    }
                    else
                    {
                        ProductSoldTag = "Small";
                        ProductSold = current.ToString();
                        ProductSoldPercent = PercentageLikenLastMonth(current, lastMonth);
                    }
                    break;

                default:
                    break;
            }
           
        }

        private void HandleTotalRevenue()
        {
            double totalRevenueLastMonth = 0;
            double totalRevenueCurrent = 0;
            if (orderCurrents != null && orderLastMonths != null)
            {
                foreach (var item in orderLastMonths)
                {
                    foreach (var item1 in item.OrderDetail)
                    {
                        totalRevenueLastMonth += Convert.ToDouble(item1.UnitPrice) * Convert.ToDouble(item1.SellingQuantity);
                    }
                }
                foreach (var item in orderCurrents)
                {
                    foreach (var item1 in item.OrderDetail)
                    {
                        totalRevenueCurrent += Convert.ToDouble(item1.UnitPrice) * Convert.ToDouble(item1.SellingQuantity);
                    }
                }
                ShowResult(totalRevenueCurrent, totalRevenueLastMonth, "TotalRevenue");
            }
        }

        private double PercentageLikenLastMonth(double indexCurrent, double indexLast)
        {
            double persen = (indexCurrent * 100) / indexLast;
            if (persen > 100)
                return persen;
            return 100 - persen;
        }
        private void TotleOrderReceived()
        {
            var beforeLastYear = DateTime.Now.AddYears(-2).Year;
            var lastYear = DateTime.Now.AddYears(-1).Year;
            var current = DateTime.Now.Year;

            var orderBeforeLastYear = listOrder.Where(p => p.OrderDate.Value.Month <= DateTime.Now.Month && p.OrderDate.Value.Month >= DateTime.Now.AddMonths(-4).Month && p.OrderDate.Value.Year == beforeLastYear).ToList();
            var orderLastYear = listOrder.Where(p => p.OrderDate.Value.Month <= DateTime.Now.Month && p.OrderDate.Value.Month >= DateTime.Now.AddMonths(-4).Month && p.OrderDate.Value.Year == lastYear).ToList();
            var orderCurrent = listOrder.Where(p => p.OrderDate.Value.Month <= DateTime.Now.Month && p.OrderDate.Value.Month >= DateTime.Now.AddMonths(-4).Month && p.OrderDate.Value.Year == current).ToList();

            LineSeries lineBeforeLastYear = null, lineLastYear = null, lineCurrent = null;


            SalesValueCollection = new SeriesCollection();
            if (orderBeforeLastYear.Count <= 0)
            {
                lineBeforeLastYear = null;
            }
            if (orderLastYear.Count <= 0)
            {
                lineLastYear = null;
            }
            if (orderCurrent.Count <= 0)
            {
                lineCurrent = null;
            }

            if (orderBeforeLastYear.Count > 0)
            {
                lineBeforeLastYear = new LineSeries()
                {
                    Title = beforeLastYear.ToString(),
                    Values = new ChartValues<double>
                    {
                       //orderBeforeLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-4).Month).Count(),
                       //orderBeforeLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-3).Month).Count(),
                       //orderBeforeLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-2).Month).Count(),
                       //orderBeforeLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-1).Month).Count(),
                       //orderBeforeLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.Month).Count(),
                       orderBeforeLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-4).Month).Count(),
                       orderBeforeLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-3).Month).Count(),
                       orderBeforeLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-2).Month).Count(),
                       orderBeforeLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-1).Month).Count(),
                       orderBeforeLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.Month).Count(),
                    }
                };
            }
            if (orderLastYear.Count > 0)
            {
                lineLastYear = new LineSeries()
                {
                    Title = lastYear.ToString(),
                    Values = new ChartValues<double>
                    {
                       //orderLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-4).Month).Count(),
                       //orderLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-3).Month).Count(),
                       //orderLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-2).Month).Count(),
                       //orderLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-1).Month).Count(),
                       //orderLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.Month).Count(),
                       // orderLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-4).Month).Count(),
                       orderLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-3).Month).Count(),
                       orderLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-2).Month).Count(),
                       orderLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-1).Month).Count(),
                       orderLastYear.Where(p => p.OrderDate.Value.Month == DateTime.Now.Month).Count(),
                    }
                };
            }
            if (orderCurrent.Count > 0)
            {
                lineCurrent = new LineSeries()
                {
                    Title = current.ToString(),
                    Values = new ChartValues<double>
                    {
                       orderCurrent.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-4).Month).Count(),
                       orderCurrent.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-3).Month).Count(),
                       orderCurrent.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-2).Month).Count(),
                       orderCurrent.Where(p => p.OrderDate.Value.Month == DateTime.Now.AddMonths(-1).Month).Count(),
                       orderCurrent.Where(p => p.OrderDate.Value.Month == DateTime.Now.Month).Count(),
                    },
                    LineSmoothness = 0,
                };

            }
            LabelMonth = TakeMonth(DateTime.Now.Month, 5);
            SalesY = value => value.ToString("D");
            if (lineBeforeLastYear != null)
                SalesValueCollection.Add(lineBeforeLastYear);
            if (lineLastYear != null)
                SalesValueCollection.Add(lineLastYear);
            if (lineCurrent != null)
                SalesValueCollection.Add(lineCurrent);
     
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
      
    }
}
