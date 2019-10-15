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
    public class OrderDetailViewModel : BaseViewModel
    {
        private Order _Orders;
        public Order Orders { get => _Orders; set { _Orders = value; OnPropertyChanged(); } }

        private string _MyOrderID;
        public string MyOrderID { get => _MyOrderID; set { _MyOrderID = value; OnPropertyChanged(); } }

        private int _OrdeID;
        public int OrdeID { get => _OrdeID; set { _OrdeID = value; OnPropertyChanged(); } }

        private string _CustID;
        public string CustID { get => _CustID; set { _CustID = value; OnPropertyChanged(); } }

        private string _EmplID;
        public string EmplID { get => _EmplID; set { _EmplID = value; OnPropertyChanged(); } }

        private DateTime? _OrderDate;
        public DateTime? OrderDate { get => _OrderDate; set { _OrderDate = value; OnPropertyChanged(); } }

        private DateTime? _NeedByDate;
        public DateTime? NeedByDate { get => _NeedByDate; set { _NeedByDate = value; OnPropertyChanged(); } }

        private DateTime? _RequestDate;
        public DateTime? RequestDate { get => _RequestDate; set { _RequestDate = value; OnPropertyChanged(); } }

        private string _OrderStatus;
        public string OrderStatus { get => _OrderStatus; set { _OrderStatus = value; OnPropertyChanged(); } }

        private string _SiteID;
        public string SiteID { get => _SiteID; set { _SiteID = value; OnPropertyChanged(); } }

        private string _ProdID;
        public string ProdID { get => _ProdID; set { _ProdID = value; OnPropertyChanged(); } }

        private string _SellingQuantity;
        public string SellingQuantity { get => _SellingQuantity; set { _SellingQuantity = value; OnPropertyChanged(); } }

        private string _UnitPrice;
        public string UnitPrice { get => _UnitPrice; set { _UnitPrice = value; OnPropertyChanged(); } }

        private ObservableCollection<OrderDetail> _OrderDetilResource;
        public ObservableCollection<OrderDetail> OrderDetilResource { get => _OrderDetilResource; set { _OrderDetilResource = value; OnPropertyChanged(); } }

        public ICommand LoadedCommand { get; set; }
        public OrderDetailViewModel(Order orders)
        {
            OrderDetilResource = new ObservableCollection<OrderDetail>();
            LoadedCommand = new RelayCommand<object>((p)=> { return true; },(p)=> {
                LoadData(orders);
            });
         

        }
        private void LoadData(Order orders)
        {
            Orders = orders;

            MyOrderID = Orders.MyOrderID;
            OrdeID = Orders.OrdeID;
            CustID = Orders.CustID;
            EmplID = Orders.EmplID;
            OrderDate = Orders.OrderDate;
            NeedByDate = Orders.NeedByDate;
            RequestDate = Orders.RequestDate;
            OrderStatus = Orders.OrderStatus;


            foreach (var item in Orders.OrderDetail)
            {
                
                OrderDetail orderDetail = new OrderDetail()
                {
                    SiteID = item.SiteID,
                    MyOrderID = item.MyOrderID,
                    ProdID = item.ProdID,
                    SellingQuantity = item.SellingQuantity,
                    UnitPrice = item.UnitPrice,
                    OrderLine = item.OrderLine,
                    OrderNum = item.OrderNum,
                    
                };
                OrderDetilResource.Add(orderDetail);
            }
        }
    }
}
