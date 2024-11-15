using Game10003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GAME_10003_Game_Development_Foundations___2D_Game_Template__v1._2_1
{

    public class Shape_Creation
    {
        //Bricks
        public Vector2 rectangleLocation = new Vector2(30, 50);
        public Vector2 rectangleSize = new Vector2(50, 25);

        //Bouncer
        public Vector2 position = Input.GetMousePosition();
        public Vector2 bouncerLocation = new Vector2(250, 600);
        public Vector2 bouncerSize = new Vector2(100, 25);
        public Vector2 bouncerLastPosition;

        //destroyed bricks array
        public bool[] hitBrick = new bool[30];

        public Collision collision;

        //brick edges initialized
        public float leftEdge;
        public float rightEdge;
        public float topEdge;
        public float bottomEdge;

        //make bricks
        public void bricks()
        {
            Draw.FillColor = Color.Blue;
            //nested for loop to create and remove bricks
            for (int i = 0; i < 3; i++)
            {
                int yOffset = i * 35;
                for (int j = 0; j < 10; j++)
                {
                    int xOffset = j * 55;
                    if (hitBrick[i * 10 + j] == false)
                    {
                        Draw.Rectangle(rectangleLocation.X + xOffset, rectangleLocation.Y + yOffset, rectangleSize.X, rectangleSize.Y);

                        leftEdge = rectangleLocation.X + xOffset;
                        rightEdge = rectangleLocation.X + xOffset + rectangleSize.X;
                        topEdge = rectangleLocation.Y + yOffset;
                        bottomEdge = rectangleLocation.Y + yOffset + rectangleSize.Y;

                        collision.doesCollideWithBrick();
                        if (collision.doesCollideWithBrick() == true)
                        {

                            hitBrick[i * 10 + j] = true;
                            collision.circleDirectionX = -collision.circleDirectionX;
                            collision.circleDirectionY = -collision.circleDirectionY;
                        }
                    }

                }

            }
        }

        //make ball
        public void ball()
        {

            Draw.FillColor = Color.Red;
            Draw.Circle(collision.circleLocation.X, collision.circleLocation.Y, collision.circleRadius);

        }

        //Move ball
        public void ballMovement()
        {
            collision.circleLocation.Y += collision.circleDirectionY;
            collision.circleLocation.X += collision.circleDirectionX;
        }

        //make bouncer
        public void bouncer()
        {
            position = Input.GetMousePosition();
            Draw.FillColor = Color.Magenta;
            Draw.Rectangle(position.X - 50, bouncerLocation.Y, bouncerSize.X, bouncerSize.Y);
        }

    }
}
