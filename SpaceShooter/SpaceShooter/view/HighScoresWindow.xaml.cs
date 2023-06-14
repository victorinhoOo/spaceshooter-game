using IHM;
using IUTGame;
using SpaceShooter.model;
using System;
using System.Collections.Generic;
using System.IO;
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
using SpaceShooter.view;

namespace SpaceShooter.view
{
    /// <summary>
    /// Logique d'interaction pour HighScores.xaml
    /// </summary>
    public partial class HighScoresWindow : Window, IWindow
    {
        private TheGame game;
        private MainWindow menu;
        private int bestScore; // Variable pour stocker le meilleur score

        public HighScoresWindow()
        {
            InitializeComponent();
            LoadScores();
        }

        public void BackMenu(object sender, RoutedEventArgs e)
        {
            this.menu = new MainWindow();
            this.menu.Show();
            this.Close();
        }

        public class ScoreItem
        {
            public string PlayerName { get; set; }
            public int Score { get; set; }
        }

        private void LoadScores()
        {
            string chemin = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string scoresFilePath = System.IO.Path.Combine(chemin, "scores.txt");

            if (!File.Exists(scoresFilePath))
            {
                using (StreamWriter writer = File.CreateText(scoresFilePath))
                {
                    writer.WriteLine("ThéoTheKiller,2997600");
                    writer.WriteLine("TheGoatAlex89,2999500");
                    writer.WriteLine("RockerBabyClem,2997829");
                    writer.WriteLine("Victorihnooo,2975400");
                    writer.WriteLine("Votre Score,0");
                }
            }

            string[] lines = File.ReadAllLines(scoresFilePath);

            bool isFirstScoreAdded = false; // Variable pour suivre si le premier score du joueur a été ajouté

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string playerName = parts[0];
                    int score = int.Parse(parts[1]);

                    listHighScores.Items.Add(new ScoreItem { PlayerName = playerName, Score = score });

                    if (!isFirstScoreAdded && playerName == "Votre Score")
                    {
                        // Ajouter le premier score du joueur pour la comparaison future
                        bestScore = score;
                        isFirstScoreAdded = true;
                    }
                    else
                    {
                        // Mettre à jour le meilleur score actuel si nécessaire
                        if (score > bestScore)
                        {
                            RemoveBestScore();
                            bestScore = score;
                        }
                    }
                }
            }

            if (!isFirstScoreAdded)
            {
                // Ajouter le premier score du joueur s'il n'est pas déjà présent dans la liste
                string playerName = "Votre Score";
                int initialScore = 0;
                listHighScores.Items.Add(new ScoreItem { PlayerName = playerName, Score = initialScore });
                bestScore = initialScore;
            }
        }

        public void AddScore(string playerName, int score)
        {
            string chemin = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string scoresFilePath = System.IO.Path.Combine(chemin, "scores.txt");

            // Vérifier si le score est supérieur au meilleur score actuel
            if (score > bestScore)
            {
                // Supprimer l'ancien meilleur score de la liste
                RemoveBestScore();

                // Mettre à jour le meilleur score actuel
                bestScore = score;

                // Ajouter le nouveau meilleur score au fichier
                using (StreamWriter writer = File.AppendText(scoresFilePath))
                {
                    writer.WriteLine($"{playerName},{score}");
                }

                // Ajouter le nouveau meilleur score à la liste des scores affichée
                listHighScores.Items.Add(new ScoreItem { PlayerName = playerName, Score = score });
            }
        }

        private void RemoveBestScore()
        {
            ScoreItem bestScoreItem = null;

            foreach (ScoreItem item in listHighScores.Items)
            {
                if (item.Score == bestScore)
                {
                    bestScoreItem = item;
                    break;
                }
            }

            if (bestScoreItem != null)
            {
                listHighScores.Items.Remove(bestScoreItem);
            }
        }


        public void UpdateScore(int score)
        {
            throw new NotImplementedException();
        }

        public void CloseWindow()
        {
            throw new NotImplementedException();
        }

        public void ShowHighScoresWindow(int score)
        {
            throw new NotImplementedException();
        }
    }
}