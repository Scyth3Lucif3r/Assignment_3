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
        public Vector2 BouncerLocation = new Vector2(250, 600);
        public Vector2 BouncerSize = new Vector2(100, 25);

        //Ball
        public Vector2 circleLocation = new Vector2(300, 400);
        int circleRadius = 10;

        public void bricks()
        {
            Draw.FillColor = Color.Blue;

            for (int i = 0; i < 3; i++)
            {
                int yOffset = i * 35;
                for (int j = 0; j < 10; j++)
                {
                    int xOffset = j * 55;
                    Draw.Rectangle(rectangleLocation.X + xOffset, rectangleLocation.Y + yOffset, rectangleSize.X, rectangleSize.Y);
                }
                
            }
        }

        public void ball()
        {
            Draw.FillColor = Color.Red;
            Draw.Circle(circleLocation, circleRadius);
        }

        public void bouncer()
        {
            Draw.FillColor = Color.Magenta;
            Draw.Rectangle(BouncerLocation, BouncerSize);
        }
        
    }
}
