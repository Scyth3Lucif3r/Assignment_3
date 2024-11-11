// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Vector2 rectangleLocation = new Vector2(50, 50);
        Vector2 rectangleSize = new Vector2(50, 25);
        // We need to convert our position and size into edges.
        

        Vector2 circleLocation = new Vector2(300, 400);
        int circleRadius = 10;
        float circleSpeed = 3;

        Vector2 circleLastPosition;
        float circleDirectionY = -3;
        float circleDirectionX = 3;

        
        // Rectangle sides
        float recTopEdge = 200f;
        //float recBottomEdge = 400f;

        float radius = 35;
        Vector2 position = new Vector2(200, 50);
        Vector2 velocity;
        Vector2 forceOfGravity = new Vector2(0, 10);
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(600, 800);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            circleLastPosition = circleLocation;
            Window.ClearBackground(Color.White);
            Draw.FillColor = Color.Blue;
            Draw.Rectangle(rectangleLocation, rectangleSize);

            Draw.FillColor = Color.Red;
            Draw.Circle(circleLocation, circleRadius);
            

            //circleDirection = 1;
            circleLocation.Y += circleDirectionY;
            circleLocation.X += circleDirectionX;
            if (DoesCollideWithBrick() == true)
            {

            }
            RectangleCollision();
        }

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

        public bool DoesCollideWithBrick()
        {
            float leftEdge = rectangleLocation.X;
            float rightEdge = rectangleLocation.X + rectangleSize.X;
            float topEdge = rectangleLocation.Y;
            float bottomEdge = rectangleLocation.Y + rectangleSize.Y;

            bool doesOverlapLeft = leftEdge < circleLocation.X + circleRadius;
            bool doesOverlapRight = rightEdge > circleLocation.X - circleRadius;
            bool doesOverlapTop = topEdge < circleLocation.Y + circleRadius;
            bool doesOverlapBottom = bottomEdge > circleLocation.Y - circleRadius;

            bool doesOverlap = doesOverlapLeft && doesOverlapRight && doesOverlapTop && doesOverlapBottom;
            return doesOverlap;
        }
    }
}
