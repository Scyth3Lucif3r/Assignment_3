using Game10003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GAME_10003_Game_Development_Foundations___2D_Game_Template__v1._2_1
{
    internal class Collision
    {
        
        public int circleRadius = 10;
        public float circleSpeed = 3;

        
        public float circleDirectionY = -3;
        public float circleDirectionX = 3;

        Shape_Creation Shape_Creation = new Shape_Creation();
        Game Game = new Game();
        public void RectangleCollision()
        {
            bool isBelowScreenBottom = Game.circleLocation.Y + circleRadius >= Window.Height;
            bool isAboveScreenTop = Game.circleLocation.Y - circleRadius <= 0;
            bool isPastScreenLeft = Game.circleLocation.X - circleRadius <= 0;
            bool isPastScreenRight = Game.circleLocation.X + circleRadius >= Window.Width;
            if (isBelowScreenBottom == true)
            {
                circleDirectionY = -3f;
                Game.circleLocation.Y = Window.Height - circleRadius;
            }
            else if (isAboveScreenTop == true)
            {
                circleDirectionY = 3f;
                Game.circleLocation.Y = 0 + circleRadius;
            }
            else if (isPastScreenLeft == true)
            {
                circleDirectionX = 3f;
                Game.circleLocation.X = 0 + circleRadius;
            }
            else if (isPastScreenRight == true)
            {
                circleDirectionX = -3f;
                Game.circleLocation.X = Window.Width - circleRadius;
            }
        }

        public bool DoesCollideWithBrick(float circleDirectionX, float circleDrectionY)
        {
            float leftEdge = Shape_Creation.rectangleLocation.X;
            float rightEdge = Shape_Creation.rectangleLocation.X + Shape_Creation.rectangleSize.X;
            float topEdge = Shape_Creation.rectangleLocation.Y;
            float bottomEdge = Shape_Creation.rectangleLocation.Y + Shape_Creation.rectangleSize.Y;

            bool doesOverlapLeft = leftEdge < Game.circleLocation.X + circleRadius;
            bool doesOverlapRight = rightEdge > Game.circleLocation.X - circleRadius;
            bool doesOverlapTop = topEdge < Game.circleLocation.Y + circleRadius;
            bool doesOverlapBottom = bottomEdge > Game.circleLocation.Y - circleRadius;

            bool doesOverlap = doesOverlapLeft && doesOverlapRight && doesOverlapTop && doesOverlapBottom;

            if (doesOverlapLeft == true)
            {
                circleDirectionX = -3f;
                Game.circleLocation = Game.circleLastPosition;

            }
            else if (doesOverlapRight == true)
            {
                circleDirectionX = 3f;
                Game.circleLocation = Game.circleLastPosition;

            }
            else if (doesOverlapTop == true)
            {
                circleDirectionY = -3f;
                Game.circleLocation = Game.circleLastPosition;

            }
            else if (doesOverlapBottom == true)
            {
                circleDirectionY = 3f;
                Game.circleLocation = Game.circleLastPosition;

            }
            return doesOverlap;
        }
    }
}
