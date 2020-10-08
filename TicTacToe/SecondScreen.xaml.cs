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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for SecondScreen.xaml
    /// </summary>
    /// 

    public static class Globals2
    {
        public static bool firstTime = false;
        public static string username1, password;
    }

    public partial class SecondScreen : Window
    {
        public SecondScreen()
        {
            InitializeComponent();
        }

        private void buttonTwoPlayer_Click(object sender, RoutedEventArgs e)
        {
            Globals.singlePlay=false;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void buttonSinglePlayer_Click(object sender, RoutedEventArgs e)
        {
            Globals.singlePlay = true;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void buttonHelp_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HelpWindow hellpWindow = new HelpWindow();
            hellpWindow.Show();
        }
    }
}
