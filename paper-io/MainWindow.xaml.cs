using System;
using System.Windows.Threading;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace paper_io
{
    /// <summary>
    /// Логика взаимодействия для paper_io.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerDisplay;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "3";
            tb.Visibility = Visibility.Visible;
            int count = Convert.ToInt32(tb.Text);
            timer.Tag = count;
            bc.IsEnabled = false;
            timer.Start();
        }

        private void TimerDisplay(object sender, EventArgs e)
        {
            int count = (int)timer.Tag;
            tb.Text = (--count).ToString();
            timer.Tag = count;
            if (count == 0)
            {
                timer.Stop();
                bc.IsEnabled = true;
                tb.Visibility = Visibility.Hidden;
            }
        }
    }

}
