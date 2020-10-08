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
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            InitializeComponent();

            readAndAdd();
        }

        private void readAndAdd()
        {
            string line = "";
            try
            {
                StreamReader read = new StreamReader(@"C:\Users\HP\Documents\Visual Studio 2015\Projects\TicTacToe\TicTacToe\highScorers.txt");     //object to read text file with the name auntheticateUsers.text
                String line2 = "";
                while ((line = read.ReadLine()) != null)
                {
                    line2 = read.ReadLine();
                    listHighScorePlayers.Items.Add("Name : "+line +" , Score : " +line2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error,Can't find file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            textBoxCurrentScore.Text = "Current Score : 2";
            textBoxTotalScore.Text = "Total Score : 4";

        }

        private void textBoxCurrentScore_MouseUp(object sender, MouseButtonEventArgs e)
        {
            textBoxCurrentScore.SelectionStart = textBoxCurrentScore.Text.Length;

        }

        private void buttonPLayNewGame_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PlayingWindow playingWindow = new PlayingWindow();
            playingWindow.Show();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
