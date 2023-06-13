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
    public partial class HighScoresWindow : Window
    {
        private MainWindow menu;
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
                }
            }

            string[] lines = File.ReadAllLines(scoresFilePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string playerName = parts[0];
                    int score = int.Parse(parts[1]);

                    listHighScores.Items.Add(new ScoreItem { PlayerName = playerName, Score = score });
                }
            }
        }

        private void AddScore(string playerName, int score)
        {
            string chemin = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string scoresFilePath = System.IO.Path.Combine(chemin, "scores.txt");

            // Ajouter le nouveau score au fichier
            using (StreamWriter writer = File.AppendText(scoresFilePath))
            {
                writer.WriteLine($"{playerName},{score}");
            }

            // Ajouter le nouveau score à la liste des scores affichée
            listHighScores.Items.Add(new ScoreItem { PlayerName = playerName, Score = score });
        }

        private void SubmitScore(object sender, RoutedEventArgs e)
        {
            // Obtenir le nom du joueur et le score depuis le formulaire
            string playerName = txtPlayerName.Text;
            int score = 2; 

            // Ajouter le score
            AddScore(playerName, score);
        }
    }
}
