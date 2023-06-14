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
    /// Logique d'interaction pour ParametersWindow.xaml
    /// </summary>
    /// /// <author>Alexandre Hugot</author>
    public partial class ParametersWindow : Window
    {
        private TheGame game;
        private MainWindow menu;
        public ParametersWindow()
        {
            InitializeComponent();
        }

        private void SliderMusic_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (game != null)
            {
                this.game.BackgroundVolume = (double)musicLevel.Value / 100;
            }
        }

        public void BackMenu(object sender, RoutedEventArgs e)
        {
            this.menu = new MainWindow();
            this.menu.Show();
            this.Close();
        }

    }
}
