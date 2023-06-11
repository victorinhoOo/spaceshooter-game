using IUTGame;
using System;

namespace SpaceShooter.model.Projectiles
{
    /// <summary>
    /// Gère les balles tirés par le joueur
    /// </summary>
    /// <author>Victor Duboz</author>
    public class PlayerBullet : Projectile
    {


        private TimeSpan waiting = TimeSpan.Zero;


        /// <summary>
        /// Créé une balle du joueur
        /// </summary>
        /// <author>Victor Duboz</author>
        public PlayerBullet(double x, double y, Game g, string name = "SpritePlayerBullet", int zindex = 0) :
            base(x, y, g, name, zindex)
        {
            base.Speed = 400;
        }

        /// <summary>
        /// Renvoi le type de la balle tirée par le joueur
        /// </summary>
        public override string TypeName => "PlayerBullet";

        /// <summary>
        /// Gère les collision entre les balles du joueur et les autres items du jeu
        /// </summary>
        /// <param name="other">autre item du jeu</param>
        public override void CollideEffect(GameItem other)
        {
            
        }

        /// <summary>
        /// Gère les animations des balles du joueur
        /// </summary>
        /// <param name="dt">durée écoulée depuis la dernière animation</param>
        /// <author>Victor Duboz</author>
        public override void Animate(TimeSpan dt)
        {

            MoveDA(Speed * dt.TotalSeconds, 270);
        }
    }
}

