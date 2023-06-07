using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Space.Projectile
{
    abstract public class Projectile : GameItem, IAnimable
    {
        private double vitesse = 200;
        public double Vitesse { get => vitesse; set => vitesse = value; }
        private TimeSpan waiting = TimeSpan.Zero;
        private bool touched = false;
        public TimeSpan Waiting { get => waiting; set => waiting = value; }
        public bool Touched { get => touched; set => touched = value; }

        public Projectile(double x, double y, Game g, string name = "", int zindex = 0) :
            base(x, y, g, name, zindex)
        {

        }
        public override void CollideEffect(GameItem other)
        {

        }
        abstract public void Animate(TimeSpan dt);
        
        public override string TypeName => "Projectile";
    }
}
