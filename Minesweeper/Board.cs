using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Board
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int NumberOfBombs { get; set; }

        public Case[][] Cases { get; set; }

        public Board(int h = 10, int w = 10)
        {
            InitializeBoard(h, w);
        }

        private bool InitializeBoard(int h, int w)
        {
            Row = h;
            Col = w;
            Cases = new Case[Row][];
            for (int i = 0; i < h; i++)
            {
                Cases[i] = new Case[Col];
                for (int j = 0; j < w; j++)
                {
                    Cases[i][j] = new Case(i, j);
                }
            }
            return true;
        }

        //TODO Improve this when there's too many bombs
        public bool FillWithBombs(int numberOfBombs)
        {
            NumberOfBombs = numberOfBombs;
            if (!IsBoardCreated()) return false;
            if (numberOfBombs < 0) return false;
            Random random = new Random();
            for (int i = 0; i < NumberOfBombs; i++)
            {
                bool CaseFilled = false;
                do
                {
                    int randomNumberRow = random.Next(0, Row);
                    int randomNumberCol = random.Next(0, Col);
                    if (!Cases[randomNumberRow][randomNumberCol].IsBomb)
                    {
                        Cases[randomNumberRow][randomNumberCol].IsBomb = true;
                        CaseFilled = true;
                    }
                } while (!CaseFilled);
            }
            return true;
        }

        public void GetNumberBombsAround(Case clickedCase)
        {
            int numberBombs = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (clickedCase.Row + i >= 0 && clickedCase.Row + i < Row && clickedCase.Col + j >= 0 && clickedCase.Col + j < Col)
                        if (Cases[clickedCase.Row + i][clickedCase.Col + j].IsBomb)
                            numberBombs++;
                }
            }
            Cases[clickedCase.Row][clickedCase.Col].NumberBombsAround = numberBombs;
        }

        public void DisplayConsole()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    string test = Cases[i][j].IsBomb ? "X" : Cases[i][j].NumberBombsAround.ToString();
                    Console.Write(test);
                }
                Console.Write("\n");
            }
        }

        private bool IsBoardCreated()
        {
            return !(Row == 0 || Col == 0);
        }
    }
}
