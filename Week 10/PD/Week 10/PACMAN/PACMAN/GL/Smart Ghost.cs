using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN.GL
{
    class Smart_Ghost : Ghost
    {
        GamePacManPlayer pac;
        GameDirection direction;
        GameDirection direction1;
        GameGrid grid;
        public Smart_Ghost(char displayCharacter, GameCell startCell, GamePacManPlayer pd) : base(GameObjectType.ENEMY, displayCharacter)
        {
            this.CurrentCell = startCell;
            this.pac = pd;
            this.grid = startCell.grid;
        }
        public override GameCell move()
        {
            if (pac.CurrentCell.Y < this.CurrentCell.Y)
            {
                direction = GameDirection.Left;
            }
            
            if (pac.CurrentCell.Y > this.CurrentCell.Y)
            {
                direction =  GameDirection.Right;
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
            return null;
        }
        public GameCell move2()
        {
            if (pac.CurrentCell.X < this.CurrentCell.X)
            {
                direction =  GameDirection.Up;
            }
            if (pac.CurrentCell.X > this.CurrentCell.X)
            {
                direction =  GameDirection.Down;
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
            GameCell next = move2();
            if(next != null)
            {
                GameObject newGo = new GameObject(GameObjectType.NONE, ' ');
                GameCell currentCell = this.CurrentCell;
                MovementClass.clearGameCellContent(currentCell, newGo);
                this.CurrentCell = next;
                MovementClass.printGameObject(this);
            }
        }

        public override void moveGhost(Ghost Gh, GamePacManPlayer pac)
        {


        }
    }
}
