﻿using IHM;
using IUTGame;
using IUTGame.WPF;
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
    /// Logique d'interaction pour GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private TheGame game;
        public GameWindow()
        {
            InitializeComponent();
        }

        public void Play(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space) 
            {
                WPFScreen screen = new WPFScreen(this.canvas);
                this.game = new TheGame(screen);
                this.game.Run();
            }
            if(e.Key == Key.Escape)
            {
                new MainWindow().Show();
                this.Close();
            }
        }
    }
}
