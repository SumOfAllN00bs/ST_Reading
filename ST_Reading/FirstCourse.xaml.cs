using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ST_Reading
{
    /// <summary>
    /// Interaction logic for FirstCourse.xaml
    /// </summary>
    public partial class FirstCourse : Window
    {
        DispatcherTimer countDown;
        DispatcherTimer visiblePeriod;
        FirstCourseControls firstCourseControls;
        int tick_no = 0;
        public FirstCourse()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            firstCourseControls = new FirstCourseControls(this);
            firstCourseControls.Show();
            Top = 0;
            Left = 100;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((MainWindow)Owner).ShowMe();
            firstCourseControls.Close();
        }

        public void Test()
        {
            countDown = new DispatcherTimer();
            countDown.Tick += Dispatcher_Tick;
            countDown.Interval = new TimeSpan(0, 0, 1);
            countDown.Start();
        }

        private void Dispatcher_Tick(object sender, EventArgs e)
        {
            if (tick_no < 3)
            {
                this.Title = Math.Abs(tick_no - 3).ToString();
                tick_no++;
                return;
            }
            this.Title = "FirstCourse";
            TextBlockScreen.Visibility = Visibility.Visible;
            visiblePeriod = new DispatcherTimer();
            visiblePeriod.Tick += VisiblePeriod_Tick;
            visiblePeriod.Interval = new TimeSpan(0, 0, 1);
            visiblePeriod.Start();
            tick_no = 0;
            countDown.Stop();
        }

        private void VisiblePeriod_Tick(object sender, EventArgs e)
        {
            TextBlockScreen.Visibility = Visibility.Hidden;
            visiblePeriod.Stop();
        }
    }
}
