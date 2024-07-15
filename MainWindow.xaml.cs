using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Windows.Threading;

namespace TimerApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private TimeSpan elapsedTime = TimeSpan.Zero;

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
            Timer_Counter.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }






        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            if(elapsedTime != TimeSpan.Zero)
            {
                timer.Start();
            }
            else
            {
                elapsedTime = TimeSpan.Zero;
                timer.Start();
            }
            


        }

        private void ResetButtonClick(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            elapsedTime = TimeSpan.Zero;
            Timer_Counter.Text = "00:00:00";
        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
