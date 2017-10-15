using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace ST_Reading
{
    /// <summary>
    /// Interaction logic for FirstCourseControls.xaml
    /// </summary>
    public partial class FirstCourseControls : Window
    {
        WordDatabase wordDatabase;
        public FirstCourseControls(Window window)
        {
            this.Owner = window;
            wordDatabase = new WordDatabase(Owner);
            InitializeComponent();
            WindowStyle = WindowStyle.None;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Left = SystemParameters.PrimaryScreenWidth - Width;
            Top = SystemParameters.PrimaryScreenHeight - Height;
            //MessageBox.Show("Guesstimated Size: Width: " + size.Width + ", Height: " + size.Height);
            //((FirstCourse)Owner).TextBlockScreen.FontSize = sl_FontSize.Value;
        }

        private void sl_FontSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((FirstCourse)Owner).TextBlockScreen.FontSize = e.NewValue;
            switch (e.NewValue)
            {
                case 10:
                    wordDatabase.WordCount = (800 - (0 * 100)) + 40;
                    break;
                case 15:
                    wordDatabase.WordCount = (800 - (1 * 100)) + 40;
                    break;
                case 20:
                    wordDatabase.WordCount = (800 - (2 * 100)) + 40;
                    break;
                case 25:
                    wordDatabase.WordCount = (800 - (3 * 100)) + 40;
                    break;
                case 30:
                    wordDatabase.WordCount = (800 - (4 * 100)) + 40;
                    break;
                case 35:
                    wordDatabase.WordCount = (800 - (5 * 100)) + 40;
                    break;
                case 40:
                    wordDatabase.WordCount = (800 - (6 * 100)) + 40;
                    break;
                case 45:
                    wordDatabase.WordCount = (800 - (7 * 100)) + 40;
                    break;
                case 50:
                    wordDatabase.WordCount = (800 - (8 * 100)) + 40;
                    break;
                default:
                    break;
            }
            wordDatabase.FillWithText();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wordDatabase.FillWithText();
            ((FirstCourse)Owner).Test();
        }
    }
}
