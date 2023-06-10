using IUTGame;
using System;

namespace SpaceShooter.model.Projectiles
{
    public class Bullet : Projectile
    {
            
        private TimeSpan waiting = TimeSpan.Zero;
        private bool touched = false;

        

        public Bullet(double x, double y, Game g, string name = "SpriteBullet", int zindex = 0) :
            base(x, y, g, name, zindex)
        {
            ChangeSprite("bullet.png");
            base.Vitesse = 200;
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
