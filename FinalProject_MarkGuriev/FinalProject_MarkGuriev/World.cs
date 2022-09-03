using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FinalProject_MarkGuriev
{
    class World
    {
        private string[,] _grid;
        private int _rows;
        private int _cols;

        public World(string[,] grid)
        {
            _grid = grid;
            _rows = _grid.GetLength(0);
            _cols = _grid.GetLength(1);
        }

        public void Draw()
        {
            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _cols; x++)
                {
                    string element = _grid[y, x];
                    SetCursorPosition(x, y);
                    if (element == "X")
                    {
                        ForegroundColor = ConsoleColor.Green;
                    }
                    else if (element == "M")
                    {
                        ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if (element == "#")
                    {
                        ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (element == "^")
                    {
                        ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                    }
                    Write(element);

                }
            }
        }

        public string GetElementAt(int x, int y)
        {
            return _grid[y, x];
        }

        public void GiveElement(string elem, int x, int y)
        {
            _grid[y, x] = elem;

        }

        public bool IsPositionWalkable(int x, int y)
        {
            //Ceck bounds first
            if (x < 0 || y < 0 || x >= _cols || y >= _rows)
            {
                return false;
            }
            //Check if the grid is walkable
            return _grid[y, x] == " " || _grid[y, x] == "X" || _grid[y, x] == " " || _grid[y, x] == "^"
                || _grid[y, x] == " " || _grid[y, x] == "*" || _grid[y, x] == " " || _grid[y, x] == "#";
            
        }
    }
}
