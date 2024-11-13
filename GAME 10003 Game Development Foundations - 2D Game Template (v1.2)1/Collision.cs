﻿using Game10003;
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
        public Vector2 circleLocation = new Vector2(300, 400);
        public int circleRadius = 10;
        public float circleSpeed = 3;

        public Vector2 circleLastPosition;
        public float circleDirectionY = -3;
        public float circleDirectionX = 3;

        Shape_Creation Shape_Creation = new Shape_Creation();
        public void RectangleCollision()
        {
            //bool isColliding = circleLocation.Y >= 400f;
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

        public bool DoesCollideWithBrick(float circleDirectionX, float circleDrectionY)
        {
            float leftEdge = Shape_Creation.rectangleLocation.X;
            float rightEdge = Shape_Creation.rectangleLocation.X + Shape_Creation.rectangleSize.X;
            float topEdge = Shape_Creation.rectangleLocation.Y;
            float bottomEdge = Shape_Creation.rectangleLocation.Y + Shape_Creation.rectangleSize.Y;

            bool doesOverlapLeft = leftEdge < circleLocation.X + circleRadius;
            bool doesOverlapRight = rightEdge > circleLocation.X - circleRadius;
            bool doesOverlapTop = topEdge < circleLocation.Y + circleRadius;
            bool doesOverlapBottom = bottomEdge > circleLocation.Y - circleRadius;

            bool doesOverlap = doesOverlapLeft && doesOverlapRight && doesOverlapTop && doesOverlapBottom;

            if (doesOverlapLeft == true)
            {
                circleDirectionX = -3f;

            }
            else if (doesOverlapRight == true)
            {
                circleDirectionX = 3f;

            }
            else if (doesOverlapTop == true)
            {
                circleDirectionY = -3f;

            }
            else if (doesOverlapBottom == true)
            {
                circleDirectionY = 3f;

            }
            return doesOverlap;
        }
    }
}
