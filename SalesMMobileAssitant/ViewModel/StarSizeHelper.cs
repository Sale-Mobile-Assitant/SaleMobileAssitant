using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SalesMMobileAssitant.ViewModel
{
    public class StarSizeHelper
    {

        private static readonly List<FrameworkElement> s_knownElements = new List<FrameworkElement>();

        public static bool GetIsEnabled(DependencyObject d)
        {
            return (bool)d.GetValue(IsEnabledProperty);
        }

        public static void SetIsEnabled(ListView d, bool value)
        {
            d.SetValue(IsEnabledProperty, value);
        }

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled",
                                                typeof(bool),
                                                typeof(StarSizeHelper),
                                                new FrameworkPropertyMetadata(IsEnabledChanged));

        public static void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            var ctl = d as ListView;
            if (ctl == null)
            {
                throw new Exception("IsEnabled attached property only works on a ListView type");
            }

            RememberElement(ctl);
        }

        private static void RememberElement(ListView ctl)
        {

            if (!s_knownElements.Contains(ctl))
            {
                s_knownElements.Add(ctl);

                RegisterEvents(ctl);
            }
            // nothing to do if elt is known
        }

        private static void OnUnloaded(object sender, RoutedEventArgs e)
        {

            FrameworkElement ctl = (FrameworkElement)sender;
            ForgetControl(ctl);
        }

        private static void ForgetControl(FrameworkElement fe)
        {

            s_knownElements.Remove(fe);
            UnregisterEvents(fe);
        }

        private static void RegisterEvents(FrameworkElement fe)
        {
            fe.Unloaded += OnUnloaded;
            fe.SizeChanged += OnSizeChanged;
        }

        private static void UnregisterEvents(FrameworkElement fe)
        {
            fe.Unloaded -= OnUnloaded;
            fe.SizeChanged -= OnSizeChanged;
        }

        private static void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {

            ListView listView = sender as ListView;
            if (listView == null)
            {
                return; // should not happen
            }
            GridView gView = listView.View as GridView;
            if (gView == null)
            {
                return; // should not happen
            }

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth - 10; // take into account vertical scrollbar
            var colWidth = workingWidth / gView.Columns.Count;
            foreach (GridViewColumn column in gView.Columns)
            {
                column.Width = colWidth;
            }
        }
    }
}
