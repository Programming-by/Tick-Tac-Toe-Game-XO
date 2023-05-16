using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        stGameStatus GameStatus;

        enPlayer PlayerTurn = enPlayer.Player1;
        enum enPlayer { Player1,Player2 };

        enum enWinner { Player1, Player2,Draw,GameInProgress };

        struct stGameStatus
        {

            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color white = Color.FromArgb(255,255, 255);
            Pen whitePen = new Pen(white);


            whitePen.Width = 15;

            whitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            whitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //draw Horizental lines
            e.Graphics.DrawLine(whitePen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(whitePen, 400, 460, 1050, 460);

            //draw Vertical lines
            e.Graphics.DrawLine(whitePen, 610, 140, 610, 620);
            e.Graphics.DrawLine(whitePen, 840, 140, 840, 620);



        }


        private void EndGame()
        {
            lblTurn.Text = "GameOver";

            switch (GameStatus.Winner)
            {
                case enWinner.Player1:

                    lblWinner.Text = "Player1";
                    break;
                
                case enWinner.Player2:
                    lblWinner.Text = "Player2";

                    break;

                default:

                    lblWinner.Text = "Draw";
                    break;

            }

          MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private bool CheckValues(Button btn1, Button btn2,Button btn3) {
        
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString()  == btn2.Tag.ToString() && btn2.Tag.ToString() == btn3.Tag.ToString())
            {

                btn1.BackColor = Color.YellowGreen;
                btn2.BackColor = Color.YellowGreen;
                btn3.BackColor = Color.YellowGreen;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                     return true;

                } else
                {

                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;




                }


            } 

            return false;
        
        }
    
        private void CheckWinner()
        {

            if (CheckValues(button1,button2,button3)) {

                return;
            }

            if (CheckValues(button4, button5, button6))
            {

                return;
            }

            if (CheckValues(button7, button8, button9))
            {

                return;
            }

            if (CheckValues(button1, button4, button7))
            {

                return;
            }

            if (CheckValues(button2, button5, button8))
            {

                return;
            }

            if (CheckValues(button3, button6, button9))
            {

                return;
            }

            if (CheckValues(button1, button5, button9))
            {

                return;
            }

            if (CheckValues(button3, button5, button7))
            {

                return;
            }



        }

        private void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?") { 


                switch(PlayerTurn)
                {

                    case enPlayer.Player1:

                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;

                        case enPlayer.Player2:

                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;


                }

} else
            {


                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            if (GameStatus.PlayCount == 9)
            {

                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();

            }


        }


    

        private void ResetButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;



        }

        private void RestartGame()
        {

            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";


        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeImage(button1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeImage(button2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeImage(button3);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeImage(button4);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeImage(button5);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeImage(button6);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeImage(button7);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeImage(button8);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeImage(button9);

        }
    }
}
