﻿using IUTGame;
using System;

namespace SpaceShooter.model.Projectiles
{
    /// <summary>
    /// Gère les balles tirées par les ennemis
    /// </summary>
    /// <author>Théo Cornu</author>
    public class Bullet : Projectile
    {
            
        private TimeSpan waiting = TimeSpan.Zero;

        

        public Bullet(double x, double y, Game g, string name = "bullet.png", int zindex = 0) :
            base(x, y, g, name, zindex)
        {
            ChangeSprite(name);
            base.Speed = 250;
        }

        
        public override string TypeName => "Bullet";


        

        public override void Animate(TimeSpan dt)
        {
            if (waiting > TimeSpan.Zero)
            {
                waiting = waiting - dt;
            }
            if (this.Top < 0)
            {
                TheGame.RemoveItem(this);


            }
            else if (Bottom > GameHeight)
            {
                TheGame.RemoveItem(this);
                
            }
            else if (Left < 0)
            {
                
                Left = 0;
                TheGame.RemoveItem(this);
            }
            else if (Right > GameWidth)
            {
                
                Right = GameWidth;
                TheGame.RemoveItem(this);
            }
            MoveDA(Speed * dt.TotalSeconds, 100);
        }

        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "Player")
            {
                //other.ChangeSprite("explosion.png");
                TheGame.Loose();
            }

        }
    }
}
