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
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void play_Click(object sender, EventArgs e)
        {
            Hide();
            Minesweeper form1 = new Minesweeper();
            form1.Bombs = Int32.Parse(Math.Round(numberBombs.Value).ToString());
            form1.ButtonRows = Int32.Parse(Math.Round(numberRows.Value).ToString());
            form1.ButtonCols = Int32.Parse(Math.Round(numberCols.Value).ToString());
            form1.Closed += (s, args) => Close();
            form1.Show();
            form1.NewGame();
        }
    }
}
