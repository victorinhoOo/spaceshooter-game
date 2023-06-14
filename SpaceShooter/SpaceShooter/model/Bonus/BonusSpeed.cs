using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Bonus
{
    
    /// <summary>
    /// Classe heritant de Bonus représentant le bonus de vitesse
    /// </summary>
    /// <author>Clément Boutet</author>
    public class BonusSpeed : Bonus
    {
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="x">Position abscisse</param>
        /// <param name="y">Position ordonnée</param>
        /// <param name="game">Jeu auquel appartient le bonus</param>
        /// <param name="spriteName">Nom du sprite</param>
        /// <param name="zindex">position en altitude</param>
        public BonusSpeed(double x, double y, Game game, string spriteName = "speed.png", int zindex = 0) : base(x, y, game, spriteName, zindex)
        {
            base.ChangeSprite(spriteName);
        }

        public override string TypeName => "Speed";
    }
}
