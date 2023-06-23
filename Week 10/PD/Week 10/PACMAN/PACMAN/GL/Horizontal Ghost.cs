using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN.GL
{

    class Horizontal_Ghost : Ghost
    {
        GameGrid grid;
        GameDirection direction;
        public Horizontal_Ghost(GameDirection direction,char displayCharacter, GameCell startCell) : base(GameObjectType.ENEMY, displayCharacter)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
            this.grid = startCell.grid;
        }
        public override GameCell move()
        {
            if (direction == GameDirection.Left)
            {
                if (CurrentCell.Y > 0)
                {
                    GameCell ncell = grid.getCell(CurrentCell.X, CurrentCell.Y - 1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                    else
                    {
                        direction = GameDirection.Right;
                    }
                }
            }
            if (direction == GameDirection.Right)
            {
                if (CurrentCell.Y < grid.Cols - 1)
                {
                    GameCell ncell = grid.getCell(CurrentCell.X, CurrentCell.Y + 1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                    else
                    {
                        direction = GameDirection.Left;
                    }
                }
            }
            
            return null; // if can not return next cell return its own reference
        }
       
        public override void movement(GameCell nextCell)
        {
            if (nextCell != null)
            {
                GameObject newGo = new GameObject(GameObjectType.NONE, ' ');
                GameCell currentCell = this.CurrentCell;
                MovementClass.clearGameCellContent(currentCell, newGo);
                this.CurrentCell = nextCell;
                MovementClass.printGameObject(this);
            }

        }
        public override void moveGhost(Ghost Gh,GamePacManPlayer pac)
        {
            
        }

    }
}
