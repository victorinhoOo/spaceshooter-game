using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Ennemies
{
    public abstract class Enemy : GameItem, IAnimable
    {
        private double speed = 200;
        public double Speed { get => speed; set => speed = value; }


        private static int amount = 0;
        private TimeSpan waiting = TimeSpan.Zero;
        private bool touched = false;
        public TimeSpan Waiting { get => waiting; set => waiting = value; }
        public bool Touched { get => touched; set => touched = value; }



        public Enemy(double x, double y, Game g, string name = "", int zindex = 0) :
            base(x, y, g, name, zindex)
        {
            ++amount;
        }

        public override string TypeName => "Enemy";



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

            }
            else if (other.TypeName == "Projectile")
            {

            }

            else if (other.TypeName == TypeName)
            {

            }



        }

        abstract public void Animate(TimeSpan dt);


    }
}
    
