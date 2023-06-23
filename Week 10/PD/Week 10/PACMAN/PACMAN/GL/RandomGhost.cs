using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN.GL
{
    class RandomGhost : Ghost
    {
        GameGrid grid;
        GameDirection direction;
        public RandomGhost(char displayCharacter, GameCell startCell) : base(GameObjectType.ENEMY, displayCharacter)
        {
            this.CurrentCell = startCell;
            this.grid = startCell.grid;
        }
        public override GameCell move()
        {
            Random rnd = new Random();
            int choice = rnd.Next(1, 5);
            if (choice == 1)
            {
                direction = GameDirection.Left;
            }
            if (choice == 2)
            {
                direction = GameDirection.Right;
            }
            if (choice == 3)
            {
                direction = GameDirection.Up;
            }
            if (choice == 4)
            {
                direction = GameDirection.Down;
            }
            if (direction == GameDirection.Left)
            {
                if (CurrentCell.Y > 0)
                {
                    GameCell ncell = grid.getCell(CurrentCell.X, CurrentCell.Y - 1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
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
                }
            }
            if (direction == GameDirection.Up)
            {
                if (CurrentCell.X > 0)
                {
                    GameCell ncell = grid.getCell(CurrentCell.X - 1, CurrentCell.Y);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
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
                }
            }
            return null;
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
