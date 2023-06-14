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



        /// <summary>
        /// Créé un laser, lui attribut une vitesse de 750
        /// </summary>
        /// <author>Victor Duboz</author>
 
        public Laser(double x, double y, Game g, string name = "laser.png", int zindex = 0) :
            base(x, y, g, name, zindex)
        {
            ChangeSprite(name);
            base.Speed = 750;
        }




        /// <summary>
        /// Animation du laser
        /// </summary>
        /// <param name="dt">temps depuis la dernière animation</param>
        /// <author>Victor Duboz</author>
        public override void Animate(TimeSpan dt)
        {
            if (Bottom > GameHeight)
            {
                TheGame.RemoveItem(this);

            }
            MoveDA(Speed * dt.TotalSeconds, 100);
        }

        public override void CollideEffect(GameItem other)
        {
        }
    }
}

