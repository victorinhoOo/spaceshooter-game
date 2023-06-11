using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Projectiles
{
    /// <summary>
    /// Gère les projectiles du jeu
    /// </summary>
    /// <author>Théo Cornu</author>
    abstract public class Projectile : GameItem, IAnimable
    {
        private double speed = 200;
        public double Speed { get => speed; set => speed = value; }
        private TimeSpan waiting = TimeSpan.Zero;
        private bool touched = false;
        public TimeSpan Waiting { get => waiting; set => waiting = value; }
        public bool Touched { get => touched; set => touched = value; }

        /// <summary>
        /// Créé un projectile
        /// </summary>
        ///<author>Théo Cornu</author>
        public Projectile(double x, double y, Game g, string name , int zindex = 0) :
            base(x, y, g, "player_bullet.png", zindex)
        {

        }
        public override void CollideEffect(GameItem other)
        {

        }
        abstract public void Animate(TimeSpan dt);
        
        /// <summary>
        /// Renvoi le type de projectile
        /// </summary>
        public override string TypeName => "Projectile";
    }
}
