using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;
using PACMAN.GL;

namespace PACMAN
{
    class Program
    {
        
        static void Main(string[] args)
        {
            GameGrid grid = new GameGrid("maze.txt", 24, 71);
            GameCell start = new GameCell(14, 2, grid);
            GamePacManPlayer pacman = new GamePacManPlayer('p', start);

            GameCell H1Start = new GameCell(15, 15, grid);
            Horizontal_Ghost H1Ghost = new Horizontal_Ghost(GameDirection.Left, 'G', H1Start);


            GameCell V1Start = new GameCell(15, 50, grid);
            Vertical_Ghost V1Ghost = new Vertical_Ghost(GameDirection.Up, 'Y', V1Start);

            GameCell rstart = new GameCell(12, 25, grid);
            RandomGhost g3 = new RandomGhost('R', rstart);

            GameCell g4start = new GameCell(19, 25, grid);
            Smart_Ghost g4 = new Smart_Ghost('S', g4start, pacman);
            List<Ghost> listGhost = new List<Ghost>();

            listGhost.Add(H1Ghost);
            listGhost.Add(V1Ghost);
            listGhost.Add(g3);
            listGhost.Add(g4);

            printMaze(grid);
            MovementClass.printGameObject(pacman);
            bool gameRunning = true;
            while(gameRunning)
            {
                Thread.Sleep(90);
                if(Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    MovementClass.moveGameObject(pacman, GameDirection.Up);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    MovementClass.moveGameObject(pacman, GameDirection.Down);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    MovementClass.moveGameObject(pacman, GameDirection.Right);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    MovementClass.moveGameObject(pacman, GameDirection.Left);
                }

                
                for(int x=0;x< listGhost.Count;x++)
                {
                    listGhost[x].movement(listGhost[x].move());
                }
            }
        }
       

        

        static void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    printCell(cell);
                }
            }
        }
        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.Y, cell.X);
            Console.Write(cell.CurrentGameObject.DisplayCharacter);
        }
    }
}
