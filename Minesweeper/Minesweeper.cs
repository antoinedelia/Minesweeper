using System;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Minesweeper : Form
    {
        public int Bombs;
        public int ButtonRows;
        public int ButtonCols;
        private int NumberBombs;
        private int TextBombs;
        private int Timer;
        private int NumberClickedCases;
        private Board board;
        private System.Timers.Timer aTimer;
        private bool IsGameOver;

        public Minesweeper()
        {
            InitializeComponent();
            ButtonRows = 10;
            ButtonCols = 10;
            Bombs = 20;
            NewGame();
        }

        public Minesweeper(int rows, int cols, int bombs)
        {
            InitializeComponent();
            ButtonRows = rows;
            ButtonCols = cols;
            Bombs = bombs;
            NewGame();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (IsGameOver) return;
            Timer++;
            Label timer = Controls.Find("Timer", true).FirstOrDefault() as Label;
            timer.Text = Timer.ToString();
        }

        public void NewGame()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
            aTimer.SynchronizingObject = this;
            aTimer.Stop();
            Timer = 0;

            Controls.Clear();
            Height = 50 * ButtonRows;
            Width = 50 * ButtonRows;
            NumberBombs = Bombs;
            TextBombs = Bombs;
            NumberClickedCases = 0;
            IsGameOver = false;
            board = new Board(ButtonRows, ButtonCols);
            board.FillWithBombs(NumberBombs);
            DisplayBoard(board);
            Height = (50 * ButtonRows) + 250;
            Width = (50 * ButtonCols) + 20;
            foreach (var button in Controls.OfType<Button>())
            {
                if (button.Name == "Replay")
                {
                    button.Click += ReplayGame;
                }
                else
                {
                    button.MouseUp += Button_Click;
                    button.Click += Button_Click2;
                }
            }
        }

        private void ReplayGame(object sender, EventArgs e)
        {
            aTimer.Close();
            NewGame();
        }

        private void Button_Click2(object sender, EventArgs e)
        {
            ClickOnButton(sender, null);
        }

        private void ClickOnButton(object sender, MouseEventArgs e)
        {
            aTimer.Start();
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
                    {
                        button.BackgroundImage = Properties.Resources.Flag;
                        Label numberBombs = Controls.Find("NumberBombs", true).FirstOrDefault() as Label;
                        TextBombs--;
                        numberBombs.Text = TextBombs.ToString();
                    }
                    else
                    {
                        button.BackgroundImage = null;
                        Label numberBombs = Controls.Find("NumberBombs", true).FirstOrDefault() as Label;
                        TextBombs++;
                        numberBombs.Text = TextBombs.ToString();
                    }
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
                NumberClickedCases++;
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
                if(NumberClickedCases == (ButtonRows*ButtonCols-NumberBombs))
                {
                    Win();
                }
            }
        }

        private void Win()
        {
            Button replayButton = Controls.Find("Replay", true).FirstOrDefault() as Button;
            replayButton.BackgroundImage = Properties.Resources.Win;
            DisplayBombs();
            IsGameOver = true;
        }

        private void Button_Click(object sender, MouseEventArgs e)
        {
            ClickOnButton(sender, e);
        }

        //TODO Improve this shit
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
            IsGameOver = true;
            DisplayBombs();
            Button buttonExplosion = Controls.Find(clickedCase.Row + ":" + clickedCase.Col, true).FirstOrDefault() as Button;
            buttonExplosion.BackgroundImage = Properties.Resources.BombExplosion;
            Button buttonReplay = Controls.Find("Replay", true).FirstOrDefault() as Button;
            buttonReplay.BackgroundImage = Properties.Resources.GameOver;
        }

        private void DisplayBombs()
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
        }

        private void DisplayBoard(Board board)
        {
            PictureBox bombPicture = new PictureBox()
            {
                Name = "BombImage",
                Image = Properties.Resources.Bomb,
                Location = new Point(50, 50),
                Height = 50,
                Width = 50
            };
            Controls.Add(bombPicture);
            Label numberBombs = new Label()
            {
                Name = "NumberBombs",
                Text = NumberBombs.ToString(),
                Location = new Point(100, 50),
                Height = 100,
                Width = 100,
                Font = new Font(Font.FontFamily, 30)
            };
            Controls.Add(numberBombs);

            Button replayButton = new Button()
            {
                Name = "Replay",
                BackgroundImage = Properties.Resources.Sun,
                Location = new Point(Width / 2, 50),
                Height = 50,
                Width = 50
            };
            Controls.Add(replayButton);

            Label timer = new Label()
            {
                Name = "Timer",
                Text = "0",
                Location = new Point(Width - 70, 50),
                Height = 100,
                Width = 100,
                Font = new Font(Font.FontFamily, 30)
            };
            Controls.Add(timer);

            for (int i = 0; i < board.Row; i++)
            {
                for (int j = 0; j < board.Col; j++)
                {
                    int size = Height / board.Row;
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

        private void exitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameItem_Click(object sender, EventArgs e)
        {
            aTimer.Close();
            NewGame();
        }

        private void beginnerItem_Click(object sender, EventArgs e)
        {
            ButtonRows = 8;
            ButtonCols = 8;
            Bombs = 10;
            NewGame();
        }

        private void intermediateItem_Click(object sender, EventArgs e)
        {
            ButtonRows = 10;
            ButtonCols = 10;
            Bombs = 20;
            NewGame();
        }

        private void expertItem_Click(object sender, EventArgs e)
        {
            ButtonRows = 15;
            ButtonCols = 15;
            Bombs = 75;
            NewGame();
        }

        private void customItem_Click(object sender, EventArgs e)
        {
            Hide();
            Settings settings = new Settings();

            settings.Closed += (s, args) => Close();
            settings.Show();
        }
    }
}
