using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_06.BL
{
    class GameObject
    {
        public char[,] shape = new char[,] { };
        public point startingpoint;
        public Boundary premises;
        public string direction;
        public int count = 0;
        public GameObject()
        {
            this.startingpoint.setXY(0, 0);
            this.premises.topleft.setXY(0, 0);
            this.premises.topright.setXY(0, 90);
            this.premises.bottomleft.setXY(90, 0);
            this.premises.bottomright.setXY(90, 90);
            this.direction = "lefttoright";
            this.count = 0;

        }
        public GameObject(char[,] shape, point startingpoint, string direction, Boundary premises)
        {
            this.shape = shape;
            this.startingpoint = startingpoint;
            this.direction = direction;
            this.premises = premises;
            this.count = 0;
        }
        public void move()
        {
            if (this.direction == "left")
            {
                if (this.startingpoint.getX() > this.premises.topleft.x || this.startingpoint.getX() > this.premises.bottomleft.x)

                {
                    this.startingpoint.setX(this.startingpoint.getX() - 1);

                }
                else
                {
                    this.direction = "right";

                }
            }
        }
        public void move1()
        {
            if (this.direction == "right")
            {
                if (this.startingpoint.getX() < this.premises.topright.x || this.startingpoint.getX() < this.premises.bottomright.x)
                {
                    this.startingpoint.setX(this.startingpoint.getX() + 1);
                }
                else
                {
                    this.direction = "left";
                }
            }

        }
        public void move4()
        {
            if (this.direction == "projectile")
            {
                if (this.count <= 5)
                {
                    moveupdiagonal();
                }
                if (this.count > 5 && this.count <= 10)
                {
                    movehorizontaldiagonal();
                }
                if (this.count > 10 && this.count <= 15)
                {
                    movedoowndiagonal();
                }
            }
        }
        public void moveupdiagonal()
        {
            if (this.startingpoint.getY() < this.premises.topright.y)
            {
                this.startingpoint.setY(this.startingpoint.getY() - 1);
                this.startingpoint.setX(this.startingpoint.getX() + 1);
                this.count++;

            }
        }
        public void movehorizontaldiagonal()
        {
            if (this.startingpoint.getX() < this.premises.topright.x || this.startingpoint.getX() < this.premises.bottomright.x)
            {
                this.startingpoint.setX(this.startingpoint.getX() + 1);
                this.count++;
            }
        }
        public void movedoowndiagonal()
        {
            if (this.startingpoint.getY() < this.premises.bottomright.y)
            {
                this.startingpoint.setY(this.startingpoint.getY() + 1);
                this.startingpoint.setX(this.startingpoint.getX() + 1);
                this.count++;
            }
        }
        public void move2()
        {


            if (this.direction == "right")
            {

                move1();
            }
            if (this.direction == "left")
            {


                move();
            }


        }
        public void move3()
        {
            if (this.direction == "diagonal")
            {

                if (this.startingpoint.getY() < this.premises.bottomright.y)
                {
                    this.startingpoint.setY(this.startingpoint.getY() + 1);
                    this.startingpoint.setX(this.startingpoint.getX() + 1);
                }

            }
        }

        public void shapeprint()
        {
            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(this.startingpoint.x + j, this.startingpoint.y + i);

                    Console.Write(shape[i, j]);
                }
            }
        }


        public void erase()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(this.startingpoint.x + j, this.startingpoint.y + i);

                    Console.Write(" ");

                }
            }
        }
    }
}
