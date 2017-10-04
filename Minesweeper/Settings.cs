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
            sizeButtons.DataSource = Enum.GetValues(typeof(ButtonSize));
            sizeButtons.SelectedIndex = 1;
        }

        private void play_Click(object sender, EventArgs e)
        {
            if (sizeButtons.SelectedValue == null) return;
            int bombs = Int32.Parse(Math.Round(numberBombs.Value).ToString());
            int rows = Int32.Parse(Math.Round(numberRows.Value).ToString());
            int cols = Int32.Parse(Math.Round(numberCols.Value).ToString());
            Enum.TryParse<ButtonSize>(sizeButtons.SelectedValue.ToString(), out ButtonSize buttonSize);
            int size = (int)buttonSize;
            Hide();

            Minesweeper form1 = new Minesweeper(rows, cols, bombs, size);
            
            form1.Closed += (s, args) => Close();
            form1.Show();
            form1.NewGame();
        }

        enum ButtonSize
        {
            Small = 30,
            Medium = 50,
            Big = 70
        }
    }
}
