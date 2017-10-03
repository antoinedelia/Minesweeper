using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private int ButtonRows = 10;
        private int ButtonCols = 10;
        private int Bombs = 20;
        private Board board;
        public Form1()
        {
            InitializeComponent();
            Height = 50 * ButtonRows;
            Width = 50 * ButtonRows;
            board = new Board(ButtonRows, ButtonCols);
            board.FillWithBombs(Bombs);
            DisplayBoard(board);
            Height = (50 * ButtonRows) + 200;
            Width = (50 * ButtonCols) + 20;
            foreach (var button in Controls.OfType<Button>())
            {
                button.MouseUp += Button_Click;
                button.Click += Button_Click2;
            }
        }

        private void Button_Click2(object sender, EventArgs e)
        {
            ClickOnButton(sender, null);
        }

        private void ClickOnButton(object sender, MouseEventArgs e)
        {
            Button button = ((Button)sender);
            string buttonName = button.Name;
            int row = Int32.Parse(buttonName.Substring(0, buttonName.LastIndexOf(':')));
            int col = Int32.Parse(buttonName.Substring(buttonName.LastIndexOf(':') + 1));
            Case clickedCase = board.Cases[row][col];
            if (clickedCase.IsClicked) return;
            if (e != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (button.BackgroundImage == null)
                        button.BackgroundImage = Properties.Resources.Flag;
                    else
                        button.BackgroundImage = null;
                    return;
                }
            }
            if (button.BackgroundImage != null) return;

            if (clickedCase.IsBomb)
            {
                GameOver(clickedCase);
            }
            else
            {
                clickedCase.IsClicked = true;
                button.BackColor = Color.WhiteSmoke;
                int numberBombs = board.GetNumberBombsAround(board, clickedCase);
                if (numberBombs == 0)
                {
                    ClickButtonsAround(clickedCase);
                }
                else
                {
                    button.Text = numberBombs.ToString();
                    button.Font = new Font(button.Font.FontFamily, 20);
                    if (numberBombs == 1) button.ForeColor = Color.Blue;
                    if (numberBombs == 2) button.ForeColor = Color.Green;
                    if (numberBombs == 3) button.ForeColor = Color.Red;
                    if (numberBombs == 4) button.ForeColor = Color.BlueViolet;
                }
            }
        }

        private void Button_Click(object sender, MouseEventArgs e)
        {
            ClickOnButton(sender, e);
        }

        private void ClickButtonsAround(Case clickedCase)
        {
            if (clickedCase.Row - 1 >= 0)
            {
                if (clickedCase.Col - 1 >= 0)
                {
                    Button button1 = Controls.Find((clickedCase.Row - 1).ToString() + ":" + (clickedCase.Col - 1).ToString(), true).FirstOrDefault() as Button;
                    button1.PerformClick();
                }
                Button button2 = Controls.Find((clickedCase.Row - 1).ToString() + ":" + (clickedCase.Col).ToString(), true).FirstOrDefault() as Button;
                button2.PerformClick();
                if (clickedCase.Col + 1 < board.Col)
                {
                    Button button3 = Controls.Find((clickedCase.Row - 1).ToString() + ":" + (clickedCase.Col + 1).ToString(), true).FirstOrDefault() as Button;
                    button3.PerformClick();
                }
            }
            if (clickedCase.Row + 1 < board.Row)
            {
                if (clickedCase.Col - 1 >= 0)
                {
                    Button button4 = Controls.Find((clickedCase.Row + 1).ToString() + ":" + (clickedCase.Col - 1).ToString(), true).FirstOrDefault() as Button;
                    button4.PerformClick();
                }
                Button button5 = Controls.Find((clickedCase.Row + 1).ToString() + ":" + (clickedCase.Col).ToString(), true).FirstOrDefault() as Button;
                button5.PerformClick();
                if (clickedCase.Col + 1 < board.Col)
                {
                    Button button6 = Controls.Find((clickedCase.Row + 1).ToString() + ":" + (clickedCase.Col + 1).ToString(), true).FirstOrDefault() as Button;
                    button6.PerformClick();
                }
            }
            if (clickedCase.Col - 1 >= 0)
            {
                Button button7 = Controls.Find((clickedCase.Row).ToString() + ":" + (clickedCase.Col - 1).ToString(), true).FirstOrDefault() as Button;
                button7.PerformClick();
            }
            if (clickedCase.Col + 1 < board.Col)
            {
                Button button8 = Controls.Find((clickedCase.Row).ToString() + ":" + (clickedCase.Col + 1).ToString(), true).FirstOrDefault() as Button;
                button8.PerformClick();
            }
        }

        private void GameOver(Case clickedCase)
        {
            for (int i = 0; i < ButtonRows; i++)
            {
                for (int j = 0; j < ButtonCols; j++)
                {
                    Button button = Controls.Find(i + ":" + j, true).FirstOrDefault() as Button;
                    button.Enabled = false;
                    if (board.Cases[i][j].IsBomb)
                    {
                        button.BackgroundImage = Properties.Resources.Bomb;
                    }
                }
            }
            Button buttonExplosion = Controls.Find(clickedCase.Row + ":" + clickedCase.Col, true).FirstOrDefault() as Button;
            buttonExplosion.BackgroundImage = Properties.Resources.BombExplosion;
        }

        private void DisplayBoard(Board board)
        {
            for (int i = 0; i < board.Row; i++)
            {
                for (int j = 0; j < board.Col; j++)
                {
                    int size = Height/board.Row;
                    Button newButton = new Button()
                    {
                        Name = i.ToString() + ":" + j.ToString(),
                        Location = new Point(j * size, i * size + 150),
                        Height = size,
                        Width = size
                    };
                    Controls.Add(newButton);
                }
            }
        }
    }
}
