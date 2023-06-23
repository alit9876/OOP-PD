using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacman
{
    class GameObject
    {
        public GameObject(GameObjectType type,char DisplayCharacter)
        {
            GameObjectType = type;
            this.DisplayCharacter = DisplayCharacter;
        }
        public char DisplayCharacter;
        public GameCell CurrentCell;
        public GameObjectType GameObjectType;
        public static GameObjectType GetGameObjectType(char displayCharacter)
        {
            if(displayCharacter=='|'|| displayCharacter == '#'|| displayCharacter == '%')
            {
                return GameObjectType.WALL;
            }
            if (displayCharacter == '.')
            {
                return GameObjectType.REWARD;
            }
            return GameObjectType.NONE;
        }
    }
}
