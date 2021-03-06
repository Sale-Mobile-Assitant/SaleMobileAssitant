using SalesMMobileAssitant.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SalesMMobileAssitant.Helper
{
    public sealed class MaterialMessageBox
    {
        private const string MessageBoxTitle = "Message";

        public static void Show(string message, bool IsRTL = false)
        {
            using (var msg = new MessageBoxWindow())
            {
                msg.Title = MessageBoxTitle;
                msg.TxtTitle.Text = MessageBoxTitle;
                msg.TxtMessage.Text = message;
                msg.TitleBackgroundPanel.Background = new SolidColorBrush(Color.FromRgb(3, 169, 244));
                msg.BorderBrush = new SolidColorBrush(Color.FromRgb(3, 169, 244));
                msg.BtnCancel.Visibility = Visibility.Collapsed;
                if (IsRTL)
                {
                    msg.FlowDirection = FlowDirection.RightToLeft;
                }
                msg.BtnOk.Focus();
                msg.ShowDialog();
            }
        }

        public static void Show(string message, string title, bool IsRTL = false)
        {
            using (var msg = new MessageBoxWindow())
            {
                msg.Title = title;
                msg.TxtTitle.Text = title;
                msg.TxtMessage.Text = message;
                msg.TitleBackgroundPanel.Background = new SolidColorBrush(Color.FromRgb(3, 169, 244));
                msg.BorderBrush = new SolidColorBrush(Color.FromRgb(3, 169, 244));
                msg.BtnCancel.Visibility = Visibility.Collapsed;
                if (IsRTL)
                {
                    msg.FlowDirection = FlowDirection.RightToLeft;
                }
                msg.BtnOk.Focus();
                msg.ShowDialog();
            }
        }

        /// <summary>
        /// Displays an error message box
        /// </summary>
        /// <param name="errorMessage">The error error message to display</param>
        /// <param name="IsRTL">(Optional) If true the MessageBox FlowDirection will be RightToLeft</param>
        public static void ShowError(string errorMessage, bool IsRTL = false)
        {
            try
            {
                using (var msg = new MessageBoxWindow())
                {
                    msg.Title = "Error";
                    msg.TxtTitle.Text = "Error";
                    msg.TxtMessage.Text = errorMessage;
                    msg.TitleBackgroundPanel.Background = Brushes.Red;
                    msg.BorderBrush = Brushes.Red;
                    msg.BtnCancel.Visibility = Visibility.Collapsed;
                    if (IsRTL)
                    {
                        msg.FlowDirection = FlowDirection.RightToLeft;
                    }
                    msg.BtnOk.Focus();
                    msg.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(errorMessage);
            }
        }

        /// <summary>
        /// Displays an error message box
        /// </summary>
        /// <param name="errorMessage">The error error message to display</param>
        /// <param name="title">The title of the message box</param>
        /// <param name="IsRTL">(Optional) If true the MessageBox FlowDirection will be RightToLeft</param>
        public static void ShowError(string errorMessage, string title, bool IsRTL = false)
        {
            try
            {
                using (var msg = new MessageBoxWindow())
                {
                    msg.Title = title;
                    msg.TxtTitle.Text = title;
                    msg.TxtMessage.Text = errorMessage;
                    msg.TitleBackgroundPanel.Background = Brushes.Red;
                    msg.BorderBrush = Brushes.Red;
                    msg.BtnCancel.Visibility = Visibility.Collapsed;
                    if (IsRTL)
                    {
                        msg.FlowDirection = FlowDirection.RightToLeft;
                    }
                    msg.BtnOk.Focus();
                    msg.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(errorMessage);
            }
        }

      
        public static void ShowError(string errorMessage, string errorTitle)
        {
            try
            {
                using (var msg = new MessageBoxWindow())
                {
                    msg.Title = errorTitle;
                    msg.TxtTitle.Text = errorTitle;
                    msg.TxtMessage.Text = errorMessage;
                    msg.TitleBackgroundPanel.Background = Brushes.Red;
                    msg.BorderBrush = Brushes.Red;
                    msg.BtnCancel.Visibility = Visibility.Collapsed;

                    msg.BtnOk.Focus();
                    msg.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(errorMessage, errorTitle);
            }
        }

     
        public static void ShowWarning(string warningMessage)
        {
            try
            {
                using (var msg = new MessageBoxWindow())
                {
                    msg.Title = "Warning";
                    msg.TxtTitle.Text = "Warning";
                    msg.TxtMessage.Text = warningMessage;
                    msg.TitleBackgroundPanel.Background = Brushes.Orange;
                    msg.BorderBrush = Brushes.Orange;
                    msg.BtnCancel.Visibility = Visibility.Collapsed;

                    msg.BtnOk.Focus();
                    msg.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(warningMessage);
            }
        }

    
        public static void ShowWarning(string warningMessage, string warningTitle)
        {
            try
            {
                using (var msg = new MessageBoxWindow())
                {
                    msg.Title = warningTitle;
                    msg.TxtTitle.Text = warningTitle;
                    msg.TxtMessage.Text = warningMessage;
                    msg.TitleBackgroundPanel.Background = Brushes.Orange;
                    msg.BorderBrush = Brushes.Orange;
                    msg.BtnCancel.Visibility = Visibility.Collapsed;

                    msg.BtnOk.Focus();
                    msg.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(warningMessage, warningTitle);
            }
        }

     
        public static MessageBoxResult ShowWithCancel(string message, bool IsRTL = false)
        {
            try
            {
                using (var msg = new MessageBoxWindow())
                {
                    msg.Title = MessageBoxTitle;
                    msg.TxtTitle.Text = MessageBoxTitle;
                    msg.TxtMessage.Text = message;
                    msg.TitleBackgroundPanel.Background = new SolidColorBrush(Color.FromRgb(3, 169, 244));
                    msg.BorderBrush = new SolidColorBrush(Color.FromRgb(3, 169, 244));
                    if (IsRTL)
                    {
                        msg.FlowDirection = FlowDirection.RightToLeft;
                    }
                    msg.BtnOk.Focus();
                    msg.ShowDialog();
                    return msg.Result == MessageBoxResult.OK ? MessageBoxResult.OK : MessageBoxResult.Cancel;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(message);
                return MessageBoxResult.Cancel;
            }
        }

      
        public static MessageBoxResult ShowWithCancel(string message, string title, bool IsRTL = false)
        {
            try
            {
                using (var msg = new MessageBoxWindow())
                {
                    msg.Title = title;
                    msg.TxtTitle.Text = title;
                    msg.TxtMessage.Text = message;
                    msg.TitleBackgroundPanel.Background = new SolidColorBrush(Color.FromRgb(3, 169, 244));
                    msg.BorderBrush = new SolidColorBrush(Color.FromRgb(3, 169, 244));
                    if (IsRTL)
                    {
                        msg.FlowDirection = FlowDirection.RightToLeft;
                    }
                    msg.BtnOk.Focus();
                    msg.ShowDialog();
                    return msg.Result == MessageBoxResult.OK ? MessageBoxResult.OK : MessageBoxResult.Cancel;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(message);
                return MessageBoxResult.Cancel;
            }
        }

 
        public static MessageBoxResult ShowWithCancel(string message, bool isError, bool IsRTL = false)
        {
            try
            {
                using (var msg = new MessageBoxWindow())
                {
                    msg.Title = MessageBoxTitle;
                    msg.TxtTitle.Text = MessageBoxTitle;
                    msg.TxtMessage.Text = message;
                    msg.TitleBackgroundPanel.Background = isError
                        ? Brushes.Red
                        : new SolidColorBrush(Color.FromRgb(3, 169, 244));
                    msg.BorderBrush = isError
                        ? Brushes.Red
                        : new SolidColorBrush(Color.FromRgb(3, 169, 244));
                    if (IsRTL)
                    {
                        msg.FlowDirection = FlowDirection.RightToLeft;
                    }
                    msg.BtnOk.Focus();
                    msg.ShowDialog();
                    return msg.Result == MessageBoxResult.OK ? MessageBoxResult.OK : MessageBoxResult.Cancel;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(message);
                return MessageBoxResult.Cancel;
            }
        }

    }
}
