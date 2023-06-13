using IHM;
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
                // Créer le fichier scores.txt s'il n'existe pas
                using (StreamWriter writer = File.CreateText(scoresFilePath))
                {
                    // Écrire des données dans le fichier (exemple)
                    writer.WriteLine("ThéoTheKiller,2677600");
                    writer.WriteLine("TheGoatAlex89,2424500");
                    writer.WriteLine("Victorihnooo,2975400");
                    writer.WriteLine("RockerBabyClem,2797829");
                }
            }

            // Charger les scores à partir du fichier
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
    }
}
