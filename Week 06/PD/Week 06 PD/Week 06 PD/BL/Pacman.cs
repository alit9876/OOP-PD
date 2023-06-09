using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;

namespace Week_06_PD.BL
{
    
     class Pacman
    {
        public int X;
        public int Y;
        public int score;
        public Grid grid_maze = new Grid();

        public Pacman(int X, int Y, Grid grid_maze)
        {
            this.X = X;
            this.Y = Y;
            this.grid_maze = grid_maze;
        }

        public void Print(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("P");
        }

        public void Remove(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        public void MoveLeft(Cell current, Cell next)
        {
            if (next.value == ' ')
            {
                Remove(current.X, current.Y);
                current.X--;
                Print(next.X, next.Y);
            }
        }

        public void MoveRight(Cell current, Cell next)
        {
            if (next.value == ' ')
            {
                Remove(current.X, current.Y);
                current.X++;
                Print(next.X, next.Y);
            }
        }

        public void MoveUp(Cell current, Cell next)
        {
            Remove(current.X, current.Y);
            current.Y--;
            Print(next.X, next.Y);
        }

        public void MoveDown(Cell current, Cell next)
        {
            Remove(current.X, current.Y);
            current.Y++;
            Print(next.X, next.Y);
        }

        public void Move()
        {
            Grid G = new Grid();
            Cell cell = new Cell('P', X, Y);
            Cell rightCell = G.GetRightCell(cell);
            Cell leftCell = G.GetLeftCell(cell);
            Cell upCell = G.GetUpCell(cell);
            Cell downCell = G.GetDownCell(cell);

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                MoveRight(cell, rightCell);
            }

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                MoveLeft(cell, leftCell);
            }

            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                MoveUp(cell, upCell);
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                MoveDown(cell, downCell);
            }
        }

        public void PrintScore()
        {
            Console.SetCursorPosition(80, 10);
            score++;
        }
        public void draw()
        {

        }
    }
}
