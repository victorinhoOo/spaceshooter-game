using IUTGame;
using System;

namespace SpaceShooter.model.Projectiles
{
    /// <summary>
    /// Gère les lasers tirées par les ennemis
    /// </summary>
    /// <author>Victor Duboz</author>
    public class Laser : Projectile
    {

        private TimeSpan waiting = TimeSpan.Zero;



        public Laser(double x, double y, Game g, string name = "laser.png", int zindex = 0) :
            base(x, y, g, name, zindex)
        {
            ChangeSprite(name);
            base.Speed = 650;
        }


        public override string TypeName => "Laser";




        public override void Animate(TimeSpan dt)
        {
            if (waiting > TimeSpan.Zero)
            {
                waiting = waiting - dt;
            }
            if (this.Top < 0)
            {
                TheGame.RemoveItem(this);


            }
            else if (Bottom > GameHeight)
            {
                TheGame.RemoveItem(this);

            }
            else if (Left < 0)
            {

                Left = 0;
                TheGame.RemoveItem(this);
            }
            else if (Right > GameWidth)
            {

                Right = GameWidth;
                TheGame.RemoveItem(this);
            }
            MoveDA(Speed * dt.TotalSeconds, 100);
        }

        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "Player")
            {
                //other.ChangeSprite("explosion.png");
                TheGame.Loose();
            }

        }
    }
}

