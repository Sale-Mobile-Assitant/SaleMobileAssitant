using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SalesMMobileAssitant.Helper
{
    public class ScrollViewFixer : ScrollViewer
    {
        public static DependencyProperty v_offsetProperty = DependencyProperty.Register("v_offset", typeof(double), typeof(ScrollViewFixer), new PropertyMetadata(new PropertyChangedCallback(OnVerticalChanged)));
        public static DependencyProperty h_offset = DependencyProperty.Register("h_offset", typeof(double), typeof(ScrollViewFixer), new PropertyMetadata(new PropertyChangedCallback(OnHorizontalChanged)));


        private static void OnVerticalChanged(DependencyObject ss_dependency, DependencyPropertyChangedEventArgs ss_evenargs)
        {
            ScrollViewFixer viewer = ss_dependency as ScrollViewFixer;
            viewer.ScrollToVerticalOffset((double)ss_evenargs.NewValue);
        }


        private static void OnHorizontalChanged(DependencyObject ss_dependency, DependencyPropertyChangedEventArgs ss_evenargs)
        {
            ScrollViewFixer viewer = ss_dependency as ScrollViewFixer;
            viewer.ScrollToHorizontalOffset((double)ss_evenargs.NewValue);
        }


        public double CurrentHorizontalOffset
        {
            get
            {
                return (double)this.GetValue(h_offset);
            }
            set
            {
                this.SetValue(h_offset, value);
            }
        }


        public double v_offset
        {
            get
            {
                return (double)this.GetValue(v_offsetProperty);
            }
            set
            {
                this.SetValue(v_offsetProperty, value);
            }

        }
    }
}
