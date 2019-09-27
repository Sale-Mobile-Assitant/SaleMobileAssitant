using System;
using System.Collections.Generic;
using System.Linq;
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

        public ICommand LoginCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand PasswordChangedCommand { get; set; }
        public LoginViewModel()
        {
            Password = "";
            UserName = "";
            RestoreData();
            CloseCommand = new RelayCommand<Window>((p) => { return true; },(p)=> {
                p.Close();
            });

            LoginCommand = new RelayCommand<Window>((p) => { return true; },(p)=> {
                Login(p);
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });

        }
        private void Login(Window p)
        {
            if (p == null)
                return;

            if (UserName == "Admin" && Password == "1")
            {
                MessageBox.Show("THành công");
                RemeberMeData();
            }
            else
            {
                MessageBox.Show("lol");
            }
          
        }

        private void RestoreData()
        {
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
        private void RemeberMeData()
        {
            if (IsChecked)
            {
                Properties.Settings.Default.UserName = UserName;
                Properties.Settings.Default.Password = Password;
                Properties.Settings.Default.RemenberMe = "yes";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = UserName;
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.RemenberMe = "no";
                Properties.Settings.Default.Save();
            }
        }

    }
}
