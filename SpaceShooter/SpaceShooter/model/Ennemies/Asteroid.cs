using IUTGame;
using SpaceShooter.model.Space.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Ennemies
{
    public class Asteroid : Enemy
    {
        public Asteroid(double x, double y, Game g, string name = "flaming_astertoid.png") : base(x, y, g, name, -100)
        {

        }
        override public void Animate(TimeSpan dt)
        {
            /*if (waiting > TimeSpan.Zero)
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
            }*/



        }
    }
}
