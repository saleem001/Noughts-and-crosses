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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public static class Globals

    {
        public static String userName = "Mike";  //Modifiable in Code
        public static int score = 10;
        public static bool singlePlay = false;
    }

    
    public partial class MainWindow : Window
    {
        bool login = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            string line = "";
            if (!(textBoxUsername.Text.Equals("Username") && textBoxPassword.Password.Equals("Password")))
            {
                try
                {
                    StreamReader read = new StreamReader(@"C:\Users\HP\Documents\Visual Studio 2015\Projects\TicTacToe\TicTacToe\users.txt");     //object to read text file with the name auntheticateUsers.text
                    String line2 = "";
                    while (!login && (line = read.ReadLine()) != null)
                    {
                        if (line == textBoxUsername.Text)              //check if username exists in text file
                        {
                            line2 = read.ReadLine();
                            if (line2 == textBoxPassword.Password)                                                    //shows login panel
                            {
                                login = true;
                                if (Globals.singlePlay)
                                {
                                    this.Hide();
                                    PlayingWindow playingWindow = new PlayingWindow();
                                    playingWindow.Show();
                                }
                                else
                                {
                                    this.Hide();
                                    if (Globals2.firstTime)
                                    {
                                        if ((Globals2.username1 == line) && (Globals2.password == line2))
                                        {
                                            MessageBox.Show("Trying to login with same user name Twice", "Log In Again!!");
                                            MainWindow mainWindow = new MainWindow();
                                            mainWindow.Show();
                                        }
                                        else
                                        {
                                            PlayingWindow playingWindow = new PlayingWindow();
                                            playingWindow.Show();
                                        }
                                    }
                                    else
                                    {
                                        Globals2.username1 = line;
                                        Globals2.password = line2;
                                        MainWindow mainWindow = new MainWindow();
                                        mainWindow.Show();
                                        Globals2.firstTime = true;
                                    }
                                }
                            }
                        }

                    }
                    if (line != textBoxUsername.Text || line2 != textBoxPassword.Password)
                    {
                        MessageBox.Show("Aunthetication Error");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error,Can't find file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (textBoxUsername.Text.Equals("Username") || textBoxPassword.Password.Equals("Password"))
            {
                MessageBox.Show("Aunthetication Error");
            }
        }

        private void buttonSignup_Click(object sender, RoutedEventArgs e)
        {
            SignupWindow signupWindow = new SignupWindow();
            signupWindow.Show();
            this.Hide();
        }
    }
}
