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
using System.IO;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for SignupWindow.xaml
    /// </summary>
    public partial class SignupWindow : Window
    {
        public SignupWindow()
        {
            InitializeComponent();
        }

        private void buttonSuccessfullySignup_Click(object sender, RoutedEventArgs e)
        {
            string line = "";
            try
            {

                using (StreamWriter w = File.AppendText(@"C:\Users\HP\Documents\Visual Studio 2015\Projects\TicTacToe\TicTacToe\users.txt"))
                {
                    w.WriteLine(textBoxUserName.Text);
                    w.WriteLine(textBoxPassword.Password);
                }

                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error,Can't find file", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
