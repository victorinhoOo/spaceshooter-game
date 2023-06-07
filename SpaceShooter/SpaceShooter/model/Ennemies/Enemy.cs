using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Space.Enemy
{
    abstract public class Enemy : GameItem, IAnimable
    {
        private double vitesse = 200;
        public double Vitesse { get => vitesse; set => vitesse = value; }
        
        
        private static int nombre = 0;
        private TimeSpan waiting = TimeSpan.Zero;
        private bool touched = false;

        public Enemy(double x, double y, Game g, string name = "", int zindex = 0) :
            base(x, y, g, name, zindex)
        {
            ++nombre;
        }

        public override string TypeName => "Ship";

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
            else if (other.TypeName == "Shoot")
            {

            }

            else if (other.TypeName == TypeName)
            {

            }



        }

        abstract public void Animate(TimeSpan dt);
      
        
    }
}
