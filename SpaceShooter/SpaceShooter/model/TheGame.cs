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
    /// <summary>
    /// Classe qui représente le jeu avec toutes les méthodes
    /// </summary>
    /// <author>Théo Cornu</author>
    /// <author>Victor Duboz</author>
    public class TheGame : IUTGame.Game
    {
        public TheGame(IScreen screen, IWindow view) : base(screen, "Sprites", "Sounds")
        {
            this.view = view;
        }

        private IWindow view;
        private int score;

        /// <summary>
        /// Propriété qui permet l'accès et la modification du score
        /// </summary>
        /// <author>Victor Duboz</author>
        public int Score { get { return score; } set { score = value; UpdateScore(score); } }


        /// <author>Clément Boutet</author>
        protected override void InitItems()
        {
            double y = 350;
            double x = this.Screen.Width / 2 -10;
            Player player = new Player(x, y, this);
            AddItem(player);
            AddItem(new GeneratorEnemy(this));

            //PlayBackgroundMusic("mainMusic.mp3");

        }

        /// <summary>
        /// Met à jour le score du joueur
        /// </summary>
        /// <param name="score">score du joueur</param>
        /// <author>Victor Duboz</author>
        public void UpdateScore(int score)
        {
            view.UpdateScore(score);
        }

        protected override void RunWhenLoose()
        {
            int score = this.Score;

            if (view is GameWindow gameWindow)
            {
                gameWindow.ShowHighScoresWindow(score);
            }

            LooseWindow loose = new LooseWindow(score); // Passer le score en tant qu'argument lors de la création de la fenêtre LooseWindow
            loose.Show();

            view.CloseWindow();
        }

        protected override void RunWhenWin()
        {
            throw new NotImplementedException();
        }
    }
}