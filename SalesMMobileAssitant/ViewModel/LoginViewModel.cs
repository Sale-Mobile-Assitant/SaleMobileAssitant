using SalesMMobileAssitant.EndPoint;
using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SalesMMobileAssitant.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private bool _IsDefaultSave;
        public bool IsDefaultSave
        {
            get { return _IsDefaultSave; }
            set
            {
                if (_IsDefaultSave == value)
                    return;
                _IsDefaultSave = value;
                OnPropertyChanged();
            }
        }

        private bool _IsChecked;
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                if (_IsChecked == value)
                    return;
                _IsChecked = value;
                OnPropertyChanged();
            }
        }

        private string _VisibilityLogin;
        public string VisibilityLogin { get => _VisibilityLogin; set { _VisibilityLogin = value; OnPropertyChanged(); } }

        private string _VisibilityURL;
        public string VisibilityURL { get => _VisibilityURL; set { _VisibilityURL = value; OnPropertyChanged(); } }

        private string _UriApi;
        public string UriApi { get => _UriApi; set { _UriApi = value; OnPropertyChanged(); } }

        public List<Account> listAccount { get; set; }
        public ICommand LoginCommand { get; set; }

        public ICommand CloseCommand { get; set; }
        public ICommand SwitchCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand TestConnectionCommand { get; set; }

        public ICommand PasswordChangedCommand { get; set; }
        public LoginViewModel()
        {

            APIHelper.InitializeClient();
            VisibilityURL = "Hidden";
            IsDefaultSave = false;
            Password = "";
            UserName = "";
            RestoreData();

            _ = Init();

            SwitchCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Switch();
            });
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

            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                p.Close();
            });

            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                Login(p);
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });

        }
        private void TestConnection(string url)
        {
            if (GeneralMethods.Ins.TestConection(url) == true)
            {
                IsDefaultSave = true;
                MaterialMessageBox.Show("Test connection succeeded");
            }
            else
            {
                MaterialMessageBox.Show("Test connection failed");
            }
        }
        async private Task Init()
        {
            listAccount = new List<Account>();

            listAccount = await GeneralMethods.Ins.GetDataFromDB<Account>("/api/AccountDB/accountdb");

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
        private void Switch()
        {
            if (VisibilityURL == "Visible")
            {
                VisibilityURL = "Hidden";
                VisibilityLogin = "Visible";
            }
            else
            {
                VisibilityURL = "Visible";
                VisibilityLogin = "Hidden";
            }
        }
        private void Login(Window p)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.URIAPI))
            {
                MaterialMessageBox.Show("Failed to load, please try URL");
                return;
            }
            if (p == null)
                return;

            bool isSuccess = false;
            if (listAccount == null)
            {
                // chi đc đang nhập khi trông list trong có account
                if (UserName == "Admin" && Password == "123")
                {
                    isSuccess = true;
                }
            }
            else
            {
                foreach (var item in listAccount)
                {
                    if (UserName == item.Username && Password == item.Password)
                    {
                        isSuccess = true;
                        break;
                    }
                }
            }

            if (isSuccess == true)
            {
                MainWindow window = new MainWindow();
                window.Show();
                p.Close();
            }
            else
            {
                MaterialMessageBox.Show("Incorrect password or account");
            }


        }

        private void RestoreData()
        {
            if (Properties.Settings.Default.URIAPI != string.Empty)
            {
                UriApi = Properties.Settings.Default.URIAPI;
            }
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                if (Properties.Settings.Default.RemenberMe == "yes")
                {
                    UserName = Properties.Settings.Default.UserName;
                    Password = Properties.Settings.Default.Password;
                }
                else
                {
                    UserName = Properties.Settings.Default.UserName;
                }
            }
        }
    }
}
