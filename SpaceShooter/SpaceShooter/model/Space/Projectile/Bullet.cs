using IUTGame;
using SpaceShooter.model.Space.Projectile;
using System;

namespace PetitJeu
{
    public class Bullet : Projectile
    {
        private double vitesse = 200;
        public double Vitesse { get => vitesse; set => vitesse = value; }
        private double angle = 315;
        
        private TimeSpan waiting = TimeSpan.Zero;
        private bool touched = false;

        public double Angle { get => angle; set => angle = value; }

        public Bullet(double x, double y, Game g, string name = "SpriteBullet", int zindex = 0) :
            base(x, y, g, name, zindex)
        {
            
        }

        
        public override string TypeName => "Bullet";


        public override void CollideEffect(GameItem other)
        {
            if (touched == false)
            {
                waiting = new TimeSpan(0, 0, 0, 600);
                touched = true;
            }
            else if (touched == true && waiting <= TimeSpan.Zero)
            {
                touched = false;
            }
            if (other.TypeName == "Player")
            {
                TheGame.RemoveItem(this);
            }

            

            

        }

        public void Animate(TimeSpan dt)
        {
            if (waiting > TimeSpan.Zero)
            {
                waiting = waiting - dt;
            }
            if (this.Top < 0)
            {
                Top = 0;
                TheGame.RemoveItem(this);


            }
            else if (Bottom > GameHeight)
            {
                TheGame.RemoveItem(this);
                
                
            }
            else if (Left < 0)
            {
                
                Left = 0;
                
            }
            else if (Right > GameWidth)
            {
                
                Right = GameWidth;
                
            }
            MoveDA(Vitesse * dt.TotalSeconds, angle);
        }
    }
}
