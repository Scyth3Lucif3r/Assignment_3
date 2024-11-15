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
    /// 
    public class Game
    {
        Shape_Creation shape_Creation = new Shape_Creation();
        Collision collision = new Collision();

        
        public void Setup()
        {
            Window.SetTitle("Breakout");

            Window.SetSize(600, 800);

            collision.shape_Creation = shape_Creation;
            shape_Creation.collision = collision;
        }

        public void Update()
        {
            collision.circleLastPosition = collision.circleLocation;
            shape_Creation.bouncerLastPosition = shape_Creation.bouncerLocation;

            Window.ClearBackground(Color.White);
            
            shape_Creation.bricks();
            shape_Creation.ball();
            shape_Creation.bouncer();
            shape_Creation.ballMovement();

            collision.bouncerCollision();
        }

        
    }
}
