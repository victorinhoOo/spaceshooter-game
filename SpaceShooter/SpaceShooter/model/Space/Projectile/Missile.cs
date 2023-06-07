using IUTGame;
using SpaceShooter.model.Space.Projectile;
using System;

namespace PetitJeu
{
    public class Missile : Projectile
    {
        private double vitesse = 200;
        public double Vitesse { get => vitesse; set => vitesse = value; }


        private TimeSpan waiting = TimeSpan.Zero;
        private bool touched = false;



        public Missile(double x, double y, Game g, string name = "SpriteBullet", int zindex = 0) :
            base(x, y, g, name, zindex)
        {

        }


        public override string TypeName => "Bullet";




        public override void Animate(TimeSpan dt)
        {


        }
    }
}
