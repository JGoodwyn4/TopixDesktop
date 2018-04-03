using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TopixApp
{
    // Figured this class would contain methods that are the same over different pages (ie. the horizontal scrolling event)

    public class GlobalMethodResource
    {

        public static void HorizontalScrollEvent(object sender, MouseWheelEventArgs e)
        {
            // Code borrowed from https://social.msdn.microsoft.com/Forums/vstudio/en-US/279e29b8-e439-4d1a-9834-86ce78f6f64f/how-to-enable-horizontal-scrolling-with-mouse-wheel?forum=wpf

            ScrollViewer scrollViewer = sender as ScrollViewer;

            if(e.Delta > 0)
            {
                scrollViewer.LineLeft();
                scrollViewer.LineLeft();
            }
            else
            {
                scrollViewer.LineRight();
                scrollViewer.LineRight();
            }

            e.Handled = true;
        }

    }
}
