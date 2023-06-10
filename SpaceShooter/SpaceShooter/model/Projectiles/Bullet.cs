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

            MoveDA(Vitesse * dt.TotalSeconds, 270);
        }
    }
}
