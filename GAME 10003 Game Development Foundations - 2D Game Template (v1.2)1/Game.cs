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

        public void Setup()
        {
            Window.SetTitle("Breakout");

            Window.SetSize(600, 800);
        }

        public void Update()
        {
            Shape_Creation Shape_Creation = new Shape_Creation();
            Collision Collision = new Collision();
            Collision.circleLastPosition = Collision.circleLocation;
            Shape_Creation.bouncerLastPosition = Shape_Creation.bouncerLocation;
            Window.ClearBackground(Color.White);
            

            Draw.FillColor = Color.Red;
            Draw.Circle(Collision.circleLocation.X, Collision.circleLocation.Y, Collision.circleRadius);
            
            Shape_Creation.bricks();
            Shape_Creation.ball();
            Shape_Creation.bouncer();
            
            Collision.circleLocation.Y += Collision.circleDirectionY;
            Collision.circleLocation.X += Collision.circleDirectionX;
            
            Collision.doesCollideWithBrick();
            if (Collision.doesCollideWithBrick() == true) 
            {
                
            }
            Collision.BallCollision();
       
        }

        
    }
}
