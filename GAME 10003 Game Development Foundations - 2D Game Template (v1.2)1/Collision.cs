using Game10003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GAME_10003_Game_Development_Foundations___2D_Game_Template__v1._2_1
{
    public class Collision
    {
        public Vector2 circleLocation = new Vector2(300, 400);
        public int circleRadius = 10;
        public float circleSpeed = 3;

        public Vector2 circleLastPosition;
        public float circleDirectionY = -3;
        public float circleDirectionX = 3;

        public Shape_Creation shape_Creation;
        public void BallCollision()
        {
            circleLastPosition = circleLocation;
            bool isAboveScreenTop = circleLocation.Y - circleRadius <= 0;
            bool isPastScreenLeft = circleLocation.X - circleRadius <= 0;
            bool isPastScreenRight = circleLocation.X + circleRadius >= Window.Width;
            if (isAboveScreenTop == true)
            {
                circleDirectionY = 3f;
                circleLocation.Y = 0 + circleRadius;
            }
            else if (isPastScreenLeft == true)
            {
                circleDirectionX = 3f;
                circleLocation.X = 0 + circleRadius;
            }
            else if (isPastScreenRight == true)
            {
                circleDirectionX = -3f;
                circleLocation.X = Window.Width - circleRadius;
            }
        }

        public bool doesCollideWithBrick()
        {
            bool doesOverlapLeft = shape_Creation.leftEdge < circleLocation.X + circleRadius;
            bool doesOverlapRight = shape_Creation.rightEdge > circleLocation.X - circleRadius;
            bool doesOverlapTop = shape_Creation.topEdge < circleLocation.Y + circleRadius;
            bool doesOverlapBottom = shape_Creation.bottomEdge > circleLocation.Y - circleRadius;

            bool doesOverlap = doesOverlapLeft && doesOverlapRight && doesOverlapTop && doesOverlapBottom;

            Console.WriteLine("doesOverlap: " + doesOverlap);

            return doesOverlap;
        }

        public void bouncerCollision()
        {
            bool bouncerTop = 605 >= circleLocation.Y + circleRadius && circleLocation.Y + circleRadius >= 600;

            if (bouncerTop == true && Input.GetMouseX() - 50 <= circleLocation.X && circleLocation.X <= Input.GetMouseX() + 50)
            {
                circleDirectionY = -3;
                circleLocation.Y = shape_Creation.bouncerLocation.Y - circleRadius;
            }
        }
    }
}
