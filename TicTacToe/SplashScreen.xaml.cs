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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {

        DispatcherTimer dispatcher = new DispatcherTimer();

        public SplashScreen()
        {
            InitializeComponent();
            dispatcher.Tick += new EventHandler(dipatcherTicks);
            dispatcher.Interval = new TimeSpan(0,0,5);
            dispatcher.Start();
        }
        private void dipatcherTicks(object sender, EventArgs e)
        {
            SecondScreen secondScreen = new SecondScreen();
            secondScreen.Show();

            dispatcher.Stop();
            this.Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            
            if(MessageBox.Show("You want to cancel?", "Are you sure?",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
