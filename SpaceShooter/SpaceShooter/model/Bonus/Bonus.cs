using IUTGame;
using SpaceShooter.model.Ennemies;
using SpaceShooter.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpaceShooter.model.Bonus
{
    /// <summary>
    /// Représente les bonus du jeux
    /// </summary>
    /// <author>Clément Boutet</author>
    public abstract class Bonus : GameItem, IAnimable
    {

        private TimeSpan delay;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="x">Position abscisse</param>
        /// <param name="y">Position ordonnée</param>
        /// <param name="game">Jeu auquel appartient le bonus</param>
        /// <param name="spriteName">Nom du sprite</param>
        /// <param name="zindex">position en altitude</param>
        public Bonus(double x, double y, Game game, string spriteName="", int zindex = 0) : base(x, y, game, spriteName, zindex)
        {
            this.delay = new TimeSpan(0,0,3);
        }

        public override string TypeName => "Bonus";


        /// <summary>
        /// Méthode qui correspond à l'animation de l'objet
        /// </summary>
        /// <param name="dt">Temps qui s'écoule</param>
        public void Animate(TimeSpan dt)
        {
           this.delay -= dt;
           if(this.delay <= TimeSpan.Zero)
            {
                TheGame.RemoveItem(this);
            }
            MoveDA(100 * dt.TotalSeconds, 90);
        }


        public override void CollideEffect(GameItem other)
        {
        }



    }
}
