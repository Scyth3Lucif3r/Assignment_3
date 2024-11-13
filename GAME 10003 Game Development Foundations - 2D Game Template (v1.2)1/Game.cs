// Include code libraries you need below (use the namespace).
using GAME_10003_Game_Development_Foundations___2D_Game_Template__v1._2_1;
using System;
using System.Numerics;
using System.Runtime.Serialization;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        //Vector2 rectangleLocation = new Vector2(50, 50);
        //Vector2 rectangleSize = new Vector2(50, 25);
        // We need to convert our position and size into edges.

        public Vector2 circleLocation = new Vector2(300, 400);
        public Vector2 circleLastPosition;

        float radius = 35;
        Vector2 position = new Vector2(200, 50);
        Vector2 velocity;
        Vector2 forceOfGravity = new Vector2(0, 10);


        Shape_Creation Shape_Creation = new Shape_Creation();

        Collision Collision = new Collision();

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
            //Console.WriteLine("Fee");

            Draw.FillColor = Color.Red;
            Draw.Circle(circleLocation.X, circleLocation.Y, Collision.circleRadius);
            //Console.WriteLine("Fi");
            Shape_Creation.bricks();
            Shape_Creation.ball();
            Shape_Creation.bouncer();
            //Console.WriteLine("Fo");
            circleLocation.Y += Collision.circleDirectionY;
            circleLocation.X += Collision.circleDirectionX;
            Collision.DoesCollideWithBrick(Collision.circleDirectionX, Collision.circleDirectionY);
            Collision.RectangleCollision();
            //Console.WriteLine("Fum");
        }

        
    }
}
