using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Ennemies
{
    public class Officer : Enemy
    {
        public Officer(double x, double y, Game g, string name = "Ship_3.png") : base(x, y, g, name, -100)
        {
            base.Speed = 150;

        }
        public override string TypeName => "Officer";
        public void ShootBomb()
        {

        }
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
