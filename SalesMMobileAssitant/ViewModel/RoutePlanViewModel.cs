using MaterialDesignThemes.Wpf;
using SalesMMobileAssitant.Controller;
using SalesMMobileAssitant.EndPoint;
using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SalesMMobileAssitant.ViewModel
{
    public class RoutePlanViewModel : BaseViewModel
    {
        #region Poperties

        private ObservableCollection<RoutePlan> _RoutePlanResources;
        public ObservableCollection<RoutePlan> RoutePlanResources { get => _RoutePlanResources; set { _RoutePlanResources = value; OnPropertyChanged(); } }


        #endregion

        private const string DialogIdentifier = "RootDialogHost";

      
        private string _SelectedPageNumber;
        public string SelectedPageNumber { get => _SelectedPageNumber; set { _SelectedPageNumber = value; OnPropertyChanged(); } }


        private string _Showing;
        public string Showing { get => _Showing; set { _Showing = value; OnPropertyChanged(); } }


        public IList<string> ListYear { get; set; }
        public IList<string> PageSizes { get; set; }

        public IList<Month> ListMonth { get; set; }

        
        public string SelectedPageSize { get; set; }
        

        private ObservableCollection<ItemPage> _ItemPageNumber;
        public ObservableCollection<ItemPage> ItemPageNumber { get => _ItemPageNumber; set { _ItemPageNumber = value; OnPropertyChanged(); } }

        private string _SelectedMonth;
        public string SelectedMonth { get => _SelectedMonth; set { _SelectedMonth = value; OnPropertyChanged(); } }

     

        private string _SelectedYear;
        public string SelectedYear { get => _SelectedYear; set { _SelectedYear = value; OnPropertyChanged(); } }

        private int pageNumber;
        private int numberRecord;
        private int totalRecord;
        private int totalPage;

        //List<RoutePlan> routePlans;

        private ObservableCollection<RoutePlan> _routePlans;
        public ObservableCollection<RoutePlan> routePlans { get => _routePlans; set { _routePlans = value; OnPropertyChanged(); } }

   

        public ICommand NewRoutePlancommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ICommand SelectionChangedCommand { get; set; }

        public ICommand SelectionChangedPageNumberCommand { get; set; }

        public ICommand NextCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        public ICommand LastCommand { get; set; }
        public ICommand FirstCommand { get; set; }

        public ICommand ShowDialogCommand { get; set; }

        public ICommand DeleteCommand { get; set; }


        public ICommand SelectionChangedMonthCommand { get; set; }


        public ICommand SelectionChangedYearCommand { get; set; }

        public RoutePlanViewModel()
        {
            PageSizes = GetAllPageSize();
            ListMonth = AddMonth();
            ListYear = AddYear();
            SelectedMonth = DateTime.Now.Month.ToString();
            SelectedYear = DateTime.Now.Year.ToString();
            SelectedPageSize = "10";
            numberRecord = Convert.ToInt32(SelectedPageSize);
            //LoadDadfta();
            _ = LoadData(DateTime.Now.Month,DateTime.Now.Year);

            RoutePlanResources = new ObservableCollection<RoutePlan>(LoadRecord(pageNumber, numberRecord));


            SelectionChangedMonthCommand = new RelayCommand<object>((p)=> { return true; },(p)=> {
                _ = LoadData(Convert.ToInt32(SelectedMonth),Convert.ToInt32(SelectedYear));
                RoutePlanResources = new ObservableCollection<RoutePlan>(LoadRecord(pageNumber, numberRecord));
                TotalPages();
            });


            SelectionChangedYearCommand = new RelayCommand<object> ((p) => { return true; }, (p) => {
                _ = LoadData(Convert.ToInt32(SelectedMonth), Convert.ToInt32(SelectedYear));
                RoutePlanResources = new ObservableCollection<RoutePlan>(LoadRecord(pageNumber, numberRecord));
                TotalPages();
            }
            );

            //RoutePlanResources = new ObservableCollection<RoutePlan>(LoadRecord(pageNumber, numberRecord));


            // lấy số record trong trang
            SelectionChangedCommand = new RelayCommand<object>((p)=> { return true; },(p)=> {
               
                numberRecord = Convert.ToInt32(SelectedPageSize);
                RoutePlanResources = new ObservableCollection<RoutePlan>(LoadRecord(pageNumber, numberRecord));
                TotalPages();
                
            });

           
            SelectionChangedPageNumberCommand = new RelayCommand<object>((p)=> { return true; },(p)=> {
                RoutePlanResources = new ObservableCollection<RoutePlan>(LoadRecord(Convert.ToInt32(SelectedPageNumber) + 1, numberRecord));
                pageNumber = Convert.ToInt32(SelectedPageNumber);
                Showing = string.Format("Showing {0} to {1} of {2} entries", pageNumber + 1, totalPage, totalRecord);

            });

            ChangePage();
            // Showing 1 to 10 of 36 entries


            #region lol


            ShowDialogCommand = new RelayCommand<object>((p) => { return true; }, (OnShowDialog));

            EditCommand = new RelayCommand<RoutePlan>((p) => { return true; }, (OnShowEditDialog));
            DeleteCommand = new RelayCommand<RoutePlan>((p) => { return true; }, (DeleteRoutePlan));

           
            #endregion

        }
      

        private void DeleteRoutePlan(RoutePlan items)
        {
            _ = Delete(items);
        }

        async private Task Delete(RoutePlan items)
        {
            if (await RoutePlanEndPoint.Ins.Delete(items.CompID, items.EmplID, items.CustID, items.DatePlan.ToString("yyyy-MM-dd")))
            {
                MaterialMessageBox.Show("Delete Success");
                RoutePlanResources.Remove(items);
                routePlans.Remove(items);
                totalRecord = routePlans.Count;
                TotalPages();
            }
            else
                MaterialMessageBox.Show("Delete Failed");

        }
       
        async private Task LoadData(int month,int year)
        {
            var result = await GeneralMethods.Ins.GetDataFromDB<RoutePlan>("/api/RoutePlan/routeplans");
            var resultByMonth = result.Where(p => p.DatePlan.Month.CompareTo(month) == 0 & p.DatePlan.Year.CompareTo(year) == 0);
            routePlans = new ObservableCollection<RoutePlan>(resultByMonth);
            totalRecord = routePlans.Count;
        }

        private void LoadDadfta()
        {
            routePlans = new ObservableCollection<RoutePlan>();

            for (int i = 0; i < 102; i++)
            {
                if (i / 2 != 14)
                {
                    routePlans.Add(new RoutePlan() { EmplID = "NG", CustID = 2, DatePlan = DateTime.Now.Date, Prioritize = i, Visited = true, Note = "Ghi cai lol gi" });

                }
                else
                    routePlans.Add(new RoutePlan() { EmplID = "NG", CustID = 1, DatePlan = DateTime.Now.Date, Prioritize = i, Visited = true, Note = "Ghi cai lol gi" });

            }
            totalRecord = routePlans.Count;
        }

        private List<RoutePlan> LoadRecord(int page,int recordNum)
        {
            List<RoutePlan> result = new List<RoutePlan>();
            result = routePlans.Skip((page - 1) * recordNum).Take(recordNum).ToList();

            return result;
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
                RoutePlanResources = new ObservableCollection<RoutePlan>(LoadRecord(pageNumber, numberRecord));
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
                RoutePlanResources = new ObservableCollection<RoutePlan>(LoadRecord(pageNumber, numberRecord));
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
                RoutePlanResources = new ObservableCollection<RoutePlan>(LoadRecord(pageNumber, numberRecord));
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


        private void TotalPages()
        {
            ItemPageNumber = new ObservableCollection<ItemPage>();
            var Result = decimal.Divide(totalRecord, numberRecord);
            totalPage = Convert.ToInt32(Math.Ceiling(Result));
            SelectedPageNumber = "0";
            for (int i = 1; i <=  totalPage ; i++)
            {
                if (i <= 5)
                    ItemPageNumber.Add(new ItemPage() { Name = i.ToString() , IsActive = true, Uid = i.ToString() });
                else
                    ItemPageNumber.Add(new ItemPage() { Name = i.ToString(), IsActive = false, Uid = i.ToString() });
            }
            if (ItemPageNumber.Count == 0)
                ItemPageNumber.Add(new ItemPage() { Name = "1", IsActive = true, Uid = "1" });
        }
        private void PageNumber(double size,int recordCount)
        {
            ItemPageNumber = new ObservableCollection<ItemPage>();

            if (size >= recordCount)
                ItemPageNumber.Add(new ItemPage() { Name = "1", IsActive = true, Uid = "1"});
            else
            {
                double resultDouble = (recordCount / size);
                int resultInt = Convert.ToInt32(recordCount / size);
                int pageNumber;
                if (resultDouble == resultInt)
                {
                    pageNumber = resultInt;
                }

                pageNumber = resultInt + 1;


                for (int i = 1; i <= pageNumber; i++)
                {
                    if (i > 5)
                    {
                        ItemPageNumber.Add(new ItemPage() { Name = i.ToString(), IsActive = false, Uid = i.ToString() });
                    }
                    else
                    {
                        ItemPageNumber.Add(new ItemPage() { Name = i.ToString(), IsActive = true, Uid = i.ToString() });
                    }
                }
            }
         


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
        private IList<Month> AddMonth()
        {
            IList<Month> listMonth = new List<Month>();
            listMonth.Add(new Month() { NumberMonth = 1,TextMonth = "January" });
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
        public string CompID { get; set; }
        private async void OnShowDialog(object lol)
        {
            var viewModel = new RoutePlanDialogViewModel();

            await DialogHost.Show(viewModel, (object sender, DialogOpenedEventArgs e) =>
            {
                void OnClose(object _, EventArgs args)
                {
                    viewModel.Close -= OnClose;
                    e.Session.Close();
                }
                viewModel.Close += OnClose;
                
            });
            _ = LoadData(DateTime.Now.Month, DateTime.Now.Year);

            RoutePlanResources = new ObservableCollection<RoutePlan>(LoadRecord(pageNumber, numberRecord));
        }

        private async void OnShowEditDialog(RoutePlan routePlan)
        {
            var viewModel = new RoutePlanDialogEditViewModel(routePlan);

            await DialogHost.Show(viewModel, (object sender, DialogOpenedEventArgs e) =>
            {
                void OnClose(object _, EventArgs args)
                {
                    viewModel.Close -= OnClose;
                    e.Session.Close();
                }
                viewModel.Close += OnClose;
               
            });
            _ = LoadData(Convert.ToInt32(SelectedMonth), Convert.ToInt32(SelectedYear));
            RoutePlanResources = new ObservableCollection<RoutePlan>(LoadRecord(pageNumber, numberRecord));
        }
    }
}
