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
        
        public bool FillWithBombs(int numberOfBombs)
        {
            if (!IsBoardCreated()) return false;
            if (numberOfBombs < 0) return false;
            NumberOfBombs = numberOfBombs;
            Random random = new Random();
            // Create options to pick bomb and delete it later so we can't choose the same position twice
            List<int[]> options = new List<int[]>();
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Col; j++)
                    options.Add(new int[] {i, j});

            for (int i = 0; i < NumberOfBombs; i++)
            {
                int randomOption = random.Next(options.Count);
                int randomNumberRow = options[randomOption][0];
                int randomNumberCol = options[randomOption][1];
                options.RemoveAt(randomOption);
                Cases[randomNumberRow][randomNumberCol].IsBomb = true;
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
