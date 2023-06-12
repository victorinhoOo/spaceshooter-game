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
    public partial class LooseWindow : Window
    {
        private GameWindow gameWindow;
        public LooseWindow()
        {
            InitializeComponent();
            
           
        }
        public void Play(object sender, RoutedEventArgs e)
        {
            this.gameWindow = new GameWindow();
            this.gameWindow.Show();
            this.Close();
        }

        public void Quit(object sender, RoutedEventArgs e)
        {
            
            
            this.Close();
        }
    }
}
