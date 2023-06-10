using IUTGame;
using System;

namespace SpaceShooter.model.Projectiles
{
    public class PlayerBullet : Projectile
    {
        private double vitesse = 400;
        public double Vitesse { get => vitesse; set => vitesse = value; }


        private TimeSpan waiting = TimeSpan.Zero;
        private bool touched = false;



        public PlayerBullet(double x, double y, Game g, string name = "SpritePlayerBullet", int zindex = 0) :
            base(x, y, g, name, zindex)
        {

        }


        public override string TypeName => "PlayerBullet";




        public override void Animate(TimeSpan dt)
        {

            MoveDA(Vitesse * dt.TotalSeconds, 270);
        }
    }
}

