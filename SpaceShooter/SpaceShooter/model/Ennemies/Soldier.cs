using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Ennemies
{
    public class Soldier : Enemy
    {        
        public Soldier(double x, double y, Game g, string name = "Ship_5.png") : base(x, y, g, name, -100)
        {



        }
        
        public override string TypeName => "Soldier";
        public void Shoot()
        {

        }
        public override void Animate(TimeSpan dt)
        {
            if (this.Top < 0)
            {
                Top = 0;
                Angle = 360 - Angle;

            }
            else if (Bottom > GameHeight)
            {
                TheGame.RemoveItem(this);
                --Amount;
            }
            else if (Left < 0)
            {
                Angle = (360 + 180 - Angle) % 360;
                Left = 0;

            }
            else if (Right > GameWidth)
            {
                Angle = (360 + 180 - Angle) % 360;
                Right = GameWidth;
            }
            MoveDA(Speed * dt.TotalSeconds, Angle);
            TimeSpan test = new TimeSpan(0, 0, 0, 0, 0);
            if (Waiting >= test) { Waiting -= dt; }
        }


    }


}
