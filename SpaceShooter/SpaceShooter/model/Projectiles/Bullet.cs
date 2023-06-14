using IUTGame;
using System;

namespace SpaceShooter.model.Projectiles
{
    /// <summary>
    /// Gère les balles tirées par les ennemis
    /// </summary>
    /// <author>Théo Cornu</author>
    public class Bullet : Projectile
    {          

        

        public Bullet(double x, double y, Game g, string name = "bullet.png", int zindex = 0) :
            base(x, y, g, name, zindex)
        {
            ChangeSprite(name);
            base.Speed = 250;
        }

        

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
