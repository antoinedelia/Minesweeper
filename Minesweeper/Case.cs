using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Case
    {
        public bool IsBomb { get; set; }
        public bool IsClicked { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public Case()
        {
            IsBomb = false;
            IsClicked = false;
        }
        public Case(int row, int col)
        {
            IsBomb = false;
            IsClicked = false;
            Row = row;
            Col = col;
        }
    }
}
