using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int NumberOfBombs { get; set; }

        private Case[][] cases;

        public Board(int h = 10, int w = 10)
        {
            InitializeBoard(h, w);
        }

        private bool InitializeBoard(int h, int w)
        {
            Height = h;
            Width = w;
            cases = new Case[Height][];
            for (int i = 0; i < h; i++)
            {
                cases[i] = new Case[Width];
                for (int j = 0; j < w; j++)
                {
                    cases[i][j] = new Case();
                }
            }
            return true;
        }

        public bool FillWithBombs(int numberOfBombs)
        {
            NumberOfBombs = numberOfBombs;
            if (!IsBoardCreated()) return false;
            if (numberOfBombs < 0) return false;
            //TODO Randomly fill the board with bombs
            return true;
        }

        private bool IsBoardCreated()
        {
            return !(Height == 0 || Width == 0);
        }
    }
}
