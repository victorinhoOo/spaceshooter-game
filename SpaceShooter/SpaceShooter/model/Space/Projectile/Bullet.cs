using IUTGame;
using SpaceShooter.model.Space.Projectile;
using System;
using System.Reflection.Metadata;

namespace PetitJeu
{
    public class Bullet : Projectile
    {
        private double vitesse = 200;
        public double Vitesse { get => vitesse; set => vitesse = value; }
        
        
        private TimeSpan waiting = TimeSpan.Zero;
        private bool touched = false;

        

        public Bullet(double x, double y, Game g, string name = "SpriteBullet", int zindex = 0) :
            base(x, y, g, name, zindex)
        {
            
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
            MoveDA(Vitesse * dt.TotalSeconds, 270);
        }
    }
}
