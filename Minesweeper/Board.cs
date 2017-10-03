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
            for (int i = 0; i < numberOfBombs; i++)
            {
                bool CaseFilled = false;
                do
                {
                    Random random = new Random();
                    int randomNumberRow = random.Next(0, Row);
                    int randomNumberCol = random.Next(0, Col);
                    if (!Cases[randomNumberRow][randomNumberCol].IsBomb)
                    {
                        Cases[randomNumberRow][randomNumberCol].IsBomb = true;
                        CaseFilled = true;
                    }
                } while (!CaseFilled);
            }
            DisplayConsole();
            return true;
        }

        public int GetNumberBombsAround(Board board, Case clickedCase)
        {
            int numberBombs = 0;
            if (clickedCase.Row - 1 >= 0)
            {
                if(clickedCase.Col - 1 >= 0)
                    if (board.Cases[clickedCase.Row - 1][clickedCase.Col - 1].IsBomb) numberBombs++;
                if (board.Cases[clickedCase.Row - 1][clickedCase.Col].IsBomb) numberBombs++;
                if (clickedCase.Col + 1 < board.Col)
                    if (board.Cases[clickedCase.Row - 1][clickedCase.Col + 1].IsBomb) numberBombs++;
            }
            if (clickedCase.Row + 1 < board.Row)
            {
                if (clickedCase.Col - 1 >= 0)
                    if (board.Cases[clickedCase.Row + 1][clickedCase.Col - 1].IsBomb) numberBombs++;
                if (board.Cases[clickedCase.Row + 1][clickedCase.Col].IsBomb) numberBombs++;
                if (clickedCase.Col + 1 < board.Col)
                    if (board.Cases[clickedCase.Row + 1][clickedCase.Col + 1].IsBomb) numberBombs++;
            }
            if (clickedCase.Col - 1 >= 0)
                if (board.Cases[clickedCase.Row][clickedCase.Col - 1].IsBomb) numberBombs++;
            if (clickedCase.Col + 1 < board.Col)
                if (board.Cases[clickedCase.Row][clickedCase.Col + 1].IsBomb) numberBombs++;

            return numberBombs;
        }

        private void DisplayConsole()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    string test = Cases[i][j].IsBomb ? "X" : ".";
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
