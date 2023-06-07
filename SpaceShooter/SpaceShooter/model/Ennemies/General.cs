using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Space.Enemy
{
    public class General : Enemy
    {
        public General(double x, double y, Game g, string name = "Ship_5.png") : base(x, y, g, name, -100)
        {



        }
        public override string TypeName => "General";

        public void Shoot()
        {

        }

        public void ShootMissile()
        {

        }
        override public void Animate(TimeSpan dt)
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
                

            }
            else if (touched)
            {
                TheGame.RemoveItem(this);
                
                //peut etre rajouter une option qui fais que quand le spaceship est touché 
                //alors son sprite change en exploision puis l'item disparait
            }



        }
    }
}
