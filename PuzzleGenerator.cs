using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPuzzleGenerator.Models;

namespace WordPuzzleGenerator.Services
{
    public class PuzzleGenerator
    {
        private int gridSize { get; set; }
        private char[,] grid;
        private List<string> wordList;
        private Random rand = new Random();

        public PuzzleGenerator(List<string> words, int size = 12)
        {
            gridSize = size;
            grid = new char[gridSize, gridSize];
            wordList = words;
        }

        public void Generate() { 
        
            foreach (var word in wordList)
            {
                bool placed = false;

                while (!placed)
                {
                    int row = rand.Next(gridSize);
                    int col = rand.Next(gridSize);
                    Direction direction = (Direction)rand.Next(3);
                    if (CanPlaceWord(word.ToUpper(), row, col, direction))
                    {
                        PlaceWord(word.ToUpper(), row, col, direction);
                        placed = true;
                    }
                }
            }

            FillRemainingCells();
        }

        private bool CanPlaceWord(string word, int row, int col, Direction dir)
        {
            for (int i=0; i<word.Length; i++)
            {
                int r = row, c = col;

                switch (dir)
                {
                    case Direction.Horizontal:
                        c += i;
                        break;
                    case Direction.Vertical:
                        r += i;
                        break;
                    case Direction.Diagonal:
                        r += i;
                        c += i;
                        break;
                }

                if (r >= gridSize || c >= gridSize || (grid[r, c] != '\0' && grid[r, c] != word[i]))
                {
                    return false;
                }
                
            }
            return true;
        }

        private void PlaceWord(string word, int row, int col, Direction dir)
        {
            for (int i=0; i<word.Length;i++)
            {
                switch (dir)
                {
                    case Direction.Horizontal:
                        grid[row, col + i] = word[i];
                        break;
                    case Direction.Vertical:
                        grid[row + i, col] = word[i];
                        break;
                    case Direction.Diagonal:
                        grid[row + i, col + i] = word[i];
                        break;
                }
            }
        }

        private void FillRemainingCells()
        {
            for (int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    if (grid[r, c] == '\0')
                    {
                        grid[r, c] = (char)('A' + rand.Next(26)); // Fill with random letters
                    }
                }
            }
        }

        public void Display()
        {
            for(int r = 0; r < gridSize; r++)
            {
                for (int c = 0; c < gridSize; c++)
                {
                    Console.Write(grid[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
