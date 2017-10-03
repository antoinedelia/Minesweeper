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
    public partial class Settings : Form
    {
        //TODO Add high scores
        public Settings()
        {
            InitializeComponent();
        }

        private void play_Click(object sender, EventArgs e)
        {
            Hide();
            int bombs = Int32.Parse(Math.Round(numberBombs.Value).ToString());
            int rows = Int32.Parse(Math.Round(numberRows.Value).ToString());
            int cols = Int32.Parse(Math.Round(numberCols.Value).ToString());
            Minesweeper form1 = new Minesweeper(rows, cols, bombs);
            
            form1.Closed += (s, args) => Close();
            form1.Show();
            form1.NewGame();
        }
    }
}
