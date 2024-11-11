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
        Vector2 rectangleLocation = new Vector2(200, 400);
        Vector2 rectangleSize = new Vector2(200, 100);

        Vector2 circleLocation = new Vector2(200, 200);
        int circleRadius = 10;

        Vector2 circleLastPosition;

        // Rectangle sides
        float recTopEdge = 200f;
        //float recBottomEdge = 400f;


        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600);
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

            
            circleLocation.Y += 1;
            RectangleCollision();
        }

        public void RectangleCollision()
        {
            bool isColliding = circleLocation.Y >= 400f;

            if (isColliding == true)
            {
                circleLocation = circleLastPosition;
            }

        }
    }
}
