using IHM;
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
    /// Logique d'interaction pour HighScores.xaml
    /// </summary>
    public partial class HighScoresWindow : Window
    {
        private MainWindow menu;
        public HighScoresWindow()
        {
            InitializeComponent();
        }

        public void BackMenu(object sender, RoutedEventArgs e)
        {
            this.menu = new MainWindow();
            this.menu.Show();
            this.Close();
        }
    }
}
