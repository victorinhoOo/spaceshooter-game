using IUTGame;
using IUTGame.WPF;
using SpaceShooter.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Formats.Asn1.AsnWriter;
using SpaceShooter.Res;

namespace SpaceShooter.view
{
    /// <summary>
    /// Logique d'interaction pour GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window, IWindow
    {
        private TheGame game;

        /// <author>Clément Boutet</author>
        public GameWindow()
        {
            InitializeComponent();
            this.Loaded += Play;

        }

        /// <author>Clément Boutet</author>
        public void Play(object sender, RoutedEventArgs e)
        {
            WPFScreen screen = new WPFScreen(this.canvas);
            this.game = new TheGame(screen, this);
            this.game.Run();
        }

  
        /// <summary>
        /// Met à jour le score du joueur sur la fenêtre
        /// </summary>
        /// <param name="score">score du joueur</param>
        /// <author>Victor Duboz</author>
        public void UpdateScore(int score)
        {
            this.scoreLabel.Content = Res.Strings.Score;
            this.scoreLabel.Content += score.ToString();
        }

        public void CloseWindow()
        {
            this.Close();
        }
        public void ShowHighScoresWindow(int score)
        {
            HighScoresWindow highScores = new HighScoresWindow();
            highScores.AddScore("Votre Score", score); 
            
            this.Close();
        }

    }
}
