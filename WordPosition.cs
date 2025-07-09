using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPuzzleGenerator.Models
{
    public enum Direction { Horizontal, Vertical, Diagonal}
    public class WordPosition
    {
        public string Word { get; set; }
        public int StartRow { get; set; }
        public int StartCol { get; set; }
        public Direction Direction { get; set; }


        public WordPosition(string word, int row, int col, Direction direction)
        {
            Word = word;
            StartRow = row;
            StartCol = col;
            Direction = direction;
        }
    }
}
