using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN.GL
{
    class GameObject
    {
        char displayCharacter;
        GameObjectType gameObjectType;
        GameCell currentCell;
        public GameObject(GameObjectType type, char displayCharacter)
        {
            this.displayCharacter = displayCharacter;
            this.gameObjectType = type;
        }
        public static GameObjectType getGameObjectType(char displayCharacter)
        {
            if(displayCharacter == '|' || displayCharacter == '%' || displayCharacter == '#')
            {
                return GameObjectType.WALL;
            }
            if(displayCharacter == 'P')
            {
                return GameObjectType.PLAYER;
            }
            if (displayCharacter == 'E')
            {
                return GameObjectType.ENEMY;
            }
            if (displayCharacter == '.')
            {
                return GameObjectType.REWARD;
            }
            return GameObjectType.NONE;
        }
        public char DisplayCharacter { get => displayCharacter; set => displayCharacter = value; }
        public GameObjectType GameObjectType { get => gameObjectType; set => gameObjectType = value; }
        public GameCell CurrentCell
        {
            get => currentCell;
            set
            {
                currentCell = value;
                currentCell.CurrentGameObject = this;
            }
        }
    }
}
