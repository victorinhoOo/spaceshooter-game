using IUTGame;
using SpaceShooter.model.Ennemies;
using SpaceShooter.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SpaceShooter.view;

namespace SpaceShooter.model
{
    public class TheGame : IUTGame.Game
    {
        public TheGame(IScreen screen, GameWindow gameWindow) : base(screen, "Sprites", "Sounds")
        {
            this.gameWindow = gameWindow;
        }

        private GameWindow gameWindow;
        private int score;

        /// <summary>
        /// Propriété qui permet l'accès et la modification du score
        /// </summary>
        /// <author>Victor Duboz</author>
        public int Score { get { return score; } set { score = value; UpdateScore(); } }

        protected override void InitItems()
        {
            double y = 350;
            double x = this.Screen.Width / 2 -10;
            Player player = new Player(x, y, this);
            AddItem(player);
            AddItem(new GeneratorEnemy(this));

            //PlayBackgroundMusic("mainMusic.mp3");

        }

        public void UpdateScore()
        {
            gameWindow.UpdateScore();
        }

        protected override void RunWhenLoose()
        {
            throw new NotImplementedException();
        }

        protected override void RunWhenWin()
        {
            throw new NotImplementedException();
        }
    }
}