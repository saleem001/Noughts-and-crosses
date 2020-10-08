using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Automation.Provider;
using System.Windows.Automation;



namespace TicTacToe
{

    /// <summary>
    /// Interaction logic for PlayingWindow.xaml
    /// </summary>
    public partial class PlayingWindow : Window
    {

        bool turn = true;
        int turnCount=0;
        public PlayingWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //performClick();
            Button button = (Button)sender;
            if(turn)
            {
                textBoxFirstUser.Text = "";
                button.Content="X";
                textBoxSecondUser.Text = "O's turn";
            }
            else
            {
                textBoxSecondUser.Text = "";
                button.Content = "O";
                textBoxFirstUser.Text = "X's turn";
            }

            turn = !turn;
            button.IsEnabled = false;
            turnCount++;
            bool x=checkWiner();

            if((!turn) && (Globals.singlePlay) && (!x))
            {
                computerMakeMove();
            }
        }

        private void computerMakeMove()
        {
            //priority1 get tic tac toe
            //priority2 block x's tic tac toe
            //priority3 go for open space
            //priority4 pick corner

            Button move = null;
            move = lookForMoveOrBlock("O");
            if(move==null)
            {
                move = lookForMoveOrBlock("X");
                if(move==null)
                {
                    move = lookForCorner();
                }
                if (move ==null)
                {
                    move = lookForOpenSpace();
                }
            }

            ButtonAutomationPeer peer = new ButtonAutomationPeer(move);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        private Button lookForMoveOrBlock(string mark)
        {
            //horizantal checks
            if ((A1.Content.ToString() == mark) && (A2.Content.ToString() == mark) && ((A3.Content as string) == ""))  //check if first colunm matches 
            {
                return A3;
            }
            else if ((A2.Content.ToString() == mark) && (A3.Content.ToString() == mark) && ((A1.Content as string) == ""))  //check if first colunm matches 
            {
                return A1;
            }
            else if ((A1.Content.ToString() == mark) && (A3.Content.ToString() == mark) && ((A2.Content as string) == ""))  //check if first colunm matches 
            {
                return A2;
            }

            //second row
            else if ((B1.Content.ToString() == mark) && (B2.Content.ToString() == mark) && ((B3.Content as string) == ""))  //check if first colunm matches 
            {
                return B3;
            }
            else if ((B2.Content.ToString() == mark) && (B3.Content.ToString() == mark) && ((B1.Content as string) == ""))  //check if first colunm matches 
            {
                return B1;
            }
            else if ((B1.Content.ToString() == mark) && (B3.Content.ToString() == mark) && ((B2.Content as string) == ""))  //check if first colunm matches 
            {
                return B2;
            }

            //third row
            else if ((C1.Content.ToString() == mark) && (C2.Content.ToString() == mark) && ((C3.Content as string) == ""))  //check if first colunm matches 
            {                                                                               
               return C3;                                                                   
            }                                                                               
            else if ((C2.Content.ToString() == mark) && (C3.Content.ToString() == mark) && ((C1.Content as string) == ""))  //check if first colunm matches 
            {                                                                               
               return C1;                                                                   
            }                                                                               
            else if ((C1.Content.ToString() == mark) && (C3.Content.ToString() == mark) && ((C2.Content as string) == ""))  //check if first colunm matches 
            {         
               return C2;
            }

            //Vertical Tests
            if ((A1.Content.ToString() == mark) && (B1.Content.ToString() == mark) && ((C1.Content as string) == ""))  //check if first colunm matches 
            {
                return C1;
            }
            else if ((B1.Content.ToString() == mark) && (C1.Content.ToString() == mark) && ((A1.Content as string) == ""))  //check if first colunm matches 
            {
                return A1;
            }
            else if ((A1.Content.ToString() == mark) && (C1.Content.ToString() == mark) && ((B1.Content as string) == ""))  //check if first colunm matches 
            {
                return B1;
            }


               //second column
            if ((A2.Content.ToString() == mark) && (B2.Content.ToString() == mark) && ((C2.Content as string) == ""))  //check if first colunm matches 
            {
                return C2;
            }
            else if ((B2.Content.ToString() == mark) && (C2.Content.ToString() == mark) && ((A2.Content as string) == ""))  //check if first colunm matches 
            {
                return A2;
            }
            else if ((A2.Content.ToString() == mark) && (C2.Content.ToString() == mark) && ((B2.Content as string) == ""))  //check if first colunm matches 
            {
                return B2;
            }


            //third column
            if ((A3.Content.ToString() == mark) && (B3.Content.ToString() == mark) && ((C3.Content as string) == ""))  //check if first colunm matches 
            {
                return C3;
            }
            else if ((B3.Content.ToString() == mark) && (C3.Content.ToString() == mark) && ((A3.Content as string) == ""))  //check if first colunm matches 
            {
                return A3;
            }
            else if ((A3.Content.ToString() == mark) && (C3.Content.ToString() == mark) && ((B3.Content as string) == ""))  //check if first colunm matches 
            {
                return B3;
            }

            //diagonal tests
            if ((A1.Content.ToString() == mark) && (B2.Content.ToString() == mark) && ((C3.Content as string) == ""))  //check if first colunm matches 
            {
                return C3;
            }
            else if ((B2.Content.ToString() == mark) && (C3.Content.ToString() == mark) && ((A1.Content as string) == ""))  //check if first colunm matches 
            {
                return A1;
            }
            else if ((A1.Content.ToString() == mark) && (C3.Content.ToString() == mark) && ((B2.Content as string) == ""))  //check if first colunm matches 
            {
                return B2;
            }

            //second diagonal
            if ((A3.Content.ToString() == mark) && (B2.Content.ToString() == mark) && ((C1.Content as string) == ""))  //check if first colunm matches 
            {
                return C1;
            }
            else if ((B2.Content.ToString() == mark) && (C1.Content.ToString() == mark) && ((A3.Content as string) == ""))  //check if first colunm matches 
            {
                return A3;
            }
            else if ((A3.Content.ToString() == mark) && (C1.Content.ToString() == mark) && ((B2.Content as string) == ""))  //check if first colunm matches 
            {
                return B2;
            }

            return null;

        }

        private Button lookForCorner()
        {
            if (A1.Content.ToString() == "O")
            {
                if ((A3.Content as string) == "")
                    return A3;
                if ((C3.Content as string) == "")
                    return C3;
                if ((C1.Content as string) == "")
                    return C1;
            }

            if (A3.Content.ToString() == "O")
            {
                if (A1.Content.ToString() == "")
                    return A1;
                if (C3.Content.ToString() == "")
                    return C3;
                if (C1.Content.ToString() == "")
                    return C1;
            }

            if (C3.Content.ToString() == "O")
            {
                if (A1.Content.ToString() == "")
                    return A3;
                if (A3.Content.ToString() == "")
                    return A3;
                if (C1.Content.ToString() == "")
                    return C1;
            }

            if (C1.Content.ToString() == "O")
            {
                if (A1.Content.ToString() == "")
                    return A3;
                if (A3.Content.ToString() == "")
                    return A3;
                if (C3.Content.ToString() == "")
                    return C3;
            }

            if (A1.Content.ToString() == "")
                return A1;
            if (A3.Content.ToString() == "")
                return A3;
            if (C1.Content.ToString() == "")
                return C1;
            if (C3.Content.ToString() == "")
                return C3;

            return null;
        }
        private Button lookForOpenSpace()
        {
            if ((A1.Content as string) == "")
                return A1;
            if ((A2.Content as string) == "")
                return A2;
            if ((A3.Content as string) == "")
                return A3;
            if ((B1.Content as string) == "")
                return B1;
            if ((B2.Content as string) == "")
                return B2;
            if ((B3.Content as string) == "")
                return B3;
            if ((C1.Content as string) == "")
                return C1;
            if ((C2.Content as string) == "")
                return C2;
            if ((C3.Content as string) == "")
                return C3;
            return null;
        }
        private bool checkWiner()
        {
            bool winner = false;
            //horizantal checks
            if((A1.Content==A2.Content) && (A1.Content==A3.Content) && (!A1.IsEnabled))  //check if first colunm matches 
            {
                winner = true;
            }
            else if ((B1.Content == B2.Content) && (B1.Content == B3.Content) && (!B1.IsEnabled))   //check if second colunm matches 
            {
                winner = true;
            }
            else if((C1.Content == C2.Content) && (C1.Content == C3.Content) && (!C1.IsEnabled))   //check if third colunm matches 
            {
                winner = true;
            }

            //Vertical checks
            else if((A1.Content == B1.Content) && (A1.Content == C1.Content) && (!A1.IsEnabled))  //check if first Row matches 
            {
                winner = true;
            }
            else if((A2.Content == B2.Content) && (A2.Content == C2.Content) && (!A2.IsEnabled))   //check if second Row matches 
            {
                winner = true;
            }
            else if((A3.Content == B3.Content) && (A3.Content == C3.Content) && (!A3.IsEnabled))   //check if third row matches 
            {
                winner = true;
            }

            //Diagonal checks
            else if ((A1.Content == B2.Content) && (A1.Content == C3.Content) && (!A1.IsEnabled))  
            {
                winner = true;
            }
            else if ((A3.Content == B2.Content) && (A3.Content == C1.Content) && (!C1.IsEnabled))   
            {
                winner = true;
            }

            if (winner)
            {
                disableButtons();
                string win="";
                if (turn)
                {
                    win = "O";
                }
                else
                    win = "X";
                MessageBox.Show(win + " Won", "Yayy!");
                buttonViewProfile.Visibility=Visibility.Visible;
                buttonViewProfile.IsEnabled = true;
                buttonExit.Visibility = Visibility.Visible;
                buttonExit.IsEnabled = true;
                if(win=="X")
                {
                    return true;
                }
            }
            else
            {
                if(turnCount==9)
                {
                    MessageBox.Show("Draw :(", "Bumm!");
                    buttonViewProfile.Visibility = Visibility.Visible;
                    buttonViewProfile.IsEnabled = true;
                    buttonExit.Visibility = Visibility.Visible;
                    buttonExit.IsEnabled = true;
                }
            }
            return false;
        }
        private void disableButtons()
        {

            A1.IsEnabled = false;
            A2.IsEnabled = false;
            A3.IsEnabled = false;
            B1.IsEnabled = false;
            B2.IsEnabled = false;
            B3.IsEnabled = false;
            C1.IsEnabled = false;
            C2.IsEnabled = false;
            C3.IsEnabled = false;
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonViewProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
        }
    }
}
