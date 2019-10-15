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
using System.Windows.Input;

namespace SalesMMobileAssitant.ViewModel
{
    public class SettingViewModel : BaseViewModel
    {
        private string _Code;
        public string Code { get => _Code; set { _Code = value; OnPropertyChanged(); } }

        private string _UriApi;
        public string UriApi { get => _UriApi; set { _UriApi = value; OnPropertyChanged(); } }

        private string _FromOrderNum;
        public string FromOrderNum { get => _FromOrderNum; set { _FromOrderNum = value; OnPropertyChanged(); } }


        public OrderDetailLolModels ListOrderDetails { get; set; }
        private string _ToOrderNum;
        public string ToOrderNum { get => _ToOrderNum; set { _ToOrderNum = value; OnPropertyChanged(); } }


        public ICommand RetrieveCommand { get; set; }

        public ICommand TestConnectionCommand { get; set; }

        public ICommand DeleteOrderEpicorCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public SettingViewModel()
        {
            RetrieveCommand = new RelayCommand<object>((p) => 
            {
                if (p.ToString() == "VLXX")
                    return true;
                return false;
            }, (p)=> {
                UpdateDataToDatabase();
            });

            if (!string.IsNullOrEmpty(Properties.Settings.Default.URIAPI))
            {
                UriApi = Properties.Settings.Default.URIAPI;
            }

            TestConnectionCommand = new RelayCommand<object>((p) =>
            {
                if (!string.IsNullOrWhiteSpace(UriApi))
                    return true;
                return false;
            }, (p) => {
                string url = UriApi + "/api/Company/companies";
                TestConnection(url);
            });

            SaveCommand = new RelayCommand<object>((p) =>
            {
                if (!string.IsNullOrWhiteSpace(UriApi))
                    return true;
                return false;
            }, (p) => {
                SaveConnection();
            });

            DeleteOrderEpicorCommand = new RelayCommand<object>((p) =>
            {
                if (!string.IsNullOrWhiteSpace(FromOrderNum) && !string.IsNullOrWhiteSpace(ToOrderNum))
                    return true;
                return false;
            }, (p) => {
                _ = DeleteOrderEpicor();
            });
        }
       
        async private Task DeleteOrderEpicor()
        {
            var json = GeneralMethodEpicor.Ins.GetOrderDetail();
            ListOrderDetails = JsonConvert.DeserializeObject<OrderDetailLolModels>(json);
            var groups = ListOrderDetails.value.GroupBy(n => n.OrderNum)
               .Select(n => new
               {
                   OrderNum = n.Key,
                   Count = n.Count()
               }
            );

            string mes = "";
            int from = Convert.ToInt32(FromOrderNum);
            int to = Convert.ToInt32(ToOrderNum);
            for (int i = from; i < to; i++)
            {
                mes += "Order[" + i + "].OrderDetail[";
                int line = groups.Where(p => p.OrderNum == i).Select(a => a.Count).FirstOrDefault();
                for (int j = 1; j <= line; j++)
                {
                    if (await GeneralMethodEpicor.Ins.DeleteOrderDetail(i, j))
                        mes += "Done,";
                    else
                        mes += "Error,";
                }

                if (await GeneralMethodEpicor.Ins.DeleteOrder(i) == true)
                {
                    mes += "] - Success";
                }
                else
                {
                    mes += "] - Failed";
                }
                mes += "\n";
            }
            MaterialMessageBox.Show(mes);
        }
        private void SaveConnection()
        {
            if (!string.IsNullOrEmpty(UriApi))
            {
                Properties.Settings.Default.URIAPI = UriApi;
                Properties.Settings.Default.Save();
                MaterialMessageBox.Show("Save succeeded");
            }
        }
        private void TestConnection(string url)
        {
            if (GeneralMethods.Ins.TestConection(url) == true)
            {
                MaterialMessageBox.Show("Test connection succeeded");
            }
            else
            {
                MaterialMessageBox.Show("Test connection failed");
            }
        }

