using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {

        public enum player
        {
            X,O
        }

        player curentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int CPUWinCount = 0;
        List<Button> buttons;

        public Form1()
        {
            InitializeComponent();
            restartGame();  
        }

        private void CPUTimer_Tick(object sender, EventArgs e)
        {
            if (buttons.Count>0)
            {
                int index=random.Next(buttons.Count);
                buttons[index].Enabled = false;
                curentPlayer=player.O;
                buttons[index].Text=curentPlayer.ToString();
                buttons[index].BackColor=Color.DarkSalmon;
                buttons.RemoveAt(index);
                checkGame();
                CPUTimer.Stop();    
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            curentPlayer=player.X;
            button.Text=curentPlayer.ToString();
            button.Enabled=false;
            button.BackColor=Color.Cyan;
            buttons.Remove(button);
            checkGame();
            CPUTimer.Start();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            restartGame();
        }

        private void checkGame()
        {
            if(button1.Text=="X" && button2.Text=="X" && button3.Text=="X"
             ||button4.Text=="X" && button5.Text=="X" && button6.Text=="X"
             ||button7.Text=="X" && button8.Text=="X" && button9.Text=="X"
             ||button1.Text=="X" && button4.Text=="X" && button7.Text=="X"
             ||button2.Text=="X" && button5.Text=="X" && button8.Text=="X"
             ||button3.Text=="X" && button6.Text=="X" && button9.Text=="X"
             ||button1.Text=="X" && button5.Text=="X" && button9.Text=="X"
             ||button3.Text=="X" && button5.Text=="X" && button7.Text=="X")
            {
                CPUTimer.Stop();
                playerWinCount++;
                label1.Text="Player Win: "+playerWinCount.ToString();
                MessageBox.Show("Player Win!");
                restartGame();
            }
            else if(button1.Text=="O" && button2.Text=="O" && button3.Text=="O"
             ||button4.Text=="O" && button5.Text=="O" && button6.Text=="O"
             ||button7.Text=="O" && button8.Text=="O" && button9.Text=="O"
             ||button1.Text=="O" && button4.Text=="O" && button7.Text=="O"
             ||button2.Text=="O" && button5.Text=="O" && button8.Text=="O"
             ||button3.Text=="O" && button6.Text=="O" && button9.Text=="O"
             ||button1.Text=="O" && button5.Text=="O" && button9.Text=="O"
             ||button3.Text=="O" && button5.Text=="O" && button7.Text=="O")
            {
                CPUTimer.Stop();
                CPUWinCount++;
                label2.Text="CPU Win: "+CPUWinCount.ToString();
                MessageBox.Show("CPU Win!");
                restartGame();
            }

        }
        private void restartGame()
        {
            buttons = new List<Button> { button1,button2,button3,button4,button5,button6,button7,button8,button9};
            foreach (Button x in buttons)
            {
                x.Enabled=true;
                x.Text="?";
                x.BackColor=DefaultBackColor;
            }
        }
    }
}
