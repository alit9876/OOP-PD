using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacman
{
    class GameGrid
    {
        public GameGrid(string fileName, int rows, int coloumns)
        {
            Rows = rows;
            Cols = coloumns;
            GameCell = new GameCell[rows, coloumns];
            LoadGrid(fileName);

        }
        public GameCell[,] GameCell;
        public int Rows;
        public int Cols;
        private void LoadGrid(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            string line = " ";
            for (int row = 0; row < Rows; row++)
            {
                line = file.ReadLine();
                for (int col = 0; col < Cols; col++)
                {
                    GameCell cell = new GameCell(row, col, this);
                    char displayCharacter = line[col];
                    GameObjectType type = GameObject.GetGameObjectType(displayCharacter);
                    GameObject gameObject = new GameObject(type ,displayCharacter);
                    cell.CurrentGameObject = gameObject;
                    GameCell[row, col] = cell;
                }
            }
            file.Close();
        }
        public GameCell GetCell(int x,int y)
        {
            return GameCell[x, y];
        }
    }
}
