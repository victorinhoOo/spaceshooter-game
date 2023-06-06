using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Vaisseaux
{
    public class Spaceship : GameItem, IAnimable
    {
        private double vitesse = 200;
        public double Vitesse { get => vitesse; set => vitesse = value; }
        private double angle = 315;
        private static int nombre = 0;
        private TimeSpan waiting = TimeSpan.Zero;
        private bool touched = false;

        public Spaceship(double x, double y, Game g, string name = "", int zindex = 0) :
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

            else if (other.TypeName == this.TypeName)
            {
                
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
                angle = 360 - angle;
                
            }
            else if (Bottom > GameHeight)
            {
                TheGame.RemoveItem(this);
                --nombre;
                if (nombre == 0)
                    TheGame.Loose();
            }
            else if (Left < 0)
            {
                angle = (360 + 180 - angle) % 360;
                Left = 0;
                
            }
            else if (Right > GameWidth)
            {
                angle = (360 + 180 - angle) % 360;
                Right = GameWidth;
                
            }
            MoveDA(Vitesse * dt.TotalSeconds, angle);
        }
    }
}
