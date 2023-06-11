using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceShooter.model.Ennemies
{
    public class Asteroid : Enemy
    {
        public Asteroid(double x, double y, Game g, string name = "flaming_asteroid.png") : base(x, y, g, name, 0)
        {
            base.Speed= 320;
        }

        public override string TypeName => "Asteroid";

        public override void CollideEffect(GameItem other)
        {
            if (Touched == false)
            {
                Waiting = new TimeSpan(0, 0, 0, 600);
                Touched = true;
            }
            else if (Touched == true && Waiting <= TimeSpan.Zero)
            {
                Touched = false;
            }
            if (other.TypeName == "Player")
            {
                TheGame.RemoveItem(this);
            }
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
