﻿using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceShooter.model.Ennemies
{
    /// <summary>
    /// Gère les astéroïdes.
    /// </summary>
    /// <author>Victor Duboz</author>
    public class Asteroid : Enemy
    {
        /// <summary>
        /// Crée un astéroïde avec une vitesse spécifique (350).
        /// </summary>
        /// <param name="x">Position horizontale de l'astéroïde.</param>
        /// <param name="y">Position verticale de l'astéroïde.</param>
        /// <param name="g">Jeu auquel l'astéroïde appartient.</param>
        /// <param name="name">Nom de l'image de l'astéroïde.</param>
        /// <author>Victor Duboz</author>
        public Asteroid(double x, double y, Game g, string name = "flaming_asteroid.png") : base(x, y, g, name, 0)
        {
            base.Speed = 350;
        }

        /// <summary>
        /// Propriété qui renvoie le type de l'astéroïde.
        /// </summary>
        public override string TypeName => "Asteroid";

        /// <summary>
        /// Effet de collision de l'astéroïde avec un autre élément du jeu
        /// </summary>
        /// <param name="other">élément avec lequel l'astéroïde entre en collision</param>
        /// <author>Victor Duboz</author>
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

        /// <summary>
        /// Effectue l'animation de l'astéroïde
        /// </summary>
        /// <param name="dt">durée écoulée depuis la dernière animation</param>
        /// <author>Victor Duboz</author>
        public override void Animate(TimeSpan dt)
        {
            if (Bottom > GameHeight)
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
            if (Waiting >= test)
            {
                Waiting -= dt;
            }
        }
    }
}
