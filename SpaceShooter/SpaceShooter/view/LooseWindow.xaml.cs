using IHM;
using SpaceShooter.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SpaceShooter.view
{
    /// <summary>
    /// Logique d'interaction pour LooseWindow.xaml
    /// </summary>
    /// <author>Théo Cornu</author>
    public partial class LooseWindow : Window, IWindow
    {
        private GameWindow gameWindow;
        private MainWindow mainWindow;
        )

        public LooseWindow(int score)
        {
            InitializeComponent();
           
        }

        // Méthode pour démarrer une nouvelle partie
        public void Play(object sender, RoutedEventArgs e)
        {
            this.gameWindow = new GameWindow();
            this.gameWindow.Show();
            this.Close();
        }

        // Méthode pour revenir au menu principal
        public void Menu(object sender, RoutedEventArgs e)
        {
            this.mainWindow = new MainWindow();
            this.mainWindow.Show();
            this.Close();
        }

        // Méthode non implémentée de l'interface IWindow pour mettre à jour le score
        void IWindow.UpdateScore(int score)
        {

        }

        // Méthode non implémentée de l'interface IWindow pour fermer la fenêtre
        void IWindow.CloseWindow()
        {

        }

        // Méthode non implémentée de l'interface IWindow pour afficher la fenêtre des meilleurs scores
        public void ShowHighScoresWindow(int score)
        {
            throw new NotImplementedException();
        }
    }
}







