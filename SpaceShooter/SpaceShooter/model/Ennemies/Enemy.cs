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
        private double angle = 315;
        public double Angle { get => angle; set => angle = value; }
        private static int nombre = 0;
        private TimeSpan waiting = TimeSpan.Zero;
        private bool touched = false;

        public Enemy(double x, double y, Game g, string name = "", int zindex = 0) :
            base(x, y, g, name, zindex)
        {
            ++nombre;
        }

        public override string TypeName => "vaisseau";

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
            else if (other.TypeName == "tirs")
            {

            }

            else if (other.TypeName == TypeName)
            {

            }



        }

        public void Animate(TimeSpan dt)
        {
            if (waiting > TimeSpan.Zero)
            {
                waiting = waiting - dt;
            }
            if (Top < 0)
            {
                Top = 0;


            }
            else if (Bottom > GameHeight)
            {
                TheGame.RemoveItem(this);
                --nombre;
                if (nombre == 0)
                {
                    //peut etre en faire spaw plus
                }

            }
            else if (touched) 
            {
                TheGame.RemoveItem(this);
                --nombre;
                //peut etre rajouter une option qui fais que quand le spaceship est touché 
                //alors son sprite change en exploision puis l'item disparait
            }


            MoveDA(Vitesse * dt.TotalSeconds, angle);
        }
    }
}
