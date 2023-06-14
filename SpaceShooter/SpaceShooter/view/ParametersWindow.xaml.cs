using IHM;
using SpaceShooter.model;
using SpaceShooter.model.Ennemies;
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
using static SpaceShooter.view.HighScoresWindow;

namespace SpaceShooter.view
{
    /// <summary>
    /// Logique d'interaction pour ParametersWindow.xaml
    /// </summary>
    /// <author>Alexandre Hugot</author>
    public partial class ParametersWindow : Window
    {
        private MainWindow menu;
        private double volumeSound;
        public double VolumeSound { get; set; }
        public ParametersWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        public void BackMenu(object sender, RoutedEventArgs e)
        {
            this.menu = new MainWindow();
            this.menu.Show();
            this.Close();
        }

        private void SoundLevelSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double volume = SoundLevelSlider.Value;

            // Enregistrement de la valeur du volume dans un fichier texte
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = System.IO.Path.Combine(folderPath, "volume.txt");
            File.WriteAllText(filePath, volume.ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = System.IO.Path.Combine(folderPath, "volume.txt");

            if (File.Exists(filePath))
            {
                // Lecture de la valeur du volume à partir du fichier texte
                string volumeString = File.ReadAllText(filePath);

                if (double.TryParse(volumeString, out double volume))
                {
                    // Mise à jour de la valeur du slider avec la valeur lue du fichier texte
                    SoundLevelSlider.Value = volume;
                }
            }
            else
            {
                // Création du fichier et écriture de la valeur du slider
                double volume = SoundLevelSlider.Value;
                File.WriteAllText(filePath, volume.ToString());
            }
        }
    }
}
