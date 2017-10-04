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
        public int ButtonSize;
        private int NumberBombs;
        private int TextBombs;
        private int Timer;
        private int NumberClickedCases;
        private Board board;
        private System.Timers.Timer aTimer;
        private bool IsGameOver;
        private bool GameWin;

        public Minesweeper()
        {
            InitializeComponent();
            ButtonRows = 9;
            ButtonCols = 9;
            Bombs = 10;
            ButtonSize = 50;
            NewGame();
        }

        public Minesweeper(int rows, int cols, int bombs, int size)
        {
            InitializeComponent();
            ButtonRows = rows;
            ButtonCols = cols;
            Bombs = bombs;
            ButtonSize = size;
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
            Height = ButtonSize * ButtonRows;
            Width = ButtonSize * ButtonRows;
            NumberBombs = Bombs;
            TextBombs = Bombs;
            NumberClickedCases = 0;
            IsGameOver = false;
            board = new Board(ButtonRows, ButtonCols);
            board.FillWithBombs(NumberBombs);
            CalculateBombsAroundEachCase();
            DisplayBoard(board);
            Height = (ButtonSize * ButtonRows) + 250;
            Width = (ButtonSize * ButtonCols) + 20;
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
            board.DisplayConsole();
        }

        private void CalculateBombsAroundEachCase()
        {
            for (int i = 0; i < board.Row; i++)
            {
                for (int j = 0; j < board.Col; j++)
                {
                    board.GetNumberBombsAround(board.Cases[i][j]);
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

            // Flags
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
                Lose(clickedCase);
            else
                Reveal(clickedCase, button);
        }

        private void Button_Click(object sender, MouseEventArgs e)
        {
            ClickOnButton(sender, e);
        }

        private void ClickButtonsAround(Case clickedCase)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (clickedCase.Row + i >= 0 && clickedCase.Row + i < board.Row && clickedCase.Col + j >= 0 && clickedCase.Col + j < board.Col)
                    {
                        Button button1 = Controls.Find((clickedCase.Row + i).ToString() + ":" + (clickedCase.Col + j).ToString(), true).FirstOrDefault() as Button;
                        if (!board.Cases[clickedCase.Row + i][clickedCase.Col + j].IsClicked)
                            Reveal(board.Cases[clickedCase.Row + i][clickedCase.Col + j], button1);
                    }
                }
            }
        }

        private void Reveal(Case clickedCase, Button button)
        {
            clickedCase.IsClicked = true;
            NumberClickedCases++;
            button.BackgroundImage = null;
            button.BackColor = Color.WhiteSmoke;
            if (clickedCase.NumberBombsAround == 0)
            {
                ClickButtonsAround(clickedCase);
            }
            else
            {
                button.Text = clickedCase.NumberBombsAround.ToString();
                button.Font = new Font(button.Font.FontFamily, ButtonSize / 3);
                if (clickedCase.NumberBombsAround == 1) button.ForeColor = Color.Blue;
                if (clickedCase.NumberBombsAround == 2) button.ForeColor = Color.Green;
                if (clickedCase.NumberBombsAround == 3) button.ForeColor = Color.Red;
                if (clickedCase.NumberBombsAround == 4) button.ForeColor = Color.BlueViolet;
            }
            if (NumberClickedCases == (ButtonRows * ButtonCols - NumberBombs))
            {
                Win();
            }
        }

        private void Lose(Case clickedCase)
        {
            Button buttonReplay = Controls.Find("Replay", true).FirstOrDefault() as Button;
            buttonReplay.BackgroundImage = Properties.Resources.GameOver;
            IsGameOver = true;
            GameWin = false;
            DisplayBombs();
            Button buttonExplosion = Controls.Find(clickedCase.Row + ":" + clickedCase.Col, true).FirstOrDefault() as Button;
            buttonExplosion.BackgroundImage = Properties.Resources.BombExplosion;
        }

        private void Win()
        {
            Button replayButton = Controls.Find("Replay", true).FirstOrDefault() as Button;
            replayButton.BackgroundImage = Properties.Resources.Win;
            IsGameOver = true;
            GameWin = true;
            DisplayBombs();
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
                        if (GameWin)
                            button.BackgroundImage = Properties.Resources.Flag;
                        else
                            if (button.BackgroundImage == null)
                            button.BackgroundImage = Properties.Resources.Bomb;
                    }
                    else
                        if (!GameWin && button.BackgroundImage != null)
                        button.BackgroundImage = Properties.Resources.WrongBomb;
                }
            }
        }

        private void DisplayBoard(Board board)
        {
            PictureBox bombPicture = new PictureBox()
            {
                Name = "BombImage",
                Image = Properties.Resources.Bomb,
                Location = new Point(30, 50),
                Height = ButtonSize,
                Width = ButtonSize,
                Size = new Size(ButtonSize, ButtonSize),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Controls.Add(bombPicture);
            Label numberBombs = new Label()
            {
                Name = "NumberBombs",
                Text = NumberBombs.ToString(),
                Location = new Point(ButtonSize * 2, 50),
                Height = ButtonSize,
                Width = ButtonSize + 20,
                Font = new Font(Font.FontFamily, ButtonSize/2)
            };
            Controls.Add(numberBombs);

            Button replayButton = new Button()
            {
                Name = "Replay",
                BackgroundImage = Properties.Resources.Sun,
                Location = new Point(Width / 2, 50),
                Height = ButtonSize,
                Width = ButtonSize,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            Controls.Add(replayButton);

            Label timer = new Label()
            {
                Name = "Timer",
                Text = "0",
                Location = new Point(Width - 100, 50),
                Height = ButtonSize,
                Width = ButtonSize + 50,
                Font = new Font(Font.FontFamily, ButtonSize/2)
            };
            Controls.Add(timer);

            for (int i = 0; i < board.Row; i++)
            {
                for (int j = 0; j < board.Col; j++)
                {
                    Button newButton = new Button()
                    {
                        Name = i.ToString() + ":" + j.ToString(),
                        Location = new Point(j * ButtonSize, i * ButtonSize + 150),
                        Height = ButtonSize,
                        Width = ButtonSize,
                        BackgroundImageLayout = ImageLayout.Stretch
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
            ButtonRows = 9;
            ButtonCols = 9;
            Bombs = 10;
            aTimer.Close();
            NewGame();
        }

        private void intermediateItem_Click(object sender, EventArgs e)
        {
            ButtonRows = 16;
            ButtonCols = 16;
            Bombs = 40;
            aTimer.Close();
            NewGame();
        }

        private void expertItem_Click(object sender, EventArgs e)
        {
            ButtonRows = 16;
            ButtonCols = 30;
            Bombs = 99;
            aTimer.Close();
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