        private void UpdateDataToDatabase()
        {
            //_ = UpdateDataCompany(); // done 
            //_ = UpdateDataProductGroup(); // hone
            //_ = UpdateDataProduct(); // done
            //_ = UpdateDataSite(); // done


            //_ = UpdateDataEmployessType(); // done
            //_ = UpdateDataEmployess(); // done
            //_ = UpdateDataCustomer(); // done


            //_ = UpdateDataProductInSite(); // done
            //_ = UpdateDataOrders();
            //_ = UpdateDataOrderDetail();
        }
        async private Task UpdateDataCompany()
        {
            var result = await CompanyEndPoint.Ins.GetCompanyFromEpicor();

            Company company = new Company()
            {
                CompID = result.Company1,
                CompName = result.Name,
                Address1 = result.Address1,
                Address2 = result.Address2,
                Address3 = result.Address3,
                City = result.City,
                Province = result.Country,
                PhoneNum = result.PhoneNum,
            };

            if (await CompanyEndPoint.Ins.PostCompanyToDB(company) == true)
            {
                MessageBox.Show("Thành Công");
            }
        }
        async private Task UpdateDataProduct()
        {
            var result = await GeneralMethods.Ins.GetDataFromEpicor<EpicorProduct>("/api/EpicorProduct/Products");
            string mes = "";
            foreach (var item in result)
            {
                Product product = new Product()
                {
                    CompID = item.Company,
                    PGroupID = item.ProdCode,
                    ProdID = item.PartNum,
                    ProdName = item.PartDescription,
                    UnitPrice = item.UnitPrice,
                    UOM = item.IUM,
                    DateUpdate = DateTime.Now,

                };
                if (await GeneralMethods.Ins.PostDataToDB("/api/Product", product) == true)
                {
                    mes += "1";
                }
                else
                {
                    mes += "0";
                }
            }

            MessageBox.Show(mes);


        }
        async private Task UpdateDataProductGroup()
        {
            var result = await GeneralMethods.Ins.GetDataFromEpicor<EpicorProductGroup>("/api/EpicorProductGroup/productgroups");
            string mes = "";
            foreach (var item in result)
            {
                ProductGroup productGroup = new ProductGroup()
                {
                    CompID = item.Company,
                    PGroupID = item.ProdCode,
                    PGdescription = item.Description,
                };
                if (await GeneralMethods.Ins.PostDataToDB("/api/ProductGroup", productGroup) == true)
                {
                    mes += "1";
                }
                else
                {
                    mes += "0";
                }
            }

            MessageBox.Show(mes);
        }
        async private Task UpdateDataSite()
        {
            var result = await GeneralMethods.Ins.GetDataFromEpicor<EpicorSite>("/api/Epicorsite/sites");

            string mes = "";

            foreach (var item in result)
            {
                Site site = new Site()
                {
                    CompID = item.Company,
                    SiteID = item.Plant1,
                    SiteName = item.Name,
                    Address1 = item.Address1,
                    Address2 = item.Address2,
                    Address3 = item.Address3,
                    City = item.City,
                    Province = item.State,
                    PhoneNum = item.PhoneNum,
                };
                if (await GeneralMethods.Ins.PostDataToDB("/api/Site", site) == true)
                {
                    mes += "1";
                }
                else
                {
                    mes += "0";
                }
            }

            MessageBox.Show(mes);
        }


