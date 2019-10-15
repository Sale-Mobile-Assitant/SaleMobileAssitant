using Newtonsoft.Json;
using SalesMMobileAssitant.EndPoint;
using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model;
using SalesMMobileAssitant.Model.EpicorModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesMMobileAssitant.ViewModel
{
    public class SynsToEpicorOrderViewModel : BaseViewModel
    {
        public event EventHandler Close;
        private string mes = "";

        private ObservableCollection<ServiceOrder> _RoutePlans;
        public ObservableCollection<ServiceOrder> RoutePlans { get => _RoutePlans; set { _RoutePlans = value; OnPropertyChanged(); } }

        private bool _IsValidating;
        public bool IsValidating { get => _IsValidating; set { _IsValidating = value; OnPropertyChanged(); } }

        public StatusType statusVerifying { get; set; }
        public StatusType statusPending { get; set; }
        public StatusType statusCompleted { get; set; }
        public ObservableCollection<StatusType> listStatusTypes { get; set; }

        public SynsToEpicorOrderViewModel(ObservableCollection<ServiceOrder> item)
        {
            _ = Init();
            RoutePlans = item;
            _ = SynsToEpicor();
        }

        async private Task Init()
        {
            var resultStatusType = await GeneralMethods.Ins.GetDataFromDB<StatusType>("/api/StatusType/statusType");
            listStatusTypes = new ObservableCollection<StatusType>(resultStatusType);

            foreach (var item in listStatusTypes)
            {
                switch (item.STypeName)
                {
                    case "Verifying":
                        statusVerifying = new StatusType() { STypeID = item.STypeID, STypeName = item.STypeName };
                        break;
                    case "Pending":
                        statusPending = new StatusType() { STypeID = item.STypeID, STypeName = item.STypeName };
                        break;
                    case "Completed":
                        statusCompleted = new StatusType() { STypeID = item.STypeID, STypeName = item.STypeName };
                        break;
                    default:
                        break;
                }
            }
        }
        public async Task SynsToEpicor()
        {
            IsValidating = true;
            var result = RoutePlans.Where(p => p.IsSelected == true);

            foreach (var item in result)
            {
                if (Convert.ToInt32(item.OrderStatus) == statusVerifying.STypeID)
                {
                    EpicorOrder order = new EpicorOrder()
                    {
                        Company = item.CompID,
                        PONum = item.MyOrderID,
                        OrderNum = 0,
                        CustNum = item.CustID,
                        SalesRepCode1 = item.EmplID,
                        OrderDate = item.OrderDate,
                        NeedByDate = item.NeedByDate,
                        RequestDate = item.RequestDate
                    };
                    var responese = await GeneralMethods.Ins.PostDataToEpicor2<EpicorOrder>("/api/EpicorOrder", order);
                    var json = JsonConvert.DeserializeObject<EpicorOrderResponse>(responese);

                    #region Edit

                    Order orderEdit = new Order()
                    {
                        CompID = item.CompID,
                        MyOrderID = item.MyOrderID,
                        OrdeID = item.OrdeID,
                        CustID = item.CustID,
                        EmplID = item.EmplID,
                        OrderDate = item.OrderDate,
                        NeedByDate = item.NeedByDate,
                        RequestDate = item.RequestDate,
                        OrderStatus = "3",
                    };

                    if (await OrdersEndPoint.Ins.Put(orderEdit))
                    {
                        mes += "Edited";
                    }

                    #endregion

                    if (int.TryParse(responese, out int lol) == false)
                    {
                        mes += string.Format("Order ({0}) success - ", item.MyOrderID);
                        foreach (var _orderDetail in item.OrderDetail.OrderBy(p=>p.OrderLine))
                        {
                            EpicorOrderDetail orderDetail = new EpicorOrderDetail()
                            {
                                Company = _orderDetail.CompID,
                                POLine = _orderDetail.MyOrderID,
                                OrderNum = json.OrderNum,
                                OrderLine = _orderDetail.OrderLine,
                                PartNum = _orderDetail.ProdID,
                                SellingQuantity = _orderDetail.SellingQuantity,
                                DocDspUnitPrice = _orderDetail.UnitPrice,
                            };
                            if (await GeneralMethods.Ins.PostDataToEpicor<EpicorOrderDetail>("/api/EpicorOrderDetail", orderDetail))
                            {
                                mes += string.Format("[OrderDetail line({0}) success] - ", orderDetail.OrderLine);
                            }
                            else
                            {
                                mes += string.Format("An error occurred in OrderDetail({0}). please check again.\n", orderDetail.OrderLine);
                            }
                        }
                        mes += "\n";
                    }
                    else
                    {
                        mes += string.Format("An error occurred in order({0}). please check again.\n", item.MyOrderID);
                    }
                }
                else
                {
                    mes += item.MyOrderID + " have been syns!\n";
                }
            }


            MaterialMessageBox.Show(mes, "Message Box Title");

            await Task.Delay(1);

            Close?.Invoke(this, EventArgs.Empty);


        }
    }
}
