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
            bool isBelowScreenBottom = circleLocation.Y + circleRadius >= Window.Height;
            bool isAboveScreenTop = circleLocation.Y - circleRadius <= 0;
            bool isPastScreenLeft = circleLocation.X - circleRadius <= 0;
            bool isPastScreenRight = circleLocation.X + circleRadius >= Window.Width;
            if (isBelowScreenBottom == true)
            {
                circleDirectionY = -3f;
                circleLocation.Y = Window.Height - circleRadius;
            }
            else if (isAboveScreenTop == true)
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
            float leftEdge = shape_Creation.rectangleLocation.X;
            float rightEdge = shape_Creation.rectangleLocation.X + shape_Creation.rectangleSize.X;
            float topEdge = shape_Creation.rectangleLocation.Y;
            float bottomEdge = shape_Creation.rectangleLocation.Y + shape_Creation.rectangleSize.Y;

            bool doesOverlapLeft = leftEdge < circleLocation.X + circleRadius;
            bool doesOverlapRight = rightEdge > circleLocation.X - circleRadius;
            bool doesOverlapTop = topEdge < circleLocation.Y + circleRadius;
            bool doesOverlapBottom = bottomEdge > circleLocation.Y - circleRadius;

            bool doesOverlap = doesOverlapLeft && doesOverlapRight && doesOverlapTop && doesOverlapBottom;

            return doesOverlap && doesOverlapLeft && doesOverlapRight && doesOverlapTop && doesOverlapBottom;
        }

        public void brickCollision(bool doesOverlapLeft, bool doesOverlapRight, bool doesOverlapTop, bool doesOverlapBottom)
        {
            if (doesOverlapLeft == true)
            {
                circleDirectionX = -3f;
                circleLocation = circleLastPosition;

            }
            else if (doesOverlapRight == true)
            {
                circleDirectionX = 3f;
                circleLocation = circleLastPosition;

            }
            else if (doesOverlapTop == true)
            {
                circleDirectionY = -3f;
                circleLocation = circleLastPosition;

            }
            else if (doesOverlapBottom == true)
            {
                circleDirectionY = 3f;
                circleLocation = circleLastPosition;

            }
        }

        public void bouncerCollision()
        {
            bool bouncerTop = 605 >= circleLocation.Y + circleRadius && circleLocation.Y + circleRadius >= 600;

            if ( bouncerTop == true && Input.GetMouseX() - 50 <= circleLocation.X && circleLocation.X <= Input.GetMouseX() + 50)
            {
                circleDirectionY = -3;
                circleLocation.Y = shape_Creation.bouncerLocation.Y - circleRadius;
            }
        }
    }
}
