using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacman
{
    class GameCell
    {
        public GameCell(int x,int y,GameGrid grid)
        {
            this.x = x;
            this.y = y;
            gameGrid = grid;
        }
        public int x;
        public int y;
        public GameObject CurrentGameObject;
        public GameGrid gameGrid;

        public GameCell nextCell(GameDirection direction)
        {
            if (direction==GameDirection.Left)
            {
                if(this.y>0)
                {
                    GameCell Cell = gameGrid.GetCell(x, y - 1);
                    if(Cell.CurrentGameObject.GameObjectType!=GameObjectType.WALL)
                    {
                        return Cell;
                    }
                }
            }
            if (direction == GameDirection.Right)
            {
                if (this.y <gameGrid.Cols-1)
                {
                    GameCell Cell = gameGrid.GetCell(x, y +1);
                    if (Cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return Cell;
                    }
                }
            }
            if (direction == GameDirection.Up)
            {
                if (this.x > 0)
                {
                    GameCell Cell = gameGrid.GetCell(x-1, y);
                    if (Cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return Cell;
                    }
                }
            }
            if (direction == GameDirection.Down)
            {
                if (this.x < gameGrid.Rows - 1)
                {
                    GameCell Cell = gameGrid.GetCell(x+1, y );
                    if (Cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return Cell;
                    }
                }
            }
            return this;//returns own reference
        }
    }
}
