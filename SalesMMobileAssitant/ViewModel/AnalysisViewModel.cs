using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.ViewModel
{
    public class AnalysisViewModel
    {
        public SeriesCollection SalesValueCollection { get; set; }
        public string[] LabelMonth { get; set; }
        public Func<double, string> SalesY { get; set; }

        public SeriesCollection SalesManCollection { get; set; }
        public string[] SalesmanName { get; set; }
        public Func<double, string> SoldApps { get; set; }
        public AnalysisViewModel()
        {
            SalesValueCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "2018",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,7}
                },
                new LineSeries
                {
                    Title = "2019",
                    Values = new ChartValues<double> { 1, 7, 3, 4,15 }
                }
            };

            LabelMonth = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
            SalesY = value => value.ToString("C");

            //modifying the series collection will animate and update the chart
            SalesValueCollection.Add(new LineSeries
            {
                Title = "2020",
                Values = new ChartValues<double> { 5, 3, 2, 4 },
                LineSmoothness = 0 //straight lines, 1 really smooth lines
            });

            //modifying any series values will also animate and update the chart
            SalesValueCollection[2].Values.Add(45d);


            // --------------

            SalesManCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 12,12 }
                }
            };

            //adding series will update and animate the chart automatically
            SalesManCollection.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 23}
            });

            //also adding values updates and animates the chart automatically
            SalesManCollection[1].Values.Add(18d);

            SalesmanName = new[] { "Maria", "Susan", "Charles" };
            SoldApps = value => value.ToString("N");


        }
    }
}
