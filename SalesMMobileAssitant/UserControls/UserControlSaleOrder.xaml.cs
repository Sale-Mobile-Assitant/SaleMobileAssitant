using SalesMMobileAssitant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesMMobileAssitant.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlSaleOrder.xaml
    /// </summary>
    public partial class UserControlSaleOrder : UserControl
    {
       
        public UserControlSaleOrder()
        {
            InitializeComponent();

        }

        private void ListViewOrder_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth; // take into account vertical scrollbar
            var col2 = 0.09;
            var col3 = 0.07;
            var col4 = 0.1;
            var col5 = 0.09;
            var col6 = 0.12;
            var col7 = 0.12;
            var col8 = 0.12;
            var col9 = 0.12;
            var col10 = 0.12;
            var col1 = 0.05;


            gView.Columns[0].Width = workingWidth * col1;
            gView.Columns[1].Width = workingWidth * col2;
            gView.Columns[2].Width = workingWidth * col3;
            gView.Columns[3].Width = workingWidth * col4;
            gView.Columns[4].Width = workingWidth * col5;
            gView.Columns[5].Width = workingWidth * col6;
            gView.Columns[6].Width = workingWidth * col7;
            gView.Columns[7].Width = workingWidth * col8;
            gView.Columns[8].Width = workingWidth * col9;
            gView.Columns[9].Width = workingWidth * col10;
        }

    }
}
