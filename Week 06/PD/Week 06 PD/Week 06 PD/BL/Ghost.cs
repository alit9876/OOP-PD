using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_06_PD.BL
{
     class Ghost
    {
        public int X;
        public int Y;
        public string ghostdirection;
        public char GCharacter;
        public float speedofghost;
        public char PreviousItem;
        public float changedspeed;
        public Grid grid_maze;

        public Ghost(int X, int Y, string ghostdirection, char GCharacter, float speedofghost, char PreviousItem, Grid grid_maze)
        {
            this.X = X;
            this.Y = Y;
            this.ghostdirection = ghostdirection;
            this.GCharacter = GCharacter;
            this.speedofghost = speedofghost;
            this.PreviousItem = PreviousItem;
            this.grid_maze = grid_maze;
        }

        public void SetDirection(string ghostdirection)
        {
            this.ghostdirection = ghostdirection;
        }

        public string GetDirection()
        {
            return ghostdirection;
        }

        public void Remove(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        public void Print(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(GCharacter);
        }

        public char GetCharacter()
        {
            return GCharacter;
        }

        public void ChangeDelta()
        {
            changedspeed = changedspeed + speedofghost;
        }

        public float GetDelta()
        {
            return changedspeed;
        }

        public void SetDeltaZero()
        {
            changedspeed = 0F;
        }

        public void move()
        {
            ChangeDelta();
            if (Math.Floor(GetDelta()) == 1)
            {
                if (GCharacter == 'H')
                {
                    MoveHorizontal(grid_maze);
                }
                SetDeltaZero();
            }
        }

        public void MoveHorizontal(Grid GridMaze)
        {
            if (GetDirection() == "Up")
            {
                if (GridMaze.maze[X, Y - 1].value == ' ')
                {
                    Y--;
                }
                else
                {
                    SetDirection("Down");
                }
            }
            if (GetDirection() == "Down")
            {
                if (GridMaze.maze[X, Y + 1].value == ' ')
                {
                    Y++;
                }
                else
                {
                    SetDirection("Up");
                }
            }
        }
    }
}
