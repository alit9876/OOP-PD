using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN.GL
{
    class Vertical_Ghost : Ghost
    {
        GameDirection direction;
        GameGrid grid;
        public Vertical_Ghost(GameDirection direction, char displayCharacter, GameCell startCell) : base(GameObjectType.ENEMY, displayCharacter)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
            this.grid = startCell.grid;
        }
        public override GameCell move()
        {
            if (direction == GameDirection.Up)
            {
                if (CurrentCell.X > 0)
                {
                    GameCell ncell = grid.getCell(CurrentCell.X - 1, CurrentCell.Y);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                    else
                    {
                        direction = GameDirection.Down;
                    }
                }
            }
            if (direction == GameDirection.Down)
            {
                if (CurrentCell.X < grid.Rows - 1)
                {
                    GameCell ncell = grid.getCell(CurrentCell.X + 1, CurrentCell.Y);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                    else
                    {
                        direction = GameDirection.Up;
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
        public override void moveGhost(Ghost Gh, GamePacManPlayer pac)
        {

        }
    }
}