        async private Task UpdateDataEmployessType()
        {
            var result = await GeneralMethods.Ins.GetDataFromEpicor<EpicorEmployeeType>("/api/Epicoremployeetype/employeestypies");

            string mes = "";

            foreach (var item in result)
            {
                EmployeeType value = new EmployeeType()
                {
                    CompID = item.Company,
                    ETypeID = item.RoleCode,
                    Commissionable = item.Commissionable,
                    ETypeDescription = item.RoleDescription,
                    
                };
                if (await GeneralMethods.Ins.PostDataToDB("/api/EmployeeType", value) == true)
                {
                    mes += "1";
                }
                else
                {
                    mes += "0";
                }
            }

            MessageBox.Show(mes);
        }
        async private Task UpdateDataEmployess()
        {
            var result = await GeneralMethods.Ins.GetDataFromEpicor<EpicorEmployee>("/api/Epicoremployees/employeestypies");

            string mes = "";

            foreach (var item in result)
            {
                Employee value = new Employee()
                {
                    CompID = item.Company,
                    ETypeID = item.RoleCode,
                    EmplID   = item.SalesRepCode,
                    EmplName = item.Name,
                    Address1 = item.Address1,
                    Address2 = item.Address2,
                    Address3 = item.Address3,
                    PhoneNum = item.CellPhoneNum,
                    DateIn = DateTime.Now,
                    DateOut = DateTime.Now,
                };
                if (await GeneralMethods.Ins.PostDataToDB("/api/Employee", value) == true)
                {
                    mes += "1";
                }
                else
                {
                    mes += "0";
                }
            }

            MessageBox.Show(mes);
        }
        async private Task UpdateDataCustomer()
        {
            var result = await GeneralMethods.Ins.GetDataFromEpicor<EpicorCustomer>("/api/EpicorCustomer/Customers");

            string mes = "";

            foreach (var item in result)
            {
                Customer value = new Customer()
                {
                    CompID = item.Company,
                    EmplID = item.SalesRepCode,
                    CustID = item.CustNum.ToString(),
                    CustName = item.Name,
                    Address1 = item.Address1,
                    Address2 = item.Address2,
                    Address3 = item.Address3,
                    City = item.City,
                    Country = item.Country,
                    PhoneNum = item.PhoneNum,
                    Discount = item.DiscountPercent,

                };
                if (await GeneralMethods.Ins.PostDataToDB("/api/Customer", value) == true)
                {
                    mes += "1";
                }
                else
                {
                    mes += "0";
                }
            }

            MessageBox.Show(mes);
        }
        async private Task UpdateDataProductInSite()
        {
            var result = await GeneralMethods.Ins.GetDataFromEpicor<EpicorProductInSite>("/api/Epicorinsite/productinsites");

            string mes = "";

            foreach (var item in result)
            {
                ProductInSite value = new ProductInSite()
                {
                    CompID = item.Company,
                    SiteID = item.Plant,
                    ProdID = item.PartNum,
                    Quantity = 0,

                };
                if (await GeneralMethods.Ins.PostDataToDB("/api/ProductInSite", value) == true)
                {
                    mes += "1";
                }
                else
                {
                    mes += "0";
                }
            }

            MessageBox.Show(mes);
        }
        async private Task UpdateDataOrders()
        {
            var result = await GeneralMethods.Ins.GetDataFromEpicor<EpicorOrder>("/api/EpicorOrder/Orders");
           
            string mes = "";

            foreach (var item in result)
            {
                Order value = new Order()
                {
                    CompID = item.Company,
                    MyOrderID = item.PONum,
                    OrdeID = item.OrderNum,
                    CustID = item.CustNum,
                    EmplID = item.SalesRepCode1,
                    OrderDate = item.OrderDate,
                    NeedByDate = item.NeedByDate,
                    RequestDate = item.RequestDate
                };
                if (await GeneralMethods.Ins.PostDataToDB("/api/Order", value) == true)
                {
                    mes += "1";
                }
                else
                {
                    mes += "0";
                }
            }

            MessageBox.Show(mes);
        }
        async private Task UpdateDataOrderDetail()
        {
            var result = await GeneralMethods.Ins.GetDataFromEpicor<EpicorOrderDetail>("/api/EpicorOrderDetail/Orders");

            string mes = "";

            foreach (var item in result)
            {
                OrderDetail value = new OrderDetail()
                {
                    CompID = item.Company,
                    SiteID = "MFGCYS",
                    MyOrderID = item.POLine,
                    ProdID = item.PartNum,
                    SellingQuantity = item.SellingQuantity,
                    UnitPrice = item.DocDspUnitPrice,
                    OrderNum = item.OrderNum,
                    OrderLine = item.OrderLine,
                    LineType = item.LineType,
                };
                if (await GeneralMethods.Ins.PostDataToDB("/api/OrderDetail", value) == true)
                {
                    mes += "1";
                }
                else
                {
                    mes += "0";
                }
            }

            MessageBox.Show(mes);
        }
    }
}
