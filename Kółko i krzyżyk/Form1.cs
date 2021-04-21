using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kółko_i_krzyżyk
{
    enum CurrentPlayer
    {
        Cross,
        Circle
    }
    public partial class Form1 : Form
    {
        CurrentPlayer currentPlayer;

        public Form1()
        {
            InitializeComponent();
            currentPlayer = CurrentPlayer.Cross;
            changeLabel();
        }

        private void Mark(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            if(currentPlayer == CurrentPlayer.Cross)
            {
                senderButton.Text = "X";
                currentPlayer = CurrentPlayer.Circle;
            }
            else
            {
                senderButton.Text = "O";
                currentPlayer = CurrentPlayer.Cross;
            }
            if (checkForWinner())
                showWinner();
            changeLabel();
        }
        public void changeLabel()
        {
            if(currentPlayer == CurrentPlayer.Cross)
            {
                currentPlayerLabel.Text = "Krzyżyk";
            }
            else
            {
                currentPlayerLabel.Text = "Kółko";
            }
        }
        public bool checkForWinner()
        {
            // pion X
            if (tl.Text == "X" && cl.Text == "X" && bl.Text == "X")
            {
                return true;
            }
            else if (tc.Text == "X" && cc.Text == "X" && bc.Text == "X")
            {
                return true;
            }
            else if (tr.Text == "X" && cr.Text == "X" && br.Text == "X")
            {
                return true;
            }
            // poziom X
            else if (tl.Text == "X" && tc.Text == "X" && tr.Text == "X")
            {
                return true;
            }
            else if (cl.Text == "X" && cc.Text == "X" && cr.Text == "X")
            {
                return true;
            }
            else if (bl.Text == "X" && bc.Text == "X" && br.Text == "X")
            {
                return true;
            }
            // skos X
            else if (tl.Text == "X" && cc.Text == "X" && br.Text == "X")
            {
                return true;
            }
            else if (tr.Text == "X" && cc.Text == "X" && bl.Text == "X")
            {
                return true;
            }
            // pion O
            if (tl.Text == "O" && cl.Text == "O" && bl.Text == "O")
            {
                return true;
            }
            else if (tc.Text == "O" && cc.Text == "O" && bc.Text == "O")
            {
                return true;
            }
            else if (tr.Text == "O" && cr.Text == "O" && br.Text == "O")
            {
                return true;
            }
            // poziom O
            else if (tl.Text == "O" && tc.Text == "O" && tr.Text == "O")
            {
                return true;
            }
            else if (cl.Text == "O" && cc.Text == "O" && cr.Text == "O")
            {
                return true;
            }
            else if (bl.Text == "O" && bc.Text == "O" && br.Text == "O")
            {
                return true;
            }
            // skos O
            else if (tl.Text == "O" && cc.Text == "O" && br.Text == "O")
            {
                return true;
            }
            else if (tr.Text == "O" && cc.Text == "O" && bl.Text == "O")
            {
                return true;
            }
            
            return false;

        }
   
        public void showWinner()
        {
            Form2 victoryScreen = new Form2(this);
            victoryScreen.winner = currentPlayerLabel.Text;
            victoryScreen.Show();
        }
        public void clearBoard()
        {
            TableLayoutControlCollection buttons = tableLayoutPanel1.Controls;

            for(int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i] is Button)
                    buttons[i].Text = "";
            }

            currentPlayer = CurrentPlayer.Cross;
            currentPlayerLabel.Text = "Krzyżyk";
        }
        
        private void restart_Click(object sender, EventArgs e)
        {
            clearBoard();
            currentPlayer = CurrentPlayer.Cross;
            currentPlayerLabel.Text = "Krzyżyk";
        }

    }
}
