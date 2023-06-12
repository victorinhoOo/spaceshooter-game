using IUTGame;
using IUTGame.WPF;
using SpaceShooter.model;
using SpaceShooter.view;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IHM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameWindow gameWindow;
        private HighScoresWindow highScoresWindow;
        private ParametersWindow parametersWindow;
        public MainWindow()
        {
            InitializeComponent();

        }

        public void Play(object sender, RoutedEventArgs e)
        {
            this.gameWindow = new GameWindow();
            this.gameWindow.Show();
            this.Close();
        }

        public void OpenHighScoresWindow(object sender, RoutedEventArgs e)
        {
            this.highScoresWindow = new HighScoresWindow();
            this.highScoresWindow.Show();
            this.Close();
        }

        public void OpenParametersWindow(object sender, RoutedEventArgs e)
        {
            this.parametersWindow = new ParametersWindow();
            this.parametersWindow.Show();
            this.Close();
        }

        public void Quit(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}
