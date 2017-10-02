using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private int ButtonRows = 10;
        private int ButtonCols = 10;
        public Form1()
        {
            InitializeComponent();
            Height = 500;
            Width = 500;
            Board board = new Board(ButtonRows, ButtonCols);
            board.FillWithBombs(10);
            DisplayBoard(board);
            Height += 50;
            Width += 50;
        }

        private void DisplayBoard(Board board)
        {
            for (int i = 0; i < board.Height; i++)
            {
                for (int j = 0; j < board.Width; j++)
                {
                    Button newButton = new Button()
                    {
                        Text = i.ToString() + j.ToString(),
                        Name = i.ToString() + j.ToString(),
                        Location = new Point(i * (Height / ButtonRows), j * (Width / ButtonCols)),
                        Height = (Height / board.Width),
                        Width = (Width / board.Height)
                    };
                    this.Controls.Add(newButton);
                }
            }
        }
    }
}
